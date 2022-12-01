/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 9/01/2022
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script describe la lógica modular básica del cierre de sesión de Firebase.
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


public class LogoutModule : MonoBehaviour
{
    private ILogoutHandler _defaultLogout;
    private InitModule _initModule;
    
    private void Awake()
    {
        _defaultLogout= GetComponent<DefaultLogout>();
        _initModule= GetComponent<InitModule>();
    }

    public void LogOut()
    {
        var _auth = _initModule.Auth();
        _defaultLogout.LogOut(_auth);
    }
    
}
