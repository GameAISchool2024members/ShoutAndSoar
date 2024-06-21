using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public static TerrainManager Instance { get; private set; }

    public int runningId = 0;

    private void Awake()
{
    // If there is an instance, and it's not me, delete myself.

    if (Instance != null && Instance != this)
    {
        Destroy(this);
    }
    else
    {
        Instance = this;
    }
}
}