/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 9/01/2022
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script describe la lógica modular básica del registro de nuevos usuarios en la plataforma. Ello 
//   obliga la implementación de servicios auxiliares como Store, Storage o RTDB, además del convencional
//   Panel.
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Analytics;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using Firebase.Storage;

public class RegisterModule : MonoBehaviour
{
    private RegisterHandler _handler;
    private PanelModule _panelModule;
    private InitModule _initModule;
    private SceneModule _sceneModule;
    private bool _status;

    [SerializeField]
    private InputField _usernameRegisterField;
    [SerializeField]
    private InputField _firstsurnameRegisterField;
    [SerializeField]
    private InputField _secondsurnameRegisterField;
    [SerializeField]
    private InputField _email;
    [SerializeField]
    private InputField _password;
    [SerializeField]
    private InputField _passwordVerify;
    [SerializeField]
    private GameObject _objectOk;
    [SerializeField]
    private GameObject _objectNotOk;
    [SerializeField]
    private Text _positiveFeedback;
    [SerializeField]
    private Text _negativeFeedback;

    private void Awake()
    {
        _handler= GetComponent<RegisterHandler>();
        _panelModule= GetComponent<PanelModule>();
        _initModule= GetComponent<InitModule>();
        _sceneModule= GetComponent<SceneModule>();
    }

    public void Register()
    {
        StartCoroutine(RegisterCoroutine());
    }

    public IEnumerator RegisterCoroutine()
    {
        var _auth = _initModule.Auth();
        string _username=_usernameRegisterField.text+ " " + _firstsurnameRegisterField.text + " " +_secondsurnameRegisterField.text;
        yield return(_handler.Register(_email.text, _password.text, _passwordVerify.text, _username, _auth, _positiveFeedback,_negativeFeedback));
        _status=_handler.CheckStatus();
        StartCoroutine(RegisterStatus());
    }
    public IEnumerator RegisterStatus()
    {
        if (_status)
        {
            yield return(_panelModule.PopUpCoroutine(_objectOk));
            _sceneModule.Load("Login");
        }
        else
        {
            yield return(_panelModule.PopUpCoroutine(_objectNotOk));
        }
    }
}
