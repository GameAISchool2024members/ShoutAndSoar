using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    public GameObject WinterGenerator;
    public GameObject SpringGenerator;
    private GameObject Generator;
    private List<GameObject> _planes = new List<GameObject>();

    [SerializeField, Tooltip("The number of planes to spawn determines the width")] private float _planesToSpawn = 3;
    private float _currentOffset = 0;

    public int planeSize;
    [SerializeField] private int _initialSpawn;
    void Start()
    {
        Generator = WinterGenerator;
        for (int i = 0; i < _initialSpawn; i++)
        {
            SpawnPlanes();
        }
    }

    public void changeSeason(string season)
    {
        if (season == "Winter")
        {
            Generator = WinterGenerator;
        }
        else if (season == "Spring")
        {
            Generator = SpringGenerator;
        }
        // Remove all previous planes
        foreach (var plane in _planes)
        {
            Destroy(plane);
        }
        for (int i = 0; i < _initialSpawn; i++)
        {
            SpawnPlanes();
        }
    }

    [ContextMenu("Spawn More Planes")]
    void SpawnPlanes()
    {
        var currentPosition = transform.position;
        for (int i = 0; i < _planesToSpawn; i++)
        {
            var xOffset = planeSize * i;
            var generator = Instantiate(Generator, transform);
            generator.transform.localPosition = new Vector3(xOffset, 0, _currentOffset);
            Debug.Log($"Spawning plane at {new Vector3(xOffset, 0, _currentOffset)}");
            generator.GetComponent<TerrainGenerator>().SetOffset(new Vector2(xOffset, _currentOffset));
            _planes.Add(generator);
        }
        _currentOffset += planeSize;
    }
}
