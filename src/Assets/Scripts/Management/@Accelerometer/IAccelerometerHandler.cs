using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAccelerometerHandler
{
    public Vector2 SetDirection(Rigidbody2D _rb, Vector2 _direction);
    public void SetVelocity(Rigidbody2D _rb, Vector2 _direction, float _sensibility);
}
