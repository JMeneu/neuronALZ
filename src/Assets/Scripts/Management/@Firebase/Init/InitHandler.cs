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


public class InitHandler:MonoBehaviour
{
    private IInitHandler _defaultInit;

    private void Awake()
    {
        _defaultInit= GetComponent<DefaultInit>();
    }

    public FirebaseAuth Auth()
    {
        return _defaultInit.InitAuth();
    }
    public FirebaseUser User()
    {
        return _defaultInit.InitUser();
    }
    public void Analytics()
    {
        _defaultInit.InitAnalytics();
    }
    public FirebaseFirestore Store()
    {
        return _defaultInit.InitStore();
    }
    public DatabaseReference Database()
    {
        return _defaultInit.InitRealTimeDatabase();
    }
    public StorageReference Storage()
    {

        return _defaultInit.InitStorage();
    }
}
