/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 9/01/2022
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script describe la lógica modular básica del inicio de sesión en Firebase. Incluye la conexión con
// otros módulos, como RTDB o PanelModule, con el objetivo de aportar la funcionalidad completa al servicio.
//  Las corrutinas permiten un control exacto del flujo de ejecución, habilitando una ejecución ordenada.
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Analytics;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using Firebase.Storage;
using Firebase.Firestore;

public class LoginModule : MonoBehaviour
{
    private LoginHandler _handler;
    private PanelModule _panelModule;
    private InitModule _initModule;
    
    private DatabaseModule _databaseModule;
    private SceneModule _sceneModule;

    private ColorBlindnessAdapter _colorModule;
    [SerializeField]
    private InputField _email;
    [SerializeField]
    private InputField _password;
    [SerializeField]
    private GameObject _objectOk;
    [SerializeField]
    private GameObject _objectNotOk;
    [SerializeField]
    private Text _positiveFeedback;
    [SerializeField]
    private Text _negativeFeedback;

    [SerializeField]
    private bool _status;

    private void Awake()
    {
        _handler= GetComponent<LoginHandler>();
        _panelModule= GetComponent<PanelModule>();
        _initModule= GetComponent<InitModule>();
        _sceneModule= GetComponent<SceneModule>();
        _databaseModule= GetComponent<DatabaseModule>();
        _colorModule= GetComponent<ColorBlindnessAdapter>();
        _colorModule.ReadVision("Normal");
    }
    public void Login()
    {
        StartCoroutine(LoginCoroutine());
    }

    public IEnumerator LoginCoroutine()
    {
        var _auth = _initModule.Auth();
        yield return(_handler.Login(_email.text, _password.text, _auth, _positiveFeedback, _negativeFeedback));
        StartCoroutine(LoginStatus());
    }
    public IEnumerator LoginStatus()
    {
        _status=_handler.CheckStatus();
        if (_status)
        {
            yield return _databaseModule.ReadLoginDataCoroutine();
            yield return(_panelModule.PopUpCoroutine(_objectOk));
            if(_databaseModule.GetRole())
            {
                _colorModule.ReadVision(_databaseModule.GetPalette());
                Debug.Log(_databaseModule.GetPalette());
                _sceneModule.Load("Session_Mode");
            }
            else
            {
                _colorModule.ReadVision(_databaseModule.GetPalette());
                Debug.Log(_databaseModule.GetPalette());
                _sceneModule.Load("MenuTerapeuta");
            }
        }
        else
        {
            yield return(_panelModule.PopUpCoroutine(_objectNotOk));
        }
        _status=false;
    }

}
