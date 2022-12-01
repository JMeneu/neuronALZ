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


public class StoreHandler:  MonoBehaviour
{

    private IStoreHandler _defaultStore;

    private void Awake()
    {
        _defaultStore= GetComponent<IStoreHandler>();
    }
    public void WriteGameData(FirebaseUser _user, string _game, string _score)
    {
        _defaultStore.WriteGameData(_user, _game, _score);
    }
    public void WriteRegisterData(string _userName, string _email, string _password, string _role, int _images, string _vision)
    {
        _defaultStore.WriteRegisterData(_userName, _email, _password, _role, _images, _vision);
    }
    public void WriteTestData(string _userName,string _testName, string _result)
    {
        _defaultStore.WriteTestData(_userName,_testName, _result);
    }
}
