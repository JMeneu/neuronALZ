using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class DefaultPhotoSaver : MonoBehaviour,ICameraHandlerPhotoSaver
{
    public string PhotoSave(byte[] _bytes, GameObject _continue)
    {
        string path = Application.persistentDataPath + "/Profile";
        if ((Directory.Exists(path)) == false)
        {
            Directory.CreateDirectory(path);
        }
        Debug.Log(path);
        File.WriteAllBytes(path + "/profile.png", _bytes);
        Debug.Log("Foto guardada!");
        PhotoSaved(_continue);
        return path;
    }
    public void PhotoSaved(GameObject _continue)
    {
        _continue.SetActive(true);
    }
}
