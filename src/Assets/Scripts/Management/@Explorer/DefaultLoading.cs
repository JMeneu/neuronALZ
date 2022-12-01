using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using NativeFilePickerNamespace;


public class DefaultLoading : MonoBehaviour,IFileLoading
{
    public RawImage LoadFile(string _path, RawImage _rawImage)
    {
        StartCoroutine(Load(_path, _rawImage));
        return _rawImage;
    }
    public IEnumerator Load(string _path, RawImage _rawImage)
    {
        var url = "file://" + _path;
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url))
        {
            yield return uwr.SendWebRequest();
            if (uwr.result == UnityWebRequest.Result.ProtocolError || uwr.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                var uwrTexture = DownloadHandlerTexture.GetContent(uwr);
                _rawImage.texture = uwrTexture;
                _rawImage.uvRect = new Rect(0, 0, 1, 1);
            }
        }
    }
}
