/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 9/01/2022
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script describe la lógica modular básica de la escritura de datos en registro y en juegos, 
//   sobre la base de datos NoSQL aportada por Store, siendo en este caso, almacenada en documentos y colecciones.
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


public class StoreModule : MonoBehaviour
{
    private StoreHandler _handler;
    private InitModule _initModule;
    [SerializeField]
    private Text _gameName;
    [SerializeField]
    private Text _scoreValue;

    [SerializeField]
    private InputField _name;
    [SerializeField]
    private InputField _userSurname;
    [SerializeField]
    private InputField _userSecondSurname;
    [SerializeField]
    private InputField _userEmail;
    [SerializeField]
    private InputField _userPassword;
    [SerializeField]
    private Text _userNameText;
    [SerializeField]
    private Text _testNameText; 
    [SerializeField]
    private Text _resultText;

    private string _role;
    private void Awake()
    {
            _handler= GetComponent<StoreHandler>();
            _initModule=GetComponent<InitModule>();
    }

    public void WriteGameData()
    {
        var _user = _initModule.User();
        var _game = _gameName.text;
        var _score = _scoreValue.text;
        _handler.WriteGameData(_user, _game, _score);
    }

    public void WriteRegisterData()
    {
        string _userName = _name.text+ " "+ _userSurname.text + " " + _userSecondSurname.text;
        string _email = _userEmail.text;
        string _password = _userPassword.text;
        int _images = 0;
        string _vision= "Normal";
        _handler.WriteRegisterData(_userName, _email, _password,_role, _images, _vision);
    }

    public void WriteTestData(string _userName, string _testName, string _results)
    {
        _handler.WriteTestData(_userName,_testName, _results);
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
}
