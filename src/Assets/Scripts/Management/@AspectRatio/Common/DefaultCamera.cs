using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefaultCamera : MonoBehaviour, IAspectRatioHandlerCamera
{
    private Dictionary<float, float> _aspectRatioDictionary = new Dictionary<float, float>()
    {
        { 4/3f, 7.5f},
        { 3/2f, 7f},
        { 16/10f, 6f},
        { 5/3f, 6f},
        { 9/5f, 5.85f},
        { 16/9f,5.5f},
        { 18/9f, 4.95f },
        { 37/18f, 4.9f },
        { 19/9f, 4.85f},
        { 20/9f,4.8f },
        { 21/9f,4.75f },
    };
    private float[] _displaySize;
    private int[] _offset={5, -10};
    public float SetSize()
    {
        return ((Display.main.systemHeight) / 2);
    }
    public float SetSize(float _aspectRatio)
    {
        if (_aspectRatioDictionary.ContainsKey(_aspectRatio))
        {
            return (float)(_aspectRatioDictionary[_aspectRatio]);
        }
        else
        {
            return 5.5f;
        }

    }

    public Vector3 SetPosition()
    {
        return new Vector3(Display.main.systemWidth / 2, Display.main.systemHeight / 2, _offset[1]);
    }
    public Vector3 SetPosition(float _aspectRatio)
    {
        if (_aspectRatioDictionary.ContainsKey(_aspectRatio))
        {
            return new Vector3(Camera.main.transform.position.x, _offset[0]-  Camera.main.orthographicSize, _offset[1]);
        }
        else
        {
            return new Vector3(Display.main.systemWidth / 2, Display.main.systemHeight / 2, _offset[1]);
        }
    }
}
