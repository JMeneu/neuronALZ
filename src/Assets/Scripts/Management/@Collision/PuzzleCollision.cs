using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleCollision : MonoBehaviour, ICollisionHandler
{
    public int Collision(GameObject _otherObject, Collider2D _object)
    {
        Time.timeScale = 1;
        if (_object.gameObject.tag == _otherObject.gameObject.tag)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
