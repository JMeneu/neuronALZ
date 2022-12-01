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



public interface IDownloaderHandler
{
    public IEnumerator Download(StorageReference _reference, string _userName,RawImage _rawImage, Texture2D _texture, int _index);
    public IEnumerator DownloadCoroutine(StorageReference _reference, string _userName, RawImage _rawImage, Texture2D _texture, int _index);
    public bool GetStatus();
    public Texture2D GetTexture();
}
