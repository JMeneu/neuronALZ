using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DefaultRenderingInput : MonoBehaviour, IInputRenderingHandler
{
    public int ReadInput(GameObject _index)
    {
        return (int.Parse(_index.GetComponent<UnityEngine.UI.Text>().text) - 1);
    }
    public int ReadInput(Vector3 _direction)
    {
        if (_direction.x >0)
        {
            return 0;
        }
        else if (_direction.x <0)
        {
            return 1;
        }

        else if (_direction.y > 0)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }
}
