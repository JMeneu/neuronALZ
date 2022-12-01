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

public interface IRegisterHandler
{
    public  IEnumerator Register(string _email, string _password, string _passwordVerify,string _username,  FirebaseAuth _auth, Text _positiveFeedback, Text _negativeFeedback);
    public IEnumerator RegisterCoroutine(string _email, string _password, string _passwordVerify, string _username, FirebaseAuth _auth,Text _positiveFeedback, Text _negativeFeedback);
    public bool GetStatus();
}
