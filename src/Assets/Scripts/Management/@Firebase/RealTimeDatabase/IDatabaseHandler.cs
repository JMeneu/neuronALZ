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


public interface IDatabaseHandler
{
    public IEnumerator WriteRegisterData(string _user,string _role, int _images, DatabaseReference _reference);
    public IEnumerator WriteGameData(string _game, string _score, FirebaseUser _user, DatabaseReference _reference);
    public IEnumerator WriteTestData(string _userName, string _testName, string _results, DatabaseReference _reference);
    public IEnumerator ReadLoginData(FirebaseUser _user);
    public IEnumerator ReadUploadData(FirebaseUser _user);
    public IEnumerator ReadUploadData(string _userName);
    public IEnumerator ReadUsersTotalAmount();
    public bool GetRole();    
    public string GetPalette();
    public int GetImages();
    public List<string> GetList();    
    public IEnumerator WriteRegister(string _user,string _role, int _images, DatabaseReference _reference);
    public IEnumerator WriteGame(string _game, FirebaseUser _user, DatabaseReference _reference);
    public IEnumerator WriteScore(string _score, FirebaseUser _user, DatabaseReference _reference);
    public IEnumerator WriteImages(int _images, FirebaseUser _user, DatabaseReference _reference);
    public IEnumerator WriteImages(int _images, string _userName, DatabaseReference _reference);
    public IEnumerator WriteTest(string _userName, string _testName, string _results,DatabaseReference _reference);
    public IEnumerator ReadRole(FirebaseUser _user);
    public IEnumerator ReadColor(FirebaseUser _user);
    public IEnumerator ReadImages(FirebaseUser _user);
    public IEnumerator ReadImages(string _userName);
    public IEnumerator ReadUsers();
}
