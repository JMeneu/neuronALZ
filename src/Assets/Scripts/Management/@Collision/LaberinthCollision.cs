using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaberinthCollision : MonoBehaviour, ICollisionHandler
{
    public int Collision(GameObject _otherObject, Collider2D _object)
    {
        if (_object.gameObject.tag == "finish")
        {
            return 1;
        }
        else if(_object.gameObject.tag == "Object")
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}