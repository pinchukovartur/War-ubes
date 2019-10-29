using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : Singleton<EnemyBase>
{
    [SerializeField] private Enemy _enemyPrefab;

    [SerializeField] private Transform _rootForEnemies;

    [SerializeField] private GameObject _targetEnemies;

    private List<Enemy> _enemies = new List<Enemy>();

    private int _enemyCount;

    private bool _isFinishSpawn;

    public bool StopSpawn { get; set; } = false;
    
    public IEnumerator StartEnemyWay()
    {
        while (true)
        {
            if(StopSpawn)
                yield break;
            
            yield return WaysController.Instance.ShowTimer();

            if(StopSpawn)
                yield break;
            
            yield return StartSpawn();

            if(StopSpawn)
                yield break;
            
            while (_enemyCount != 0)
            {
                yield return null;
            }
            
            WaysController.Instance.UpgradeWay();
        }
    }

    private IEnumerator StartSpawn()
    {
        _isFinishSpawn = false;
        var delay = WaysController.Instance.CurrentWay.SpawnDelay;
        var spawnCount = WaysController.Instance.CurrentWay.Count;

        while (spawnCount != 0)
        {
            if(StopSpawn)
                break;
            
            Spawn();
            yield return new WaitForSeconds(delay);
            spawnCount--;
        }
        _isFinishSpawn = true;
    }

    private void Spawn()
    {
        var enemyObj = ObjectPoolController.Instance.GetFromPool(ObjectPoolController.ElementType.SimpleEnemy);
        _enemyCount++;
        WaysController.Instance.EnemyCountText.text = _enemyCount.ToString();
        enemyObj.transform.SetParent(_rootForEnemies);
        enemyObj.transform.position = new Vector3();
        enemyObj.SetActive(true);
        
        var enemy = enemyObj.GetComponent<Enemy>();
        enemy.SetTarget(_targetEnemies);
        enemy.OnDestroyAction = RemoveEnemyCount;
        _enemies.Add(enemy);
    }

    private void RemoveEnemyCount()
    {
        _enemyCount--;
        WaysController.Instance.EnemyCountText.text = _enemyCount.ToString();
    }

    public void DestroyEnemies()
    {
        StopAllCoroutines();
        
        foreach (var enemy in _enemies)
        {
            if(enemy == null)
                continue;
            
            ObjectPoolController.Instance.SetToPool(enemy.gameObject, ObjectPoolController.ElementType.SimpleEnemy);
        }

        _enemyCount = 0;
        WaysController.Instance.EnemyCountText.text = _enemyCount.ToString();
        _enemies.Clear();
    }
}