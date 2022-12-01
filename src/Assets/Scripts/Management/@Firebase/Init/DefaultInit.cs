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


public class DefaultInit : MonoBehaviour, IInitHandler
{
    private FirebaseAuth _authReference;
    private FirebaseUser _user;
    private FirebaseFirestore _storeReference;
    private DatabaseReference _databaseReference;
    private StorageReference _storageReference;

    public FirebaseAuth InitAuth()
    {
        _authReference = FirebaseAuth.DefaultInstance;
        return _authReference;
    }
    public FirebaseUser InitUser()
    {
        _user = _authReference.CurrentUser;
        return _user;
    }
    public void InitAnalytics()
    {
        var app = FirebaseApp.DefaultInstance;
        FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
    }
    public FirebaseFirestore InitStore()
    {
        _storeReference = FirebaseFirestore.DefaultInstance;
        return _storeReference;
    }
    public DatabaseReference InitRealTimeDatabase()
    {
        _databaseReference= Firebase.Database.FirebaseDatabase.DefaultInstance.RootReference;
        return _databaseReference;
    }
    public StorageReference InitStorage()
    {
        FirebaseStorage storage = FirebaseStorage.DefaultInstance;
        _storageReference= storage.GetReferenceFromUrl("gs://neuronalz-beta-cd43e.appspot.com");
        return _storageReference;
    }

}
