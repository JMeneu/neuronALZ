using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PanelHandler: MonoBehaviour
{

    private IActivateHandler _activate;
    private IDeactivateHandler _deactivate;

    private void Awake()
    {
        _activate= GetComponent<Activate>();
        _deactivate= GetComponent<Deactivate>();

    }

    public void Active(GameObject _object)
    {
        _activate.SetActivate(_object);
    }
    public void Active(GameObject _object, int _timeScale)
    {
        _activate.SetActivate(_object, _timeScale);
    }
    public void Active(GameObject _object,int _timeScale, int _countdown)
    {
        StartCoroutine(ActiveCoroutine(_object, _timeScale, _countdown));
    }
    public IEnumerator ActiveCoroutine(GameObject _object,int _timeScale, int _countdown)
    {
        yield return StartCoroutine(_activate.SetActivate(_object, _timeScale, _countdown));
        Deactive(_object);
    }

    public void Deactive(GameObject[] _objects)
    {
        for (int i = 0; i < _objects.Length; i++)
        {
            _deactivate.SetDeactivate(_objects[i]);
        }
    }

    public void Deactive(GameObject _object)
    {

        _deactivate.SetDeactivate(_object);
    }
}
