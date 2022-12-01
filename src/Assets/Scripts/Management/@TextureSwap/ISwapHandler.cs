using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public interface ISwapHandler
{
    public bool Swap(RawImage _object,Texture2D[] _textures, bool _status);
    public bool Swap(RawImage _object, Texture2D[] _textures, InputField _inputField, bool _status);
}
