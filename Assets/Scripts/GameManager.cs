using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PointManager _pointManager;
    private void Start()
    {
        _pointManager.ResetPoints();
    }
}