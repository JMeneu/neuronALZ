using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneHandler: MonoBehaviour
{
    private ISceneHandler _load;

    private void Awake()
    {
        _load= GetComponent<DefaultChange>();
    }
    public void Load(string _scene)
    {
        _load.Load(_scene);
    }
    public void Load(string _scene,string _parameter, int _level)
    {
        _load.Load(_scene,_parameter, _level);
    }
    public void Load(string _scene, int _countdown, string _nextScene,string _parameter, int _level)
    {
        _load.Load(_scene, _countdown, _nextScene, _parameter, _level);
    }

}
