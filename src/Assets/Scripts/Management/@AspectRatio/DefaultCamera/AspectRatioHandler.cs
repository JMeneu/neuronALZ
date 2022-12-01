using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AspectRatioHandler: MonoBehaviour
{
    private IAspectRatioHandlerCalculate _defaultCalculate;
    private IAspectRatioHandlerCamera _defaultCamera;
    private float _aspectRatio;

    private void Awake()
    {
        _defaultCalculate= GetComponent<DefaultCalculate>();
        _defaultCamera= GetComponent<DefaultCamera>();
    }

    public float Calculate()
    {
        _aspectRatio = _defaultCalculate.Calculate();
        return _aspectRatio;
    }
    public Vector3 SetPosition(float _aspectRatio)
    {
        return _defaultCamera.SetPosition(_aspectRatio);
    }
    public float SetSize(float _aspectRatio)
    {
        return _defaultCamera.SetSize(_aspectRatio);
    }
}
