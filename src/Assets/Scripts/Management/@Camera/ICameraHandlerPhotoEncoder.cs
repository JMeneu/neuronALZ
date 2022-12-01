using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public interface ICameraHandlerPhotoEncoder
{
    byte[] PhotoEncode(Texture2D _texture, byte[] _bytes);
}
