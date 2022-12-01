using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapObject : MonoBehaviour, ISwapHandler
{
    public bool Swap(RawImage _object,Texture2D[] _textures, bool _status)
    {
        if(_status==false)
        {
            _object.texture=_textures[0];
            return true;
        }
        else
        {
            _object.texture=_textures[1];
            return false;
        }
    }

    public bool Swap(RawImage _object, Texture2D[] _textures, InputField _inputField, bool _status)
    {
        if(_status==false)
        {
            _object.texture=_textures[0];
            _inputField.contentType = InputField.ContentType.Password;
            _inputField.ForceLabelUpdate();
            return true;

        }
        else
        {
             _object.texture=_textures[1];
            _inputField.contentType = InputField.ContentType.Standard;
            _inputField.ForceLabelUpdate();
            return false;
        }
    }
}
