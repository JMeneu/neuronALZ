using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Analytics;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using Firebase.Storage;
using Firebase.Firestore;


public class DefaultDatabase : MonoBehaviour, IDatabaseHandler
{

    private int files;
    private static List<string> _patients = new List<string>();
    private bool _isPatient;
    private string _colors;
    private int _images;
    private bool _isDone;

    private void Awake()
    {
        _isPatient=false;
        _images=0;
        files=0;
        _isDone=false;
    }
    public IEnumerator WriteRegisterData(string _user,string _role, int _images, DatabaseReference _reference)
    {
        yield return StartCoroutine(WriteRegister(_user, _role, _images, _reference));
    }
    public IEnumerator WriteRegister(string _user,string _role, int _images, DatabaseReference _reference)
    {
        var _dbTask = _reference.Child("Users").Child(_user).Child("Role").SetValueAsync(_role);
        yield return new WaitUntil(predicate: () => _dbTask.IsCompleted);

        if (_dbTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {_dbTask.Exception}");
        }
        else
        {
            Debug.Log("Entrada de información de usuario creada.");
        }
        var _dbTask2 = _reference.Child("Users").Child(_user).Child("Images").SetValueAsync(0);
        yield return new WaitUntil(predicate: () => _dbTask2.IsCompleted);

        if (_dbTask2.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {_dbTask2.Exception}");
        }
        else
        {
            Debug.Log("Entrada de imágenes creada.");
        }
        var _dbTask3 = _reference.Child("Users").Child(_user).Child("Vision").SetValueAsync("Normal");
        yield return new WaitUntil(predicate: () => _dbTask3.IsCompleted);

        if (_dbTask3.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {_dbTask3.Exception}");
        }
        else
        {
            Debug.Log("Entrada de visión creada.");
        }
    }

    public IEnumerator WriteGameData(string _game, string _score, FirebaseUser _user, DatabaseReference _reference)
    {
        yield return StartCoroutine(WriteGame(_game, _user, _reference));
        yield return StartCoroutine(WriteScore(_score, _user, _reference));
    }
    public IEnumerator WriteGame(string _game, FirebaseUser _user, DatabaseReference _reference)
    {
        var _dbTask = _reference.Child("Scores").Child(_user.DisplayName).Child(DateTime.Now.ToString("yyyy-MM-dd HH:mm")).Child("Game").SetValueAsync(_game);

        yield return new WaitUntil(predicate: () => _dbTask.IsCompleted);

        if (_dbTask.Exception != null)
        {
            Debug.LogWarning(message: $"Fallo al registrar tarea con {_dbTask.Exception}");
        }
        else
        {
            Debug.Log("Juego guardado correctamente");
        }
    }

    public IEnumerator WriteScore(string _score, FirebaseUser _user, DatabaseReference _reference)
    {
        var _dbTask = _reference.Child("Scores").Child(_user.DisplayName).Child(DateTime.Now.ToString("yyyy-MM-dd HH:mm")).Child("Score").SetValueAsync(_score);

        yield return new WaitUntil(predicate: () => _dbTask.IsCompleted);

        if (_dbTask.Exception != null)
        {
            Debug.LogWarning(message: $"Fallo al registrar tarea con{_dbTask.Exception}");
        }
        else
        {
            Debug.Log("Puntuación guardada correctamente");
        }
    }
    public IEnumerator WriteImages(int _images, FirebaseUser _user, DatabaseReference _reference)
    {
        var _dbTask= _reference.Child("Users").Child(_user.DisplayName).Child("Images").SetValueAsync(_images);

        yield return new WaitUntil(predicate: () => _dbTask.IsCompleted);

        if (_dbTask.Exception != null)
        {
            Debug.LogWarning(message: $"Fallo al registrar tarea con{_dbTask.Exception}");
        }
        else
        {
            Debug.Log("Imágenes guardada correctamente");
        }
    }

    public IEnumerator WriteImages(int _images, string _userName, DatabaseReference _reference)
    {
        var _dbTask= _reference.Child("Users").Child(_userName).Child("Images").SetValueAsync(_images);

        yield return new WaitUntil(predicate: () => _dbTask.IsCompleted);

        if (_dbTask.Exception != null)
        {
            Debug.LogWarning(message: $"Fallo al registrar tarea con{_dbTask.Exception}");
        }
        else
        {
            Debug.Log("Imágenes guardada correctamente");
        }
    }
    public IEnumerator WriteTestData(string _userName, string _testName, string _results, DatabaseReference _reference)
    {
        yield return StartCoroutine(WriteTest(_userName, _testName, _results, _reference));
    }

    public IEnumerator WriteTest(string _userName, string _testName, string _results,DatabaseReference _reference)
    {
        var _dbTask = _reference.Child("Users").Child(_userName).Child(_testName).SetValueAsync(_results);
        yield return new WaitUntil(predicate: () => _dbTask.IsCompleted);

        if (_dbTask.Exception != null)
        {
            Debug.LogWarning(message: $"Fallo al regitrar tarea con {_dbTask.Exception}");
        }
        else
        {
            Debug.Log("Estado de visión guardado.");
        }
    }

