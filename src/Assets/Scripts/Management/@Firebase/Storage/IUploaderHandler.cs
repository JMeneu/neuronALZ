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


public interface IUploaderHandler
    {
        public IEnumerator Upload (string _path,string _userName, StorageReference _reference,FirebaseUser _user, bool _isProfileImage);
        public IEnumerator Upload (string _path,string _userName, StorageReference _reference,FirebaseUser _user, bool _isProfileImage, int _images);

        public IEnumerator UploadCoroutine(string _path,StorageReference _imagesRef, bool _isProfileImage, int _images);
        public long ReadSize(string _path);
        public bool GetStatus();
        public int GetImages();
    }
