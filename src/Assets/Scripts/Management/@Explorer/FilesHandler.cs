using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using NativeFilePickerNamespace;


public class FilesHandler: MonoBehaviour
{
    private IFileSelectionHandler _defaultSelection;
    private ICameraHandlerTextureFitter _defaultTextureFitter;
    private IFileLoading _defaultLoading;


    private void Awake()
    {
        _defaultTextureFitter= GetComponent<DefaultTextureFitter>();
        _defaultSelection= GetComponent<DefaultSelection>();
        _defaultLoading= GetComponent<DefaultLoading>();
    }
    public string GetImagePath(string _path)
    {
        _path= _defaultSelection.SelectFile("image/*");
        return _path;

    }
    public string GetVideoPath(string _path)
    {
        _path = _defaultSelection.SelectFile("video/*");
        return _path;
    }
    public string GetPdfPath(string _path)
    {
        _path = _defaultSelection.SelectFile("application/pdf");
        return _path;
    }

    public RawImage TextureFit(RawImage _rawImage, RectTransform _rt)
    {
        _rt = _rawImage.GetComponent<RectTransform>();
        _rawImage = _defaultTextureFitter.TextureScaleFit(_rawImage);
        _rt = _defaultTextureFitter.TextureRatioFit(_rt, _rawImage);
        _rawImage = _defaultTextureFitter.TextureRotateFit(_rawImage);
        return _rawImage;
    }
    public RawImage TextureLoad(string _path, RawImage _rawImage)
    {
        _rawImage=_defaultLoading.LoadFile(_path, _rawImage);
        return _rawImage;
    }


}
