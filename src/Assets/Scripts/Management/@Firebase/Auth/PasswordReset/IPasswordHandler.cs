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


    public interface IPasswordHandler
    {
        public IEnumerator SendPasswordResetEmail(string _email, FirebaseAuth _auth,  Text _positiveFeedback, Text _negativeFeedback);
        public bool CheckStatus();
    }
