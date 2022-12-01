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

public class DefaultLogout : MonoBehaviour,ILogoutHandler
{
    public void LogOut(FirebaseAuth _auth)
    {   
        _auth.SignOut();
    }
}
