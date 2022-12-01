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

public interface IStoreHandler
{
    public void WriteGameData(FirebaseUser _user, string _game, string _score);
    public void WriteRegisterData(string _userName, string _email, string _password, string _role, int _images, string _vision);
    public void WriteTestData(string _userName,string _testName, string _result);
}
