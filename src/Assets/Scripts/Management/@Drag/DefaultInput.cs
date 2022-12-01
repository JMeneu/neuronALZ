using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefaultInput : MonoBehaviour,IInputHandler
{
    public Vector3 ReadInput()
    {
        return (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
    }
}
