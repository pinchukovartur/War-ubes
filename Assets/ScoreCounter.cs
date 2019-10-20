using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : Singleton<ScoreCounter>
{
    [SerializeField, Tooltip("Ui text for score count")]
    private Text _scoreText;
    
    [SerializeField, Tooltip("Current count")]
    private int _currentCount;

    private void Awake()
    {
        _scoreText.text = _currentCount.ToString();
    }

    public void AddScore()
    {
        _currentCount++;
        _scoreText.text = _currentCount.ToString();
    }
}
