using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class ObjectPoolController : Singleton<ObjectPoolController>
{
    [SerializeField] private PoolElementSetting[] _settings;

    private Dictionary<ElementType, List<GameObject>> _pool = new Dictionary<ElementType, List<GameObject>>();

    private void Awake()
    {
        /*foreach (var elementSetting in _settings)
        {
            for (int i = 0; i < elementSetting.Count; i++)
            {
                AddNewElementInPool(elementSetting.Type, elementSetting.Prefab);
            }
        }*/
    }

    private void AddNewElementInPool(ElementType type, GameObject prefab)
    {
        var entity = Instantiate(prefab, transform);
        entity.SetActive(false);
        if (_pool.ContainsKey(type))
        {
            _pool[type].Add(entity);
        }
        else
        {
            _pool.Add(type, new List<GameObject>() {entity});
        }
    }

    public GameObject GetFromPool(ElementType type)
    {
        /*if(!_pool.ContainsKey(type))
            throw new ArgumentException();
        
        if(_pool[type].Count == 0)
            AddNewElementInPool(type, _settings.First(a => a.Type == type).Prefab);
*/

        //var result = _pool[type][0];

        var result = Instantiate(_settings[0].Prefab, transform);
        //_pool[type].RemoveAt(0);
        return result;
    }
    
    public void SetToPool(GameObject enemy, ElementType simpleEnemy)
    {
        /*enemy.SetActive(false);
        enemy.transform.SetParent(transform);
        if (_pool.ContainsKey(simpleEnemy))
        {
            _pool[simpleEnemy].Add(enemy);
        }
        else
        {
            _pool.Add(simpleEnemy, new List<GameObject>() {enemy});
        }*/
        Destroy(enemy);
    }
    
    [Serializable]
    public struct PoolElementSetting
    {
        public GameObject Prefab;
        public ElementType Type;
        public int Count;
    }

    public enum ElementType
    {
        SimpleEnemy
    }
}