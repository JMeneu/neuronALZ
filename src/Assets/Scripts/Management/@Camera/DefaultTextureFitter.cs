using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class DefaultTextureFitter : MonoBehaviour,ICameraHandlerTextureFitter
{
    private Vector2 _starting;
    private bool _savedSize = false;
    private float _imgRatio;
    private float _texRatio;

    public RawImage TextureScaleFit(RawImage _rawImage)
    {
        _imgRatio = 1;
		_texRatio = 1;
        RectTransform _rt = _rawImage.GetComponent<RectTransform>();
        if (_savedSize == false)
        {
            _starting = _rt.sizeDelta;
            _savedSize = true;
        }
        else
        {
            _rt.sizeDelta = _starting;
        }
        return _rawImage;
    }

    public RawImage TextureRotateFit(RawImage _rawImage)
    {
        _rawImage.uvRect = new Rect(0, 0, 1, 1);
        return _rawImage;
    }

    public RectTransform TextureRatioFit(RectTransform _rt, RawImage _rawImage)
    {
        _imgRatio = (float)_rt.sizeDelta.x / _rt.sizeDelta.y;
        _texRatio = (float)_rawImage.texture.width / _rawImage.texture.height;
        if (_texRatio > 1)
        {
            _rt.sizeDelta = new Vector2(_rt.sizeDelta.x, _rt.sizeDelta.y / _texRatio);
        }
        else if (_texRatio == 1)
        {
            _rt.sizeDelta = new Vector2(_rt.sizeDelta.x, _rt.sizeDelta.y);
        }
        else
        {
            _rt.sizeDelta = new Vector2(_rt.sizeDelta.x * _texRatio, _rt.sizeDelta.y);
        }
        return _rt;
    }
}
