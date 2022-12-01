using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShapesCollision : MonoBehaviour, ICollisionHandler
{

    public int Collision(GameObject _otherObject, Collider2D _object)
    {
        if (_object.gameObject.tag == "Object")
        {
            if (_object.GetComponent<Renderer>().material.GetColor("_Color") == _otherObject.GetComponent<Renderer>().material.GetColor("_Color"))
            {
                _otherObject.gameObject.SetActive(false);
                Destroy(_otherObject.gameObject);
                return 1;
            }
            else
            {
                return 0;
            }

        }
        else
        {
            return 0;
        }

    }
}
