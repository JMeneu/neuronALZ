using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class DefaultPhotoEncoder : MonoBehaviour,ICameraHandlerPhotoEncoder
{
    public byte[] PhotoEncode(Texture2D _texture,  byte[] _bytes)
    {
        byte[] bytes = _texture.EncodeToPNG();
        return bytes;
    }
}
