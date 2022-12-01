using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Analytics;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using Firebase.Storage;
using Firebase.Firestore;


public class DatabaseHandler:MonoBehaviour
{
    private IDatabaseHandler _defaultDatabase;

    private void Awake()
    {
        _defaultDatabase= GetComponent<IDatabaseHandler>();
    }
    public IEnumerator WriteGameData(Text _gameText, Text _scoreText, FirebaseUser _user, DatabaseReference _reference)
    {
        var _game = _gameText.text;
        var _score = _scoreText.text;
        yield return _defaultDatabase.WriteGameData(_game, _score, _user, _reference);
    }
    
    public IEnumerator WriteImages(int _images, FirebaseUser _user, DatabaseReference _reference)
    {
        yield return _defaultDatabase.WriteImages(_images,_user, _reference);
    }

    public IEnumerator WriteImages(int _images, string _userName, DatabaseReference _reference)
    {
        yield return _defaultDatabase.WriteImages(_images,_userName, _reference);
    }
    
    public IEnumerator WriteRegisterData(string _userName, string _role, int _images, DatabaseReference _reference)
    {
        yield return _defaultDatabase.WriteRegisterData(_userName, _role, 0, _reference);
    }
    public IEnumerator WriteTestData(string _userName, string _testName, string _results, DatabaseReference _reference)
    {
        yield return _defaultDatabase.WriteTestData(_userName, _testName, _results, _reference);
    }
    public IEnumerator ReadLoginData(FirebaseUser _user) 
    {
        yield return _defaultDatabase.ReadLoginData(_user);
    }
    public IEnumerator ReadUploadData(FirebaseUser _user) 
    {
        yield return _defaultDatabase.ReadUploadData(_user);
    }
    public IEnumerator ReadUploadData(string _userName) 
    {
        yield return _defaultDatabase.ReadUploadData(_userName);
    }
    public IEnumerator ReadUsersTotalAmount() 
    {
        yield return _defaultDatabase.ReadUsersTotalAmount();
    }
    public IEnumerator ReadImages(FirebaseUser _user)
    {
        yield return _defaultDatabase.ReadImages(_user);
    }
    public IEnumerator ReadImages(string _userName)
    {
        yield return _defaultDatabase.ReadImages(_userName);
    }
    public bool GetRole()
    {
        return _defaultDatabase.GetRole();
    }
    public string GetPalette()
    {
        return _defaultDatabase.GetPalette();
    }
    public int GetImages()
    {
        return _defaultDatabase.GetImages();
    }
    public List<string> GetList()
    {
        return _defaultDatabase.GetList();
    }
}
