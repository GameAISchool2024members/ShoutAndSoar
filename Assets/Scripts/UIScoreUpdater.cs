using TMPro;
using UnityEngine;

public class UIScoreUpdater : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;
    [SerializeField]
    private PointManager _pointManager;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        _pointManager.OnPointsChanged += UpdateText;
    }

    private void UpdateText()
    {
        text.text = _pointManager.Points.ToString();
    }
}
