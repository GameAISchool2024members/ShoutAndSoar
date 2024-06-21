using UnityEngine;

[CreateAssetMenu(fileName = "PointManager", menuName = "ScriptableObjects/PointManager", order = 1)]
public class PointManager : ScriptableObject
{
    [SerializeField]
    private int _points;
    
    public int Points => _points;

    public void AddPoints(int points)
    {
        _points += points;
    }
    
    public void ResetPoints()
    {
        _points = 0;
    }
}