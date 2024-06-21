using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PointManager _pointManager;
    [SerializeField]
    private SkyboxChanger _skyboxChanger;
    [SerializeField] private float _gameTime = 60f;
    private float _gameTimer;
    
    [SerializeField]
    Image GameOverPanel;
    
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
            StartCoroutine(FadeInEnumerator());
        }
    }

    IEnumerator FadeInEnumerator()
    {
        while (GameOverPanel.color.a < 1)
        {
            GameOverPanel.color = new Color(GameOverPanel.color.r, GameOverPanel.color.g, GameOverPanel.color.b, GameOverPanel.color.a + Time.deltaTime);
            yield return null;
        }
        // SceneManager.LoadScene()
    }
}
