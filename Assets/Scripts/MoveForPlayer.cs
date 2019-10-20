using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    private float _defaultX;
    private float _defaultZ;

    private void Awake()
    {
        _defaultX = transform.position.x;
        _defaultZ = transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(_player.transform.position.x + _defaultX, transform.position.y, _player.transform.position.z + _defaultZ);
    }
}
