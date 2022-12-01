/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 9/01/2022
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script describe la lógica modular básica para el manejo de la cámara, preparando las cámaras,
//   inicializándolas, previsualizando el contenido, capturando imágenes, adaptando éstas y finalmente, 
//   guardándolas.
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class CameraModule : MonoBehaviour
{

    private CameraHandler _handler;
    private bool _camAvailable;
    private byte[] _bytes;
    private Texture2D _texture;
    private WebCamTexture _webCamTexture;
    private string _path;
    
    [SerializeField]
    private RawImage _background;
    [SerializeField]
    private RawImage _rawImage;

    [SerializeField]
    private RectTransform _rt;
    [SerializeField]
    private AspectRatioFitter _fit;
    [SerializeField]
    private GameObject _continue;
    [SerializeField]
    private GameObject _text;


    private void Awake()
    {
        _handler = GetComponent<CameraHandler>();
    }
    private void Start()
    {
        _webCamTexture= _handler.Init(_webCamTexture,_background, _text, _camAvailable);
        _camAvailable = _handler.Setup(_webCamTexture, _camAvailable);
    }
    private void Update()
    {
        if (_camAvailable)
        {
            _fit=_handler.PreviewRatioFit(_webCamTexture, _fit);
            _background=_handler.PreviewFit(_webCamTexture, _background);
        }
    }
    public void TakePicture()
    {
        if (_camAvailable)
        {
            _texture=_handler.TextureGet(_texture, _webCamTexture);
            _rawImage=_handler.TextureSet(_texture, _rawImage);
            _rawImage= _handler.TextureFit(_rawImage, _rt);
            _texture=_handler.PhotoFit(_texture,true, 360);
            _bytes= _handler.PhotoEncode(_texture, _bytes);
            _path=_handler.PhotoSave(_bytes, _continue);
        }
    }

    public string GetPath()
    {
        return _path;
    }
    
}
