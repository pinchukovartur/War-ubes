using System.Collections;
using System.Collections.Generic;
using Source.Scripts.Windows;
using UnityEngine;
using UnityEngine.UI;

public class FailWindow : Singleton<FailWindow>
{
    [SerializeField]
    public WindowAnimationController AnimationController;

    [SerializeField]
    private Text _scoreText;

    public void RestartAction()
    {
        GameController.Instance.StartNewGame();
    }

    public void SetScore(int score)
    {
        _scoreText.text = $"Score: {score}";
    }
}
