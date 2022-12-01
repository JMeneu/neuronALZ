using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Analytics;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using Firebase.Storage;
using Firebase.Firestore;
public interface ILoginHandler
{
    public IEnumerator Login(string _email, string _password, FirebaseAuth _auth,  Text _positiveFeedback, Text _negativeFeedback);
    public IEnumerator LoginCoroutine(string _email, string _password, FirebaseAuth _auth, Text _positiveFeedback, Text _negativeFeedback);
    public bool GetStatus();
}
