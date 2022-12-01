using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class DefaultPreviewFitter : MonoBehaviour,ICameraHandlerPreviewFitter
{
    public AspectRatioFitter CameraRatioFit(WebCamTexture _webCamTexture, AspectRatioFitter _fit)
    {
        float ratio = (float)_webCamTexture.width / (float)_webCamTexture.height;
        _fit.aspectRatio = ratio;
        return _fit;
    }
    public RawImage CameraRotateFit(WebCamTexture _webCamTexture, RawImage _background)
    {
        int orient = -_webCamTexture.videoRotationAngle;
        _background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
        return _background;
    }
    public RawImage CameraScaleFit(WebCamTexture _webCamTexture, RawImage _background)
    {
        float scaleY = _webCamTexture.videoVerticallyMirrored ? -1f : 1f;
        _background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);
        return _background;
    }


}
