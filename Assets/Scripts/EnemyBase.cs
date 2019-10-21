using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : Singleton<EnemyBase>
{
   [SerializeField]
   private Enemy _enemyPrefab;

   [SerializeField]
   private Transform _rootForEnemies;

   [SerializeField]
   private float _spawnTime;

   [SerializeField]
   private GameObject _targetEnemies;

   [SerializeField]
   private bool _isStopSpawn;
   
   private float _currentTime;
   
   private List<Enemy> _enemies = new List<Enemy>();

   private void FixedUpdate()
   {
      if (IsTimeSpawn())
      {
         Spawn();
      }
   }

   private bool IsTimeSpawn()
   {
      if (_isStopSpawn)
         return false;
      
      _currentTime += Time.deltaTime;
      if(_currentTime < _spawnTime)
         return false;

      _currentTime = 0;
      return true;
   }
   
   private void Spawn()
   {
      var enemy = Instantiate(_enemyPrefab, _rootForEnemies);
      enemy.SetTarget(_targetEnemies);
      _enemies.Add(enemy);
   }

   public void StopSpawn()
   {
      _isStopSpawn = true;
   }

   public void DestroyEnemies()
   {
      foreach (var enemy in _enemies)
      {
         if(enemy != null)
            Destroy(enemy.gameObject);
      }
      _enemies.Clear();
   }

   public void StartSpawn()
   {
      _isStopSpawn = false;
   }
}
