using UnityEngine;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using System.Text;

public class SkyboxChanger : MonoBehaviour
{
    public Material[] skyboxes; // Array to hold the skybox materials
    public float changeInterval = 100f; // Interval time in seconds
    public GameObject[] seasons;
    public GameObject panel;
    public GameObject ending;
    public GameObject objectWCounter;
    private int currentSkyboxIndex = 0;
    private float timer;
    public bool ended = false;

    void Start()
    {
        if (skyboxes.Length > 0)
        {
            RenderSettings.skybox = skyboxes[currentSkyboxIndex];
        }
        timer = changeInterval;
        ChangeSkybox();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            ChangeSkybox();
            timer = changeInterval;
        }
    
    }

     IEnumerator WaitAndChangeSkybox()
    {
        yield return new WaitForSeconds(6f);
        panel.gameObject.SetActive(false);
        seasons[currentSkyboxIndex].SetActive(false);
    }

    void ChangeSkybox()
    {
        int old = currentSkyboxIndex;
        if (currentSkyboxIndex < skyboxes.Length - 1){
        currentSkyboxIndex = currentSkyboxIndex + 1;
        RenderSettings.skybox = skyboxes[currentSkyboxIndex];
        panel.gameObject.SetActive(true);
        Debug.Log(seasons[currentSkyboxIndex]);
        seasons[currentSkyboxIndex].SetActive(true);
        seasons[old].SetActive(false);
        StartCoroutine(WaitAndChangeSkybox());
        }else{
            ending.gameObject.SetActive(true);
            ended = true;
        }
    }

    /*void CreateCSV(){
         using (StreamWriter writer = new StreamWriter(path, true, Encoding.UTF8))
        {
           // writer.Write($"{heartsCaught}", $"{totalHearts}");
            writer.WriteLine();
        }
}*/


}