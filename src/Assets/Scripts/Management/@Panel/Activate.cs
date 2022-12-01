using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Activate : MonoBehaviour, IActivateHandler
{
    public void SetActivate(GameObject _object)
    {
        _object.SetActive(true);
    }
    public void SetActivate(GameObject _object, int _timeScale)
    {
        _object.SetActive(true);
        Time.timeScale = _timeScale;

    }
    public IEnumerator SetActivate(GameObject _object, int _timeScale, int _countdown)
    {
        yield return StartCoroutine(ActiveCoroutine(_object, _timeScale, _countdown));

    }
    public IEnumerator ActiveCoroutine(GameObject _object,int _timeScale, int _countdown)
    {
        _object.SetActive(true);
        Time.timeScale = _timeScale;
        yield return new WaitForSeconds(_countdown);
    }
}
