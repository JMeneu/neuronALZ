using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CameraHandler: MonoBehaviour
{
    private ICameraHandlerSetup _defaultSetup;
    private ICameraHandlerPreviewFitter _defaultPreviewFitter;
    private ICameraHandlerTextureSet _defaultTextureSet;
    private ICameraHandlerTextureFitter _defaultTextureFitter;
    private ICameraHandlerPhotoFitter _defaultPhotoFitter;
    private ICameraHandlerPhotoEncoder _defaultPhotoEncoder;
    private ICameraHandlerPhotoSaver _defaultPhotoSaver;

    private void Awake()
    {
        _defaultSetup = GetComponent<ICameraHandlerSetup>();
        _defaultPreviewFitter = GetComponent<ICameraHandlerPreviewFitter>();
        _defaultTextureSet = GetComponent<ICameraHandlerTextureSet>();
        _defaultTextureFitter = GetComponent<ICameraHandlerTextureFitter>();
        _defaultPhotoFitter = GetComponent<ICameraHandlerPhotoFitter>();
        _defaultPhotoEncoder = GetComponent<ICameraHandlerPhotoEncoder>();
        _defaultPhotoSaver = GetComponent<ICameraHandlerPhotoSaver>();
    }

    public WebCamTexture Init(WebCamTexture _webCamTexture,RawImage _background, GameObject _text, bool _camAvailable){
        var webcamDevices = _defaultSetup.CameraExistance(_text);
        _webCamTexture = _defaultSetup.CameraSet(webcamDevices, _background, _webCamTexture, _camAvailable);
        return _webCamTexture;
    }
    public bool Setup(WebCamTexture _webCamTexture, bool _camAvailable)
    {
        _camAvailable = _defaultSetup.CameraStatus(_webCamTexture, _camAvailable);
        return _camAvailable;
    }
    public RawImage PreviewFit(WebCamTexture _webCamTexture, RawImage _background)
    {
        _background=_defaultPreviewFitter.CameraRotateFit(_webCamTexture, _background);
        _background=_defaultPreviewFitter.CameraScaleFit(_webCamTexture, _background);
        return _background;
    }
    public AspectRatioFitter PreviewRatioFit(WebCamTexture _webCamTexture, AspectRatioFitter _fit)
    {
        _fit =_defaultPreviewFitter.CameraRatioFit(_webCamTexture,_fit);
        return _fit;

    }
    public Texture2D TextureGet(Texture2D _texture, WebCamTexture _webCamTexture)
    {
        _texture = _defaultTextureSet.TextureSet(_webCamTexture);
        return _texture;
    }
    public RawImage TextureSet(Texture2D _texture, RawImage _rawImage)
    {
        _rawImage.texture=_texture;
        return _rawImage;
    }
    public RawImage TextureFit(RawImage _rawImage, RectTransform _rt)
    {
        _rt = _rawImage.GetComponent<RectTransform>();
        _rt = _defaultTextureFitter.TextureRatioFit(_rt, _rawImage);
        _rawImage = _defaultTextureFitter.TextureRotateFit(_rawImage);
        _rawImage = _defaultTextureFitter.TextureScaleFit(_rawImage);
        return _rawImage;
    }

    public Texture2D PhotoFit(Texture2D _texture, bool clockwise, int rotationAngle)
    {
        _texture = _defaultPhotoFitter.PhotoRotateFit(_texture, clockwise, rotationAngle);
        return _texture;
    }
    public byte[] PhotoEncode(Texture2D _texture, byte[] _bytes)
    {
        _bytes = _defaultPhotoEncoder.PhotoEncode(_texture, _bytes);
        return _bytes;
    }
    public string PhotoSave(byte[] _bytes, GameObject _continue)
    {
        var _path=_defaultPhotoSaver.PhotoSave(_bytes, _continue);
        _defaultPhotoSaver.PhotoSaved(_continue);
        return _path;
    }
}
