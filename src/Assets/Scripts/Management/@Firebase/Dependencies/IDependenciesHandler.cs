using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Analytics;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;


public interface IDependenciesHandler
{
    public void DependenciesCheck(DependencyStatus _dependencyStatus);
}
