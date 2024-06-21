using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PointManager _pointManager;
    [SerializeField]
    private SkyboxChanger _skyboxChanger;

    [SerializeField] private float _gameTime = 60f;
    private float _gameTimer;
    private void Start()
    {
        _pointManager.ResetPoints();
        _skyboxChanger.SetRandomSkybox();
    }

    private void Update()
    {
        _gameTimer += Time.deltaTime;
        if (_gameTimer >= _gameTime)
        {
        }
    }
}
