using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISceneHandler
{
    public void Load(string _scene);
    public void Load(string _scene, string _parameter, int _level);
    public void Load(string _scene, int _countdown, string _nextScene, string _parameter, int _level);
    public IEnumerator InitCoroutine (string _scene, int _countdown, string _nextScene,string _parameter, int _level);
    public IEnumerator LoadCoroutine(string _scene, int _countdown);
    public IEnumerator CountDownCoroutine(int _countdown);
}
