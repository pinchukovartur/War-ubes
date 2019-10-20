
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
   [SerializeField]
   private Enemy _enemyPrefab;

   [SerializeField]
   private Transform _rootForEnemies;

   [SerializeField]
   private float _spawnTime;

   [SerializeField]
   private GameObject _targetEnemies;
   
   
   private float _currentTime;

   private void FixedUpdate()
   {
      if (IsTimeSpawn())
      {
         Spawn();
      }
   }

   private bool IsTimeSpawn()
   {
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
   }
}
