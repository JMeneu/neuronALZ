using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public interface ICameraHandlerTextureSet
{
    public Texture2D TextureSet(WebCamTexture _webCamTexture);
}
