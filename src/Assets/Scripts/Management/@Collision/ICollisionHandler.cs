using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public interface ICollisionHandler
{
    public int Collision(GameObject _otherObject, Collider2D _object);
}
