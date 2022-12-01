using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Analytics;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;


public class DefaultDependencies : MonoBehaviour, IDependenciesHandler
{
    public void DependenciesCheck(DependencyStatus _dependencyStatus)
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            _dependencyStatus = task.Result;
            if (_dependencyStatus == DependencyStatus.Available)
            {
                Firebase.AppOptions options = new Firebase.AppOptions();
                options.ApiKey = "AIzaSyA1L8S0z-SuQ-YqBxjqU7BOj_IWVMx47Qs";
                options.AppId = "1:1001094747363:android:9cebe1cb68b4ae6b0e21d6";
                options.ProjectId = "neuronalz-beta-cd43e";
                options.StorageBucket = "neuronalz-beta-cd43e.appspot.com";
                Debug.Log("Everything OK!");
            }
            else
            {
                Debug.LogError("No se pudieron resolver todas las dependencias de Firebase: " + _dependencyStatus);
            }
        });
    }
}
