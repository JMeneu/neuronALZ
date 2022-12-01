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


public class DownloaderHandler: MonoBehaviour
{
    private IDownloaderHandler _defaultDownload;

    private void Awake()
    {
        _defaultDownload= GetComponent<DefaultDownload>();
    }
    public IEnumerator Download(StorageReference _reference,string _userName, RawImage _rawImage, Texture2D _texture, int _index)
    {
        yield return _defaultDownload.Download(_reference, _userName, _rawImage, _texture, _index);
    }

    public bool CheckStatus()
    {
        return _defaultDownload.GetStatus();
    }
    public Texture2D GetTexture()
    {
        return _defaultDownload.GetTexture();
    }
}
