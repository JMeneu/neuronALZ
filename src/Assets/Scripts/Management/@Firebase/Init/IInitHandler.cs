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
public interface IInitHandler
{
    public FirebaseAuth InitAuth();
    public FirebaseUser InitUser();
    public void InitAnalytics();
    public DatabaseReference InitRealTimeDatabase();
    public StorageReference InitStorage();
    public FirebaseFirestore InitStore();
}
