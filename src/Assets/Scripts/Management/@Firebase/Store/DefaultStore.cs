using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Analytics;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using Firebase.Storage;
using Firebase.Firestore;


public class DefaultStore : MonoBehaviour, IStoreHandler
{

    [FirestoreData]
    public struct GameData
    {
        [FirestoreProperty]
        public string Game { get; set; }

        [FirestoreProperty]
        public string Score { get; set; }

        [FirestoreProperty]
        public string Date { get; set; }

    }
    [FirestoreData]
    public struct UserData
    {
        [FirestoreProperty]
        public string Name { get; set; }

        [FirestoreProperty]
        public string Email { get; set; }

        [FirestoreProperty]
        public string Password { get; set; }

        [FirestoreProperty]
        public string Role { get; set; }

        [FirestoreProperty]
        public int Images { get; set; }
        
        [FirestoreProperty]
        public string TestVisual { get; set; }
        [FirestoreProperty]
        public string Test { get; set; }
        [FirestoreProperty]
        public string Result { get; set; }
    }

    public void WriteGameData(FirebaseUser _user, string _game, string _score)
    {
            var _userPath = "Puntuaciones/" + _user.DisplayName + "/Data/" + DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            var _userData = new GameData
            {
                Game = _game,
                Score = _score,
                Date = (DateTime.Now.ToString("yyyy-MM-dd HH:mm"))
            };
            var _firestore = FirebaseFirestore.DefaultInstance;
            _firestore.Document(_userPath).SetAsync(_userData);
    }

    public void WriteRegisterData(string _userName, string _email, string _password, string _role, int _images, string _vision)
    {
        var _userPath = "Datos/" + _userName;
        var _userData = new UserData
        {
            Name = _userName,
            Email = _email,
            Password = _password,
            Role = _role,
            Images = _images,
            TestVisual= _vision
        };
        var _firestore = FirebaseFirestore.DefaultInstance;
        _firestore.Document(_userPath).SetAsync(_userData);
    }

    public void WriteTestData(string _userName,string _testName, string _result)
    {
        var _userPath = "Datos/" + _userName;
        var _userData = new UserData
        {
            Test= _testName,
            Result=_result
        };
        var _firestore = FirebaseFirestore.DefaultInstance;
        _firestore.Document(_userPath).SetAsync(_userData);
    }
}
