using UnityEngine;

public class CatcherFallen : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            ScoreCounter.Instance.AddScore();
            Destroy(collision.gameObject);
        }
        
        if (collision.collider.CompareTag("Player"))
        {
            GameController.Instance.LoseGame();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            ScoreCounter.Instance.AddScore();
            Destroy(collision.gameObject);
        }
        
        if (collision.collider.CompareTag("Player"))
        {
            GameController.Instance.LoseGame();
        }
    }
}