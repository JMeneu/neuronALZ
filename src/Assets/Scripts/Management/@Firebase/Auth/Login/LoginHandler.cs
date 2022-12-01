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


public class LoginHandler: MonoBehaviour
{
    private ILoginHandler _defaultLogin;

    private void Awake(){
        _defaultLogin= GetComponent<DefaultLogin>();
    }
    public IEnumerator Login(string _email, string _password, FirebaseAuth _auth, Text _positiveFeedback, Text _negativeFeedback)
    {
        yield return StartCoroutine(_defaultLogin.Login(_email, _password, _auth,_positiveFeedback, _negativeFeedback));
    }
    public bool CheckStatus()
    {
        return _defaultLogin.GetStatus();
    }
}
