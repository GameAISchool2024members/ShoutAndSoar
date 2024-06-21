using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using System.Text;
using System.Linq;



public class PlayerMovementArrowKeys : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject objectToInstantiate;
    private Vector3 lastPosition;
    private float distanceMoved = 0f;
    public GameObject[] seasons;
    private float number = 1;
    private int heartsCollected = 0;
    private int totalheartsInGame = 0;
    public TMP_Text heartText;
    public GameObject objectWCounter;
    private SkyboxChanger sky;
    private bool ending;
    private string path = Application.dataPath + "/Maria/Ending.txt";
    public TMP_Text firstPlace;
    public TMP_Text secondPlace;
    public TMP_Text thirdPlace;
    private bool didItOnce = false;

    void Start()
    {
        // Initialize the last position
        lastPosition = transform.position;
        sky = objectWCounter.GetComponent<SkyboxChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sky.ended && !didItOnce){
            Debug.Log("TotalHearts in game" + totalheartsInGame);
            CreateOrUpdateTextFile();
            sky.ended = false;
            didItOnce = true;
        }else{
        // Get input from the arrow keys
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector3 movement = new Vector3(-moveY, 0, moveX);

        // Normalize the movement vector to ensure consistent speed in all directions
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        // Move the object
        transform.Translate(movement);

        // Update the distance moved
        distanceMoved += Mathf.Abs(transform.position.z - lastPosition.z);
        lastPosition = transform.position;
        for (int i = 1; i <= seasons.Length - 1; i++){
            if(seasons[i].gameObject.activeSelf){
                number = i;
            }
        }
        // Check if the player has moved 5 units forward
        if (distanceMoved >= 5f)
        {
            // Reset the distance moved
            distanceMoved = 0f;
            float randomX = UnityEngine.Random.Range(-2f, 2f);
            float randomY = UnityEngine.Random.Range(-2f, 2f);
            float randomZ = UnityEngine.Random.Range(transform.position.z + 15, transform.position.z + 30);
        if (number == 2){
        randomX = UnityEngine.Random.Range(-5f, 5f);
         randomY = UnityEngine.Random.Range(-5f, 5f);
         randomZ = UnityEngine.Random.Range(transform.position.z + 12, transform.position.z + 26);
        }
        if (number == 3){
        randomX = UnityEngine.Random.Range(-8f, 8f);
        randomY = UnityEngine.Random.Range(-8f, 8f);
        randomZ = UnityEngine.Random.Range(transform.position.z + 12, transform.position.z + 24);
        }
        if (number == 4){
        randomX = UnityEngine.Random.Range(-8f, 8f);
        randomY = UnityEngine.Random.Range(-8f, 8f);
        randomZ = UnityEngine.Random.Range(transform.position.z + 9, transform.position.z + 19);
        }

        // Calculate the new position
        Vector3 randomPosition = new Vector3(transform.position.x + randomX, transform.position.y + randomY, randomZ);

        // Instantiate the heart at the new position
        Instantiate(objectToInstantiate, randomPosition, Quaternion.identity);
        totalheartsInGame++;
        }
        heartText.text = heartsCollected.ToString();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has a specific tag or component (adjust as needed)
        if (collision.gameObject.CompareTag("Heart"))
        {
            // Increase the counter
            heartsCollected++;

            // Delete the collided object
            Destroy(collision.gameObject);

            // Optionally, perform other actions or logic here
        }
    }

    /*void CreateCSV(){
         using (StreamWriter writer = new StreamWriter(path, true, Encoding.UTF8))
        {
            if (!File.Exists(path))
            {
                firstPlace.text = heartsCollected + " Hearts";
            }
            writer.Write($"{heartsCollected}");
            writer.WriteLine();
            SortCSVByFirstColumn();
        }

    void SortCSVByFirstColumn()
    {
        // Read all lines from the CSV file
        var lines = File.ReadAllLines(path, Encoding.UTF8).ToList();

        // Extract the header (assuming the first line is the header)
        var header = lines.First();
        lines.RemoveAt(0);

        // Parse the remaining lines into a list of tuples (number, line)
        var parsedLines = lines
            .Select(line => (number: int.Parse(line.Split(',')[0]), line))
            .ToList();

        // Sort the parsed lines by the number in the first column
        parsedLines.Sort((a, b) => a.number.CompareTo(b.number));

        // Reconstruct the sorted lines including the header
        var sortedLines = new List<string> { header };
        sortedLines.AddRange(parsedLines.Select(tuple => tuple.line));

        // Write the sorted lines back to the CSV file
        File.WriteAllLines(path, sortedLines, Encoding.UTF8);
    }*/

    void CreateOrUpdateTextFile()
    {
        try
        {
            // Append the new result to the text file
            using (StreamWriter writer = new StreamWriter(path, true, Encoding.UTF8))
            {
                if (writer.BaseStream.Length > 0)
                {
                    writer.Write($",{heartsCollected}");
                }
                else
                {
                    writer.Write(heartsCollected);
                }
            }
        }
        catch (IOException ex)
        {
            Debug.LogError($"Failed to write to file: {ex.Message}");
        }
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