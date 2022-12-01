using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RendererHandler: MonoBehaviour
{

    private IRendererHandler _defaultRenderer;
    private IInputRenderingHandler _defaultInput;

    private void Awake()
    {
        _defaultInput=GetComponent<DefaultRenderingInput>();
        _defaultRenderer=GetComponent<DefaultRenderer>();
    }
    public int Index(GameObject _index)
    {
        return _defaultInput.ReadInput(_index);

    }
    public int Index(Vector3 _direction)
    {
        return _defaultInput.ReadInput(_direction);
    }
    public void Render(Sprite[] _spriteArray, int _arrayIndex)
    {
        _defaultRenderer.RenderSprite(_spriteArray[_arrayIndex]);
    }

}
