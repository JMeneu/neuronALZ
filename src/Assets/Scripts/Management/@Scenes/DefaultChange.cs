using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefaultChange : MonoBehaviour, ISceneHandler
{
    private void Awake()
    {
        //DontDestroyOnLoad(this);
    }
    public void Load(string _scene)
    {
        SceneManagerPro.Load(_scene);
    }
    public void Load(string _scene, string _parameter, int _level)
    {
        SceneManagerPro.Load(_scene, _parameter, _level);
    }
    public void Load(string _scene, int _countdown, string _nextScene,string _parameter, int _level)
    {
        StartCoroutine(InitCoroutine(_scene, _countdown, _nextScene, _parameter, _level));
    }
    public IEnumerator InitCoroutine (string _scene, int _countdown, string _nextScene, string _parameter, int _level)
    {
        yield return (StartCoroutine(LoadCoroutine(_scene, _countdown)));
        Load(_nextScene, _parameter, _level);
    }
    public IEnumerator LoadCoroutine(string _scene, int _countdown)
    {
        Load(_scene);
        yield return new WaitForSeconds(3);
    }
    public IEnumerator CountDownCoroutine(int _countdown)
    {
        yield return new WaitForSeconds(3);

    }
}
