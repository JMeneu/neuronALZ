/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 9/01/2022
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script describe la lógica modular básica de la descarga de archivos a la plataforma Storage de
// Firebase. Se incluye el servicio RTDB entre otros, pues Storage no permite analizar el contenido ya 
// existente, obligando a la sincronizació0n de dicha información con RTDB para así conocer fielmente 
// el número de imágenes del usuario, no sobreescribir las anteriores.
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
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
using Random=UnityEngine.Random;



public class DownloaderModule : MonoBehaviour
{
    private InitModule _initModule;
    private DownloaderHandler _handler;
    private FilesHandler _filesHandler;
    private PanelModule _panelModule;
    private DatabaseModule _databaseModule;

    [SerializeField]
    private Texture2D _texture;

    [SerializeField]
    private RawImage _rawImage;
    [SerializeField]
    private GameObject _objectOk;
    [SerializeField]
    private GameObject _objectNotOk;
    private bool _status;
    private string _path;
    private int _images;

    private void Awake()
    {
        _initModule= GetComponent<InitModule>();
        _handler= GetComponent<DownloaderHandler>();
        _filesHandler= GetComponent<FilesHandler>();
        _panelModule= GetComponent<PanelModule>();
        _databaseModule= GetComponent<DatabaseModule>();
    }

    public void Download()
    {
        Debug.Log("Downloading...");
        StartCoroutine(DownloadCoroutine());
    }

    public IEnumerator DownloadCoroutine()
    {
        var _auth= _initModule.Auth();
        var _user = _initModule.User();
        var _reference = _initModule.Storage();
        string _userName=_user.DisplayName;
        yield return StartCoroutine(_databaseModule.ReadImagesCoroutine(_userName));
        yield return new WaitForSeconds(1);
        _images= _databaseModule.GetImages();
        Debug.Log(_images);
        int _index= Random.Range(0, _images);
        yield return (_handler.Download( _reference, _userName,_rawImage, _texture, _index));
        //DownloadStatus();
    }
    public void DownloadStatus()
    {
        _status= _handler.CheckStatus();
        if (_status)
        {
            _panelModule.Demo(_objectOk);
        }
        else
        {
            _panelModule.Demo(_objectNotOk);
        }
    }

    public Texture2D GetTexture()
    {
        return _handler.GetTexture();
    }
}
