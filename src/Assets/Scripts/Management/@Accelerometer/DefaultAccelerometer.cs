using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefaultAccelerometer : MonoBehaviour, IAccelerometerHandler
{
    public Vector2 SetDirection(Rigidbody2D _rb, Vector2 _direction)
    {
        _direction = new Vector2(Input.acceleration.x, Input.acceleration.y);
        if (_direction.sqrMagnitude > 1)
        {
            _direction.Normalize();
        }
        _direction *= Time.deltaTime;
        return _direction;
    }

    public void SetVelocity(Rigidbody2D _rb, Vector2 _direction, float _sensibility)
    {
        _rb.velocity = (_direction * _sensibility);
    }
}
