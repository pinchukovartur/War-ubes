using System;
using TMPro;
using UnityEngine;

public class PortalItem : MonoBehaviour
{
    [SerializeField]
    private int _resetTime;
    
    [SerializeField] private TextMeshPro _timerText;

    [SerializeField] private Type _type;
    [SerializeField] private Type _outPortal;

    private bool _isPortalActivate;
    private float _currentTime;
    private int _lastTextValue;
    
    private void Awake()
    {
        _timerText.text = string.Empty;
        _currentTime = _resetTime;
    }

    public void ActivatePortal()
    {
        _isPortalActivate = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(_isPortalActivate)
            return;
        
        if (collision.collider.CompareTag("Player"))
        {
            _isPortalActivate = true;
            PortalController.Instance.EntryPortal(_type, _outPortal);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(_isPortalActivate)
            return;
        
        if (collision.collider.CompareTag("Player"))
        {
            _isPortalActivate = true;
            PortalController.Instance.EntryPortal(_type, _outPortal);
        }
    }

    private void FixedUpdate()
    {
        if(!_isPortalActivate)
            return;

        _currentTime -= Time.deltaTime;
        var textValue = (int) _currentTime;
        
        if (textValue != _lastTextValue)
        {
            _lastTextValue = textValue;
            _timerText.text = _lastTextValue.ToString();
        }
        
        if(_currentTime > 1)
            return;

        _currentTime = _resetTime;
        _isPortalActivate = false;
        _timerText.text = string.Empty;
        _lastTextValue = -1;
    }

    public enum Type
    {
        PlayerBase,
        EnemyBase
    }
}