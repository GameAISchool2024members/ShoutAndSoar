using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine.UI;
using System.Text;
using System.Linq;


public class ScoresEnding : MonoBehaviour
{
    public TMP_Text firstPlace;
    public TMP_Text secondPlace;
    public TMP_Text thirdPlace;
    private string path = Application.dataPath + "/Maria/Ending.txt";

    // Start is called before the first frame update
    void Start()
    {
        SortTextFileByDescendingOrder();
    }

    void SortTextFileByDescendingOrder()
    {
        List<string> lines = new List<string>();
        try
        {
            // Read all lines from the text file
            lines = File.ReadAllLines(path, Encoding.UTF8).ToList();
        }
        catch (IOException ex)
        {
            Debug.LogError($"Failed to read file: {ex.Message}");
            return;
        }

        // Check if there are any lines in the file
        if (lines.Count > 0)
        {
            // Get the first line and split by commas
            string firstLine = lines[0];
            string[] total = firstLine.Split(',');
            int[] intArray = Array.ConvertAll(total, int.Parse);
            Array.Sort<int>(intArray,
                    new Comparison<int>(
                            (i1, i2) => i1.CompareTo(i2)
                    ));
            firstPlace.text = intArray[intArray.Length - 1].ToString();
            secondPlace.text = intArray[intArray.Length - 2].ToString();
            thirdPlace.text = intArray[intArray.Length - 3].ToString();
        }
        else
        {
            Debug.LogWarning("The file is empty.");
        }
    }
}