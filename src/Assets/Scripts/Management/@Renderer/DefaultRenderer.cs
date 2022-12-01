using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DefaultRenderer : MonoBehaviour, IRendererHandler
{
    [SerializeField]
    private Image _objectImage;
    public void RenderSprite(Sprite _sprite)
    {
        _objectImage.sprite = _sprite;
    }
}
