using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(_player.transform.position.x - 6, transform.position.y, _player.transform.position.z - 3);
    }
}
