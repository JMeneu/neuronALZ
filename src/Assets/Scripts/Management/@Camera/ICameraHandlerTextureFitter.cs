using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public interface ICameraHandlerTextureFitter
{
    public RawImage TextureScaleFit(RawImage _rawImage);

    public RawImage TextureRotateFit(RawImage _rawImage);

    public RectTransform TextureRatioFit(RectTransform _rt, RawImage _rawImage);
}
