using UnityEngine;

public class CatcherFallen : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            ScoreCounter.Instance.AddScore();
            ObjectPoolController.Instance.SetToPool(collision.gameObject, ObjectPoolController.ElementType.SimpleEnemy);
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
            ObjectPoolController.Instance.SetToPool(collision.gameObject, ObjectPoolController.ElementType.SimpleEnemy);
        }
        
        if (collision.collider.CompareTag("Player"))
        {
            GameController.Instance.LoseGame();
        }
    }
}