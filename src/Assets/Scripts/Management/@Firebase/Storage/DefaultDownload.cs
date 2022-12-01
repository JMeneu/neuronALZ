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


public class DefaultDownload : MonoBehaviour, IDownloaderHandler
{
    private bool _isOk;
    private Texture2D _tex;
    public IEnumerator Download(StorageReference _reference, string _userName, RawImage _rawImage, Texture2D _texture, int _index)
    {
        yield return StartCoroutine(DownloadCoroutine(_reference, _userName, _rawImage, _texture, _index));
    }

    public IEnumerator DownloadCoroutine(StorageReference _reference, string _userName, RawImage _rawImage, Texture2D _texture, int _index)
    {
        Debug.Log("UserUploads/" + _userName + "/Game/gamePic/GameImage_"+_index.ToString());
        var _pathReference = FirebaseStorage.DefaultInstance.GetReference("UserUploads/" + _userName + "/Game/gamePic/GameImage_"+_index.ToString());
        var downloadTask = _pathReference.GetBytesAsync(long.MaxValue);
        yield return new WaitUntil(predicate: () => downloadTask.IsCompleted);
        if (downloadTask.Exception != null)
        {
            Debug.LogWarning(message: $"Fallo al registar tarea con {downloadTask.Exception}");
            _isOk = false;
        }
        else
        {
            _texture = new Texture2D(2, 2);
            _texture.LoadImage(downloadTask.Result);
            _tex=_texture;
            _rawImage.texture = _texture;
            _isOk = true;
        }
    }

    public bool GetStatus()
    {
        return _isOk;
    }
    public Texture2D GetTexture()
    {
        return _tex;
    }

}
