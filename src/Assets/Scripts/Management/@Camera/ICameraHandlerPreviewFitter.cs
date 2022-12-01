using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public interface ICameraHandlerPreviewFitter
{

    public AspectRatioFitter CameraRatioFit(WebCamTexture _webCamTexture, AspectRatioFitter _fit);
    public RawImage CameraScaleFit(WebCamTexture _webCamTexture, RawImage _background);
    public RawImage CameraRotateFit(WebCamTexture _webCamTexture, RawImage _background);
}
