/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 9/01/2022
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script describe la lógica modular básica de la recuperación de credenciales de Firebase.
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
using Firebase.Firestore;


public class PasswordModule : MonoBehaviour
{
    private IPasswordHandler _defaultPassword;
    private InitModule _initModule;
    private PanelModule _panelModule;
    [SerializeField]
    private InputField _emailField;
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
        _defaultPassword= GetComponent<DefaultPassword>();
        _initModule= GetComponent<InitModule>();
        _panelModule= GetComponent<PanelModule>();
    }
    public void Reset()
    {
        StartCoroutine(ResetCoroutine());
    }
    public IEnumerator ResetCoroutine()
    {
        string _email = _emailField.text;
        var _auth = _initModule.Auth();
        yield return _defaultPassword.SendPasswordResetEmail(_email, _auth, _positiveFeedback, _negativeFeedback);
        ResetStatus();
    }
    public void ResetStatus()
    {
        _status=_defaultPassword.CheckStatus();
        if (_status)
        {
            _panelModule.PopUp(_objectOk);
        }
        else
        {
            _panelModule.PopUp(_objectNotOk);
        }
        _status=false;
    }

}
