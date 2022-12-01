using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Deactivate : MonoBehaviour, IDeactivateHandler
{
    public void SetDeactivate(GameObject _object)
    {
        _object.SetActive(false);
    }
}
