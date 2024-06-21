using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PointManager _pointManager;
    [SerializeField]
    private SkyboxChanger _skyboxChanger;
    private void Start()
    {
        _pointManager.ResetPoints();
        _skyboxChanger.SetRandomSkybox();
    }
}