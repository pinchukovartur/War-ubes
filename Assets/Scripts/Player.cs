using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Joystick _joystick;

    [SerializeField, Range(1, 10)]
    private float _speed;
    
    // Update is called once per frame
    void FixedUpdate ()
    {
        /*if (Input.GetKey("up"))
        {
            transform.Translate(0f, 0f, Time.deltaTime * _speed);
        }

        if (Input.GetKey("down"))
        {
            transform.Translate(0f, 0f, Time.deltaTime * _speed * -1);
        }
        
        if (Input.GetKey("right"))
        {
            transform.Rotate(0f, Time.deltaTime * _speed * 55, 0f);
        }
        
        if (Input.GetKey("left"))
        {
            transform.Rotate(0f, Time.deltaTime * _speed * -1 * 55, 0f);
        }*/

        
        
        
        var rg = GetComponent<Rigidbody>();
        
        rg.velocity = new Vector3(_joystick.Horizontal * _speed, rg.velocity.y, _joystick.Vertical * _speed);
        
        return;
        
        if (Input.GetKey("up"))
        {
            rg.AddForce(new Vector2(13.0f, 0));
        }

        if (Input.GetKey("down"))
        {
            rg.AddForce(new Vector2(-13.0f, 0));
        }
        
        if (Input.GetKey("right"))
        {
            rg.AddForce(new Vector3(0, 0, -13.0f));
        }
        
        if (Input.GetKey("left"))
        {
            rg.AddForce(new Vector3(0, 0, 13.0f));
        }
    }
}