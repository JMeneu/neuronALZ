using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Storage;
using Firebase.Extensions;


public class DefaultUpload : MonoBehaviour, IUploaderHandler
{
    private bool _isOk;
    private int _userImages;
    public IEnumerator Upload(string _path,string _userName, StorageReference _reference, FirebaseUser _user, bool _isProfileImage)
    {
        _isOk=false;
        Debug.Log(_path);
        StorageReference _usersRef = _reference.Child("UserUploads");
        var fileSize = ReadSize(_path);
        if(fileSize> 5000000000)
        {
            _isOk = false;
        }
        else
        {
            StorageReference _rootRef = _usersRef.Child(_userName);
            StorageReference _userRef = _rootRef.Child("Profile");
            StorageReference _typeRef = _userRef.Child("profilePic");
            StorageReference _imagesRef = _typeRef.Child("ProfileImage");
            yield return StartCoroutine(UploadCoroutine(_path, _imagesRef, _isProfileImage, 0));
        }
    }

    public IEnumerator Upload(string _path,string _userName, StorageReference _reference, FirebaseUser _user, bool _isProfileImage, int _images)
    {
        _isOk=false;
        _userImages=_images;
        Debug.Log(_path);
        StorageReference _usersRef = _reference.Child("UserUploads");
        var fileSize = ReadSize(_path);
        if(fileSize> 5000000000)
        {
            _isOk = false;
        }
        else
        {
            StorageReference _rootRef = _usersRef.Child(_userName);
            StorageReference _userRef = _rootRef.Child("Game");
            StorageReference _typeRef = _userRef.Child("gamePic");
            StorageReference _imagesRef = _typeRef.Child("GameImage_"+ _images.ToString());
            yield return StartCoroutine(UploadCoroutine(_path, _imagesRef, _isProfileImage, _images));
        }
    }

    public IEnumerator UploadCoroutine(string _path,StorageReference _imagesRef, bool _isProfileImage, int _images)
    {
        _isOk = false;
        var new_metadata = new Firebase.Storage.MetadataChange();
        new_metadata.ContentType = "image/png";
        _path = "file://" + _path;
        var uploadTask = _imagesRef.PutFileAsync(_path, new_metadata, null, CancellationToken.None, null);
        yield return new WaitUntil(predicate: () => uploadTask.IsCompleted);
        if (uploadTask.Exception != null)
        {
            Debug.LogWarning(message: $"Fallo al registar tarea con {uploadTask.Exception}");
            Debug.Log("Subida fallida!");
            _isOk = false;
        }
        else
        {
            if(!_isProfileImage)
            {
                ++_images;
                _userImages=_images;
            }
            Debug.Log("Subida correcta!");
            _isOk = true;
        }

    }
    public long ReadSize(string _path)
    {
        FileInfo fi = new FileInfo(_path);
        long size = fi.Length;
        return size;
    }
    public bool GetStatus()
    {
        return _isOk;
    }
    public int GetImages()
    {
        return _userImages;
    }

}
