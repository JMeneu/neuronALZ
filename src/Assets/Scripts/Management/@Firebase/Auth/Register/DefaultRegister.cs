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

public class DefaultRegister : MonoBehaviour, IRegisterHandler
{
    public bool _isOk=false;
    private string message;

    public IEnumerator Register(string _email, string _password, string _passwordVerify, string _username, FirebaseAuth _auth, Text _positiveFeedback, Text _negativeFeedback)
    {
        yield return (StartCoroutine(RegisterCoroutine(_email, _password,_passwordVerify, _username, _auth, _positiveFeedback,_negativeFeedback)));
    }

    public IEnumerator RegisterCoroutine(string _email, string _password, string _passwordVerify, string _username, FirebaseAuth _auth,Text _positiveFeedback, Text _negativeFeedback)
    {
        if (_username == "")
        {
            message = "Falta el usuario\nIntroduzca el usuario.";
            _isOk = false;
        }
        else if (_password != _passwordVerify)
        {

            message = "Las contraseñas no coinciden\nRevise la contraseña.";
            _isOk = false;
        }
        else
        {
            var RegisterTask = _auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if (RegisterTask.Exception != null)
            {
                _isOk = false;
                Debug.LogWarning(message: $"Fallo al registrar tarea con {RegisterTask.Exception}");
                FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
                message = "Registro Fallido!";
                switch (errorCode)
                {
                    case AuthError.MissingEmail:
                        message = "Falta el correo electrónico\nInstroduzca su correo electrónico";
                        break;
                    case AuthError.MissingPassword:
                        message = "Falta la contraseña\nIntroduzca su contraseña";
                        break;
                    case AuthError.WeakPassword:
                        message = "Contraseña débil\nElija otra más segura";
                        break;
                    case AuthError.EmailAlreadyInUse:
                        message = "Email en uso\nCambie el correo electrónico";
                        break;
                }
                _negativeFeedback.text= message;
            }
            else
            {
                var User = RegisterTask.Result;
                if (User != null)
                {
                    UserProfile profile = new UserProfile { DisplayName = _username };
                    var ProfileTask = User.UpdateUserProfileAsync(profile);
                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

                    if (ProfileTask.Exception != null)
                    {
                        _isOk=false;
                        Debug.LogWarning(message: $"Fallo al registrar tarea con {ProfileTask.Exception}");
                        FirebaseException firebaseEx = ProfileTask.Exception.GetBaseException() as FirebaseException;
                        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
                        message= "Fallo al introducir el usuario!";
                        _negativeFeedback.text= message;
                    }
                    else
                    {
                        _isOk = true;
                        message= "¡Bienvenid@, " + User.DisplayName+"!";
                        _positiveFeedback.text= message;
                    }
                }
            }
        }
    }
        public bool GetStatus()
        {
            return _isOk;
        }
}
