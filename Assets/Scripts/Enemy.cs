using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _agent;

    public Action OnDestroyAction { get; set; }

    public void SetTarget(GameObject target)
    {
        _agent.isStopped = false;
        _agent.ResetPath();
        _agent.SetDestination(target.transform.position);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Base"))
        {
            LifeCounter.Instance.RemoveLife();
            _agent.isStopped = true;
            _agent.ResetPath();
            ObjectPoolController.Instance.SetToPool(gameObject, ObjectPoolController.ElementType.SimpleEnemy);
            OnDestroyAction?.Invoke();
            
            if(LifeCounter.Instance.IsFinish)
                GameController.Instance.LoseGame();
        }
        if (collision.collider.CompareTag("Player"))
        {
            _agent.isStopped = true;
            _agent.ResetPath();
            ScoreCounter.Instance.AddScore();
            ObjectPoolController.Instance.SetToPool(gameObject, ObjectPoolController.ElementType.SimpleEnemy);
            OnDestroyAction?.Invoke();
        }
    }
    
    private void OnCollisionStay(Collision collision)
    {
        
        if(collision.collider.CompareTag("Base"))
        {
            _agent.isStopped = true;
            _agent.ResetPath();
            LifeCounter.Instance.RemoveLife();
            ObjectPoolController.Instance.SetToPool(gameObject, ObjectPoolController.ElementType.SimpleEnemy);
            OnDestroyAction?.Invoke();
        }
        if (collision.collider.CompareTag("Player"))
        {
            _agent.isStopped = true;
            _agent.ResetPath();
            ScoreCounter.Instance.AddScore();
            ObjectPoolController.Instance.SetToPool(gameObject, ObjectPoolController.ElementType.SimpleEnemy);
            OnDestroyAction?.Invoke();
        }

    }

}
