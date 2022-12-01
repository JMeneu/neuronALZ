/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 9/01/2022
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script describe la lógica modular básica para el renderizado de imágenes en Unity.
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RendererModule : MonoBehaviour
{
    private RendererHandler _handler;

    [SerializeField]
    private Sprite[] _spriteArray;
    [SerializeField]
    private GameObject _object;
    private int _arrayIndex;

    private void Awake(){

        _handler= GetComponent<RendererHandler>();
    }
    private void Update()
    {
        _arrayIndex=_handler.Index(_object);
        _handler.Render(_spriteArray, _arrayIndex);
    }
}
