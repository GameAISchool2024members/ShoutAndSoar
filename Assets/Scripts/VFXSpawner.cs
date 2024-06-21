using UnityEngine;

[CreateAssetMenu(fileName = "VFXSpawner", menuName = "ScriptableObjects/VFXSpawner", order = 1)]
public class VFXSpawner : ScriptableObject
{
    [SerializeField]
    private GameObject _pointVFX;
    
    public void SpawnCelebrationVFX(Vector3 location)
    {
        SpawnObject(_pointVFX, location);
    }
    
    public void SpawnObject(GameObject objectToSpawn, Vector3 location)
    {
        Instantiate(objectToSpawn, location, Quaternion.identity);
    }
}