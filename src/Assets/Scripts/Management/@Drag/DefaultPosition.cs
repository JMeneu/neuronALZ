using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultPosition : MonoBehaviour,IPositionHandler
{
    public void MoveObject(GameObject _object,Vector3 _objectPosition)
    {
        _object.transform.position = _objectPosition;
    }
}
