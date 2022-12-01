using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public interface ICameraHandlerPhotoSaver
{
    public string PhotoSave(byte[] bytes, GameObject _continue);
    public void PhotoSaved(GameObject _continue);
}
