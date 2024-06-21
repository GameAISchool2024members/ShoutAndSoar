using System;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class PointSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _pointPrefab;
    [SerializeField]
    private PlaneMovement _planeMovement;

    [SerializeField]
    private Vector2 _maxBounds = new Vector2(3, 3);

    [SerializeField] 
    private float timeToSpawn = 3f;
    private float spawnTimer = 0f;


    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= timeToSpawn)
        {
            SpawnPoint();
            spawnTimer = 0;
        }
    }

    private void SpawnPoint()
    {
        var location = new Vector3(
            UnityEngine.Random.Range(-_maxBounds.X, _maxBounds.X), 
            UnityEngine.Random.Range(-_maxBounds.Y, _maxBounds.Y),
            transform.position.z + transform.localPosition.z * _planeMovement.SpeedRamp * 2);
        Instantiate(_pointPrefab, location, Quaternion.identity);
    }
}