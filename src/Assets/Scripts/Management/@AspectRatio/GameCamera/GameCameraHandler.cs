using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameCameraHandler: MonoBehaviour
{
    private IAspectRatioHandlerCamera _defaultCamera;

    private void Awake()
    {
        _defaultCamera= GetComponent<DefaultCamera>();
    }
    public Vector3 SetPosition()
    {
        return _defaultCamera.SetPosition();
    }
    public float SetSize()
    {
       return _defaultCamera.SetSize();
    }
}