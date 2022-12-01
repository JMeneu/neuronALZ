/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 9/01/2022
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script describe la lógica modular básica del manejo de paneles en Unity, estableciendo comportamientos
//   estándar (Demo, PopUp, etc) adaptables a tanto juegos como elementos UI genericos.
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PanelModule : MonoBehaviour
{

    private PanelHandler _handler;
    [SerializeField]
    private GameObject[] _objects;
    [SerializeField]
    private GameObject _defaultCanvas;
    [SerializeField]
    private GameObject _demoCanvas;
    [SerializeField]
    private GameObject _demoPreviewCanvas;
    [SerializeField]
    private GameObject _popupCanvas;


    private void Awake()
    {
        _handler= GetComponent<PanelHandler>();
    }
    public void Default()
    {
        _handler.Deactive(_objects);
        _handler.Active(_defaultCanvas, 1);
    }

    public void Demo(int _timeScale)
    {
        _handler.Deactive(_objects);
        _handler.Active(_demoCanvas, _timeScale);
    }
    public void Demo()
    {
        _handler.Deactive(_objects);
        _handler.Active(_demoCanvas, 0);
    }
    public void Demo(GameObject _demo)
    {
        _handler.Deactive(_objects);
        _handler.Active(_demo, 0);
    }

    public void DemoPreview()
    {
        _handler.Deactive(_objects);
        _handler.Active(_demoPreviewCanvas, 0);
    }

    public void DemoPreview(int _timeScale)
    {
        _handler.Deactive(_objects);
        _handler.Active(_demoPreviewCanvas, _timeScale);
    }

    public void PopUp()
    {
        StartCoroutine(PopUpCoroutine(_popupCanvas));
    }

    public void PopUp(GameObject _panelPopup)
    {
        _handler.Active(_panelPopup, 1, 3);
    }

    public IEnumerator PopUpCoroutine(GameObject _panelPopup)
    {
        yield return(_handler.ActiveCoroutine(_panelPopup, 1, 3));
        _handler.Active(_defaultCanvas, 1);
        _handler.Deactive(_objects);

    }
}
