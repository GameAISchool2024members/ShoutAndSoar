using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    public TerrainGenerator Generator;

    [SerializeField, Tooltip("The number of planes to spawn determines the width")] private float _planesToSpawn = 3;
    private float _currentOffset = 0;
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
            var xOffset = Generator.PlaneSize.x * i;
            var generator = Instantiate(Generator, new Vector3(currentPosition.x + xOffset, currentPosition.y,
                currentPosition.z + _currentOffset), Quaternion.identity);
            generator.SetOffset(new Vector2(xOffset, _currentOffset));
            generator.transform.SetParent(this.transform);
        }
        _currentOffset += Generator.PlaneSize.y;
    }
}
