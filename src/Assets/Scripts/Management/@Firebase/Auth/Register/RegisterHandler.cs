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

public class RegisterHandler:MonoBehaviour
{
    private IRegisterHandler _defaultRegister;
    private IInitHandler _defaultInit;
    private bool _status;
    private void Awake()
    {
        _defaultRegister= GetComponent<DefaultRegister>();
    }

    public IEnumerator Register(string _email, string _password, string _passwordVerify, string _username, FirebaseAuth _auth, Text _positiveFeedback, Text _negativeFeedback)
    {
        yield return _defaultRegister.Register(_email, _password, _passwordVerify,_username,  _auth, _positiveFeedback, _negativeFeedback);
    }
    public bool CheckStatus()
    {
        return _defaultRegister.GetStatus();
    }
}

