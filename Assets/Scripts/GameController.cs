using UnityEngine;

public class GameController : Singleton<GameController>
{
    public State CurrentState;

    public void Awake()
    {
        StartNewGame();
    }

    public void LoseGame()
    {
        if(CurrentState == State.Lose)
            return;

        CurrentState = State.Lose;
        EnemyBase.Instance.StopSpawn = true;
        EnemyBase.Instance.DestroyEnemies();
        FailWindow.Instance.SetScore(ScoreCounter.Instance.Score);
        FailWindow.Instance.AnimationController.Show();
    }

    public void StartNewGame()
    {
        if(CurrentState == State.Play)
            return;

        if (CurrentState == State.Lose)
        {
            FailWindow.Instance.AnimationController.Hide();
        }
        
        CurrentState = State.Play;
        Player.Instance.transform.position = new Vector3(5.5f, 1.5f);

        EnemyBase.Instance.StopSpawn = false;
        WaysController.Instance.ResetWays();
        ScoreCounter.Instance.ResetScore();
        LifeCounter.Instance.ResetLife();

        StartCoroutine(EnemyBase.Instance.StartEnemyWay());
    }
    
    public enum State
    {
        None,
        Play,
        Lose
    }
}