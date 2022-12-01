using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public interface IInputRenderingHandler
{
    public int ReadInput(GameObject _index);
    public int ReadInput(Vector3 _direction);
}
