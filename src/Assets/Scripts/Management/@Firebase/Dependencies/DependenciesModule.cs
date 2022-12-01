/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 9/01/2022
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script describe la lógica modular básica para el análisis de dependencias de Firebase.
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Analytics;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;

public class DependenciesModule : MonoBehaviour
{
    private IDependenciesHandler _handler;
    private DependencyStatus _dependencyStatus;
    private void Awake()
    {
        //DontDestroyOnLoad(this);
        _handler= GetComponent<DefaultDependencies>();
        _handler.DependenciesCheck(_dependencyStatus);
    }
}
