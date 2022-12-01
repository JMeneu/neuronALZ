using System;
using System.Collections;
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

public class DefaultLogin : MonoBehaviour, ILoginHandler
{
    private bool _isOk;
    private string message;
    private System.Threading.Tasks.Task< FirebaseUser > _task;
    public IEnumerator Login(string _email, string _password, FirebaseAuth _auth, Text _positiveFeedback, Text _negativeFeedback)
    {
        yield return(StartCoroutine(LoginCoroutine(_email, _password, _auth, _positiveFeedback, _negativeFeedback)));
    }
    public IEnumerator LoginCoroutine(string _email, string _password, FirebaseAuth _auth, Text _positiveFeedback, Text _negativeFeedback)
    {
        _task = _auth.SignInWithEmailAndPasswordAsync(_email, _password);
        yield return new WaitUntil(predicate: () => _task.IsCompleted);
        if (_task.Exception != null)
        {
            _isOk = false;
            FirebaseException firebaseEx = _task.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
            message = "Fallo al iniciar sesión!";
            switch (errorCode)
            {
                case AuthError.MissingEmail:
                    message = "Falta el correo electrónico\nIntroduzca su correo electrónico";
                    break;
                case AuthError.MissingPassword:
                    message = "Falta la contraseña\nIntroduzca su contraseña";
                    break;
                case AuthError.WrongPassword:
                    message = "Contraseña incorrecta\nSi no la recuerda, pulse en  Olvidé mi Contraseña";
                    break;
                case AuthError.InvalidEmail:
                    message = "Correo inválido.\nIntroduzca el correo registrado correctamente.";
                    break;
                case AuthError.UserNotFound:
                    message = "La cuenta no existe\nSi lo desea puede registrar una nueva cuenta";
                    break;
            }
            _negativeFeedback.text= message;
        }
        else
        {
            _isOk = true;
            var User=_auth.CurrentUser;
            User = _task.Result;
            message="¡Bienvenid@ de nuevo,\n"+ User.DisplayName+"!";
            _positiveFeedback.text= message;
        }
    }

    public bool GetStatus()
    {
        return _isOk;
    }
}