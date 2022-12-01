/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 9/01/2022
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script describe la lógica modular básica de la carga de archivos a la plataforma Storage de
// Firebase. Se incluye el servicio RTDB entre otros, pues Storage no permite analizar el contenido ya 
// existente, obligando a la sincronizació0n de dicha información con RTDB para así conocer fielmente 
// el número de imágenes del usuario, no sobreescribir las anteriores.
////////////////////////////////////////////////////////////////////////////////////////////////////////

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

public class UploaderModule : MonoBehaviour
{
    private InitModule _initModule;
    private UploaderHandler _handler;
    private FilesModule _filesModule;
    private PanelModule _panelModule;
    private DatabaseModule _databaseModule;
    [SerializeField]
    private GameObject _objectOk;
    [SerializeField]
    private GameObject _objectNotOk;

    [SerializeField]
    private InputField _name;
    [SerializeField]
    private InputField _surname;    
    [SerializeField]
    private InputField _secondsurname;
    [SerializeField]
    private bool _isProfile;
    private string _userName;
    private bool _status;
    public string _path;
    private int _images;

    private void Awake()
    {
        _handler= GetComponent<UploaderHandler>();
        _panelModule= GetComponent<PanelModule>();
        _initModule= GetComponent<InitModule>();
        _filesModule= GetComponent<FilesModule>();
        _databaseModule= GetComponent<DatabaseModule>();
    }
    public void Upload()
    {
        Debug.Log("Uploading...");
        StartCoroutine(UploadCoroutine());
    }

    public IEnumerator UploadCoroutine()
    {
        var _user = _initModule.User();
        var _reference = _initModule.Storage();
        _path= _filesModule.GetImagePath();
        Debug.Log(_path);
        if(_isProfile)
        {
            _userName=_name.text+" "+ _surname.text +" "+ _secondsurname.text;
            yield return (_handler.Upload(_path, _userName, _reference, _user,_isProfile));
        }
        else
        {
            _userName=PanelManager.instance.local_name.text;
            yield return StartCoroutine(_databaseModule.ReadImagesCoroutine(_userName));
            _images = _databaseModule.GetImages();
            yield return (_handler.Upload(_path, _userName, _reference, _user,_isProfile, _images));
            _images++;
            Debug.Log(_images);
            _databaseModule.WriteImagesData(_images, _userName);
        }

        if(!_isProfile)
        {
            UploadStatus();
        }
    }
    public void UploadStatus()
    {
        _status=_handler.CheckStatus();
        if (_status)
        {
            _panelModule.Demo(_objectOk);
            _status=false;
        }
        else
        {
            _panelModule.Demo(_objectNotOk);
            _status=false;
        }
    }

}
