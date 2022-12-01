/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 9/01/2022
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script describe la lógica modular básica de la inicialización de los principales servicios de 
//   Firebase, ello incluyendo Store, Storage, RTDB, Auth, etc.
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


public class InitModule : MonoBehaviour
{
    private InitHandler _handler;
    private FirebaseAuth _auth;
    private FirebaseUser _user;
    private FirebaseFirestore _store;
    private DatabaseReference _database;
    private StorageReference _storage;

    private void Awake(){
        _handler= GetComponent<InitHandler>();
    }

    private void Start()
    {
        _auth = _handler.Auth();
    }
    public FirebaseAuth Auth()
    {
        _auth = _handler.Auth();
        return _auth;
    }
    public void Analytics()
    {
        _handler.Analytics();
    }
    public FirebaseUser User()
    {
        _user = _handler.User();
        return _user;
    }
    public DatabaseReference Database()
    {
        _database = _handler.Database();
        return _database;
    }
    public FirebaseFirestore Store()
    {
        _store = _handler.Store();
        return _store;
    }
    public StorageReference Storage()
    {
        _storage = _handler.Storage();
        return _storage;
    }


}
