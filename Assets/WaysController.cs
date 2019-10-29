using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaysController : Singleton<WaysController>
{
    [SerializeField] private Text _wayNumberText;
    [SerializeField] private Text _wayTimerText;
    [SerializeField] private Text _enemyCountText;

    [SerializeField] private EnemyWay[] _ways;


    private int _currentWayIndex;
    private bool _showWayTimer;
    private float _currentTime;
    private int _lastTimerValue;

    public Text EnemyCountText => _enemyCountText;

    public EnemyWay CurrentWay
    {
        get
        {
            if (_ways == null || _ways.Length == 0)
                throw new ArgumentException();

            return _ways[_currentWayIndex];
        }
    }

    private void Awake()
    {
        _wayNumberText.text = $"WAVE: {_currentWayIndex + 1}";
    }

    public void UpgradeWay()
    {
        if (_ways.Length - 1 <= _currentWayIndex)
            return;

        _currentWayIndex++;
        _wayNumberText.text = $"WAVE: {_currentWayIndex + 1}";
    }

    public IEnumerator ShowTimer()
    {
        var way = CurrentWay;
        var currentVal = way.StartWayDelay;

        while (currentVal != 0)
        {
            _wayTimerText.text = $"Next way: {(currentVal)}";
            yield return new WaitForSeconds(1);
            currentVal--;
        }
        
        _wayTimerText.text = string.Empty;
    }

    [Serializable]
    public class EnemyWay
    {
        [SerializeField] public EnemyType Type;
        [SerializeField] public int Count;
        [SerializeField] public float SpawnDelay;
        [SerializeField] public int StartWayDelay;
    }

    public enum EnemyType
    {
        Simple
    }

    public void ResetWays()
    {
        _currentWayIndex = 0;
        _wayNumberText.text = $"WAVE: {_currentWayIndex + 1}";
    }
}