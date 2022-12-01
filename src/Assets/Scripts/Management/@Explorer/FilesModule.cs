/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 9/01/2022
// # Credits: Unity Documentation, Unity Answers, NativeFilePicker
// # Definition:
//   Este script describe la lógica modular básica de la administración de archivos, empleando el paquete
//   NativeFilePicker. Este módulo permite explorar archivos y obtener su directorio.
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using NativeFilePickerNamespace;


public class FilesModule : MonoBehaviour
{
    private FilesHandler _fileHandler;
    private CameraModule _cameraModule;

    [SerializeField]
    public RawImage _rawImage;
    [SerializeField]
    private RectTransform _rt;
    public static string _path;
    private void Awake()
    {
        _fileHandler = GetComponent<FilesHandler>();
    }

    public void SelectImage()
    {
        _path = _fileHandler.GetImagePath(_path);
        _rawImage=_fileHandler.TextureFit(_rawImage, _rt);
        _rawImage=_fileHandler.TextureLoad(_path, _rawImage);
    }

    public string GetImagePath()
    {
        return _path;
    }
    public void ChangePath()
    {
        _cameraModule = GetComponent<CameraModule>();
        _path=_cameraModule.GetPath() + "/profile.png";
    }
}
