using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class DefaultTextureSet : MonoBehaviour, ICameraHandlerTextureSet
{
    public Texture2D TextureSet(WebCamTexture _webCamTexture)
    {
        Texture2D photo = new Texture2D(_webCamTexture.width, _webCamTexture.height);
        photo.SetPixels(_webCamTexture.GetPixels());
        photo.Apply();
        return photo;
    }
}
