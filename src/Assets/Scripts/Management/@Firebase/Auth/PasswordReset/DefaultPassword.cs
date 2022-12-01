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


public class DefaultPassword : MonoBehaviour, IPasswordHandler
{
    private bool _isOk;
    private bool _isDone;
    private string message;
    public IEnumerator SendPasswordResetEmail(string _email, FirebaseAuth _auth,  Text _positiveFeedback, Text _negativeFeedback)
    {
        _auth.SendPasswordResetEmailAsync(_email).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                message="Se canceló la\noperación asíncrona de\nenvío de contraseña.";
                _negativeFeedback.text= message;
                _isOk=false;
            }
            if (task.IsFaulted)
            {
                message="Hubo un error en\nla operación asíncrona\nde envío de contraseña.";
                _negativeFeedback.text= message;
                _isOk=false;
            }
            else
            {
                message = "Correo de reseteo\nde credenciales enviado\ncorrectamente.";
                _positiveFeedback.text= message;
                _isOk=true;
            }
            _isDone=true;
        });
        yield return new WaitUntil(predicate: () => _isDone);
    }
    public bool CheckStatus()
    {
        return _isOk;
    }
}
