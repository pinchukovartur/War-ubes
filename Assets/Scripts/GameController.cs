using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    public State CurrentState = State.Play;
    
    public void LoseGame()
    {
        if(CurrentState == State.Lose)
            return;

        CurrentState = State.Lose;
        EnemyBase.Instance.StopSpawn();
        EnemyBase.Instance.DestroyEnemies();
        FailWindow.Instance.SetScore(ScoreCounter.Instance.Score);
        FailWindow.Instance.AnimationController.Show();
    }

    public void StartNewGame()
    {
        if(CurrentState == State.Play)
            return;

        CurrentState = State.Play;
        Player.Instance.transform.position = new Vector3(5.5f, 1.5f);
        
        ScoreCounter.Instance.ResetScore();
        LifeCounter.Instance.ResetLife();
        
        EnemyBase.Instance.StartSpawn();
        FailWindow.Instance.AnimationController.Hide();
    }
    
    public enum State
    {
        Play,
        Lose
    }
}