using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    public GameObject Generator;

    [SerializeField, Tooltip("The number of planes to spawn determines the width")] private float _planesToSpawn = 3;
    private float _currentOffset = 0;

    public int planeSize;
    [SerializeField] private int _initialSpawn;
    void Start()
    {
        #if UNITY_EDITOR
        if (Generator == null)
        {
            Debug.LogWarning("NO GENERATOR SET");
        }
        #endif
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
        }
        _currentOffset += planeSize;
    }
}
