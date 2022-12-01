using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActivateHandler
{
    public void SetActivate(GameObject _object);
    public void SetActivate(GameObject _object, int _timeScale);
    public IEnumerator SetActivate(GameObject _object, int _timeScale, int _countdown);
    public IEnumerator ActiveCoroutine(GameObject _object,int _timeScale, int _countdown);
}
