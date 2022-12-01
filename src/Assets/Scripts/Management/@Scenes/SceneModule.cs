/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 9/01/2022
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script describe la lógica modular básica de la carga de escenas, con variaciones de la convencional
//  carga (con tiempo atrás, con un nivel, etc.)
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SceneModule : MonoBehaviour
{
    private SceneHandler _handler;

    public static List <string> _sceneHistory= new List<string>();

    private void Awake()
    {
        _handler= GetComponent<SceneHandler>();
    }
    public void Load(string _scene)
    {
        AddHistory(_scene);
        _handler.Load(_scene);
    }
    public void Load(int level)
    {
        AddHistory("Splash");
        SceneManagerPro.SetParameters("parameter", level);
        _handler.Load("Splash", 3, _sceneHistory[_sceneHistory.Count-2], "parameter", level);
    }
    public void Load(string _scene, string _parameter, int _level)
    {
        AddHistory(_scene);
        _handler.Load(_scene,_parameter, _level);
    }
    public void LoadPrevious()
    {
        _handler.Load(_sceneHistory[_sceneHistory.Count-1]);
    }
    
    public void LoadPrevious(string _scene)
    {
        AddHistory(_scene);
        Debug.Log(_scene);
        _handler.Load("MenuLevel");
    }
    public void ReplayPrevious()
    {
        LoadPrevious(_sceneHistory[_sceneHistory.Count-1]);
    }
    private void AddHistory(string _scene)
    {
        _sceneHistory.Add(_scene);
    }
    public string ReadHistory(){
        return _sceneHistory[_sceneHistory.Count-2];
    }
}
