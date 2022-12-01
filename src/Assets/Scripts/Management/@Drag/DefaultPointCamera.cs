using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefaultPointCamera : MonoBehaviour,ICameraHandler
{
    public Vector3 MoveCamera(Vector3 _inputPosition)
    {
        return (Camera.main.ScreenToWorldPoint(_inputPosition));
    }
}