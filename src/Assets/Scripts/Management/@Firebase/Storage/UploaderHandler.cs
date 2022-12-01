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



    public class UploaderHandler:MonoBehaviour
    {
        private IUploaderHandler _defaultUpload;

        private void Awake()
        {
            _defaultUpload= GetComponent<DefaultUpload>();
        }
        public IEnumerator Upload(string _path, string _userName,StorageReference _reference,FirebaseUser _user, bool _isProfile)
        {
            yield return _defaultUpload.Upload(_path,_userName, _reference, _user, _isProfile);
        }
        public IEnumerator Upload(string _path, string _userName,StorageReference _reference,FirebaseUser _user, bool _isProfile, int _images)
        {
            yield return _defaultUpload.Upload(_path,_userName, _reference, _user, _isProfile, _images);
        }
        public bool CheckStatus(){
            return _defaultUpload.GetStatus();
        }
        public int GetImages()
        {
            return _defaultUpload.GetImages();
        }
    }
