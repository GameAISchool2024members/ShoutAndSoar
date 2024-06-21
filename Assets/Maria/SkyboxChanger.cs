using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class SkyboxChanger : MonoBehaviour
{
    public Season[] seasons;
    private int currentSkyboxIndex = 0;
    private float timer;
    public bool ended = false;
    public TerrainSpawner terrainSpawner;

    public void SetRandomSkybox()
    {
        var skyboxIndex = Random.Range(0, seasons.Length);

        var season = seasons[skyboxIndex];
        RenderSettings.skybox = season.skybox;
        season.textPanel.SetActive(true);

        terrainSpawner.changeSeason(season.SeasonName);
        StartCoroutine(SetInactiveAfterSections(season.textPanel, 5f));
    }
    
    IEnumerator SetInactiveAfterSections(GameObject obj, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }
}

[Serializable]
public class Season
{
    public Material skybox;
    public GameObject textPanel;
    public string SeasonName;
}