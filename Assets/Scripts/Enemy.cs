using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _agent;

    public void SetTarget(GameObject target)
    {
        _agent.SetDestination(target.transform.position);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Base"))
        {
            LifeCounter.Instance.RemoveLife();
            Destroy(gameObject);
            
            if(LifeCounter.Instance.IsFinish)
                GameController.Instance.LoseGame();
        }
        if (collision.collider.CompareTag("Player"))
        {
            ScoreCounter.Instance.AddScore();
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.CompareTag("Base"))
        {
            LifeCounter.Instance.RemoveLife();
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("Player"))
        {
            ScoreCounter.Instance.AddScore();
            Destroy(gameObject);
        }

    }
}
