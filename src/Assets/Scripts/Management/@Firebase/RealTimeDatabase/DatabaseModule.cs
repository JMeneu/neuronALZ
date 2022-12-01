/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 9/01/2022
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script describe la lógica modular básica en el manejo del servicio RTDB, habilitando la 
//   lectura y escritura de una base de datos NoSQL, en formato JSON
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Analytics;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using Firebase.Storage;
using Firebase.Firestore;


public class DatabaseModule : MonoBehaviour
{
    private DatabaseHandler _handler;
    private InitModule _initModule;
    [SerializeField]
    private InputField _usernameRegisterField;
    [SerializeField]
    private InputField _firstsurnameRegisterField;
    [SerializeField]
    private InputField _secondsurnameRegisterField;

    [SerializeField]
    private Text _gameText;

    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _userText;
    [SerializeField]
    private Text _testText;

    [SerializeField]
    private Text _resultsText;
    private string _role;

    private void Awake()
    {
        _handler= GetComponent<DatabaseHandler>();
        _initModule= GetComponent<InitModule>();  
    }
    public void WriteGameData()
    {
        StartCoroutine(WriteGameDataCoroutine());
    }
    public IEnumerator WriteGameDataCoroutine()
    {
        var _auth = _initModule.Auth();
        var _user = _initModule.User();
        var _reference = _initModule.Database();
        yield return _handler.WriteGameData(_gameText, _scoreText,_user, _reference);
    }

    public void WriteImagesData(int _images)
    {
        StartCoroutine(WriteImagesDataCoroutine(_images));
    }
    public IEnumerator WriteImagesDataCoroutine(int _images)
    {
        var _auth = _initModule.Auth();
        var _user = _initModule.User();
        var _reference = _initModule.Database();
        yield return _handler.WriteImages(_images,_user, _reference);
    }
    public void WriteImagesData(int _images, string _userName)
    {
        StartCoroutine(WriteImagesDataCoroutine(_images, _userName));
    }
    public IEnumerator WriteImagesDataCoroutine(int _images, string _userName)
    {
        var _reference = _initModule.Database();
        yield return _handler.WriteImages(_images,_userName, _reference);
    }

    public void WriteRegisterData()
    {
        StartCoroutine(WriteRegisterDataCoroutine());
    }
    public IEnumerator WriteRegisterDataCoroutine()
    {
        var _auth = _initModule.Auth();
        var _reference = _initModule.Database();
        var _userName= _usernameRegisterField.text + " "+ _firstsurnameRegisterField.text + " "+ _secondsurnameRegisterField.text;
        yield return _handler.WriteRegisterData(_userName, _role, 0, _reference);
    }

    public void WriteTestData(string _userName, string _testName, string _results)
    {
        StartCoroutine(WriteTestDataCoroutine(_userName, _testName, _results));
    }
    public IEnumerator WriteTestDataCoroutine(string _userName, string _testName, string _results)
    {
        var _auth = _initModule.Auth();
        var _reference = _initModule.Database();
        yield return _handler.WriteTestData(_userName, _testName, _results, _reference);
    }

    public void ReadLoginData()
    {
        StartCoroutine(ReadLoginDataCoroutine());
    }
    public IEnumerator ReadLoginDataCoroutine()
    {
        var _user = _initModule.User();
        yield return _handler.ReadLoginData(_user);
    }
    public void ReadUploadData()
    {
        StartCoroutine(ReadUploadDataCoroutine());
    }

    public IEnumerator ReadUploadDataCoroutine()
    {
        var _user = _initModule.User();
        yield return _handler.ReadUploadData(_user);
    }

    public void ReadPatientUploadData()
    {
        StartCoroutine(ReadPatientUploadDataCoroutine());
    }

    public IEnumerator ReadPatientUploadDataCoroutine()
    {
        var _userName = _userText.text;
        yield return _handler.ReadUploadData(_userName);
    }
    public void ReadUsersTotalAmount()
    {
        StartCoroutine(ReadUsersTotalAmountCoroutine());
    }

    
    public IEnumerator ReadUsersTotalAmountCoroutine()
    {
        yield return _handler.ReadUsersTotalAmount();
    }

    public void ReadImages(string _userName)
    {
        StartCoroutine(ReadImagesCoroutine(_userName));
    }

    
    public IEnumerator ReadImagesCoroutine(string _userName)
    {
        yield return _handler.ReadImages(_userName);
    }

    public void ReadImages()
    {
        StartCoroutine(ReadImagesCoroutine());
    }

    
    public IEnumerator ReadImagesCoroutine()
    {
        var _user = _initModule.User();
        yield return _handler.ReadImages(_user);
    }

    public void OnClickRole(bool _patient)
    {
        if(_patient)
        {
            _role="Paciente";
        }
        else
        {
            _role="Terapeuta";
        }
    }
    public bool GetRole(){
        return _handler.GetRole();
    }
    public string GetPalette()
    {
        return _handler.GetPalette();
    }
    public int GetImages()
    {
        return _handler.GetImages();
    }
    public List<string> GetList()
    {
        return _handler.GetList();
    }
}