    public IEnumerator ReadLoginData(FirebaseUser _user)
    {
        yield return StartCoroutine(ReadRole(_user));
        yield return StartCoroutine(ReadColor(_user));
    }
    public IEnumerator ReadRole(FirebaseUser _user)
    {
        FirebaseDatabase.DefaultInstance.GetReference("Users").GetValueAsync().ContinueWithOnMainThread(_dbTask => {
        if (_dbTask.IsFaulted)
        {
            
        }
        else if (_dbTask.IsCompleted)
        {
            DataSnapshot _snapshot = _dbTask.Result;
            foreach (var _child in _snapshot.Children)
            {
                if(_child.Key == _user.DisplayName)
                {
                    Debug.Log(_child.Key);
                    Debug.Log(_user.DisplayName);
                    foreach (var i in _child.Children)
                    {
                        if (i.Key.ToString() == "Role")
                        {
                            if(i.Value.ToString()=="Terapeuta")
                            {
                                Debug.Log(i.Value.ToString());
                                _isPatient=false;
                            }
                            else
                            {
                                 _isPatient=true;
                            }

                        }
                    }
                }
            }
        }
      });
      yield return new WaitForSeconds(0);
    }
    public IEnumerator ReadColor(FirebaseUser _user)
    {
        FirebaseDatabase.DefaultInstance.GetReference("Users").GetValueAsync().ContinueWithOnMainThread(_dbTask => {
        if (_dbTask.IsFaulted)
        {

        }
        else if (_dbTask.IsCompleted)
        {
            DataSnapshot _snapshot = _dbTask.Result;
            foreach (var _child in _snapshot.Children)
            {
                if (_child.Key == _user.DisplayName)
                {
                    Debug.Log(_child.Key);
                    Debug.Log(_user.DisplayName);
                    foreach (var i in _child.Children)
                    {
                        if (i.Key.ToString() == "Vision")
                        {
                            _colors=i.Value.ToString();
                        }
                    }
                }
            }
        }
    });
    yield return new WaitForSeconds(0);
    }

    public IEnumerator ReadUploadData(FirebaseUser _user)
    {
        yield return StartCoroutine(ReadImages(_user));
    }

    public IEnumerator ReadUploadData(string _userName)
    {
        yield return StartCoroutine(ReadImages(_userName));
    }
    
    public IEnumerator ReadImages(FirebaseUser _user)
    {
        FirebaseDatabase.DefaultInstance.GetReference("Users").GetValueAsync().ContinueWithOnMainThread(_dbTask => {
        if (_dbTask.IsFaulted)
        {
            Debug.Log("Error: Ha ocurrido un fallo");
        }
        else if (_dbTask.IsCompleted)
        {
            DataSnapshot _snapshot = _dbTask.Result;
            foreach (var _child in _snapshot.Children)
            {
                if (_child.Key.ToString() == _user.DisplayName)
                {
                    foreach (var i in _child.Children)
                    {
                        if (i.Key.ToString() == "Images")
                        {
                            files = int.Parse(i.Value.ToString());
                            Debug.Log("Images:" + files);
                            _images=files;
                            _isDone=true;
                        }
                    }
                }
            }
        }
    });
    yield return new WaitUntil(predicate: ()=> _isDone);
    Debug.Log("All done!");
    _isDone=false;
    }

    public IEnumerator ReadImages(string _userName)
    {
        FirebaseDatabase.DefaultInstance.GetReference("Users").GetValueAsync().ContinueWithOnMainThread(_dbTask => {
        if (_dbTask.IsFaulted)
        {
            Debug.Log("Error: Ha ocurrido un fallo");
        }
        else if (_dbTask.IsCompleted)
        {
            DataSnapshot _snapshot = _dbTask.Result;
            foreach (var _child in _snapshot.Children)
            {
                if (_child.Key.ToString() == _userName)
                {
                    foreach (var i in _child.Children)
                    {
                        if (i.Key.ToString() == "Images")
                        {
                            files = int.Parse(i.Value.ToString());
                            Debug.Log("Images:" + files);
                            _isDone=true;
                        }
                    }
                }
            }
        }
    });
    yield return new WaitUntil(predicate: ()=> _isDone);
    Debug.Log("All done!");
    _isDone=false;
    }

    public IEnumerator ReadUsersTotalAmount()
    {
        yield return StartCoroutine(ReadUsers());
    }
    
    public IEnumerator ReadUsers()
    {
        FirebaseDatabase.DefaultInstance.GetReference("Users").GetValueAsync().ContinueWithOnMainThread(_dbTask => {
        if (_dbTask.IsFaulted)
        {
            Debug.Log("Error: Ha ocurrido un fallo");
        }
        else if (_dbTask.IsCompleted)
        {
            DataSnapshot _snapshot = _dbTask.Result;
            foreach (var _child in _snapshot.Children)
            {
                    foreach (var i in _child.Children)
                    {
                        if (i.Value.ToString() == "Paciente")
                        {
                            _patients.Add(_child.Key.ToString());
                        }
                    }
            }
        }
    });
    yield return new WaitForSeconds(0);
    }

    public bool GetRole()
    {
        return _isPatient;
    }

    public string GetPalette()
    {
        return _colors;
    }
    public int GetImages()
    {
        return files;
    }
    public List<string> GetList()
    {
        return _patients;
    }
}
