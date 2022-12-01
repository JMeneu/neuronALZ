using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public interface ICameraHandlerSetup
{
    public WebCamDevice[] CameraExistance(GameObject _text);
    public WebCamTexture CameraSet(WebCamDevice[] webcamDevices, RawImage _background, WebCamTexture _webCamTexture, bool _camAvailable);
    public bool CameraStatus(WebCamTexture _webCamTexture, bool _camAvailable);
}
