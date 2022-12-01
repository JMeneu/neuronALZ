/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 9/01/2022
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script describe la lógica modular básica para la sustitución de un objeto por otro.
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
class SwapModule : MonoBehaviour
{
    [SerializeField]
    private ISwapHandler _swapObject;
    [SerializeField]
    private InputField _inputField;

    [SerializeField]
    private RawImage _object;
    [SerializeField]
    private Texture2D[] _textures;

    private bool _status;
    private void Awake()
    {
        _swapObject= GetComponent<SwapObject>();
        _status=false;
    }
    public void Swap()
    {
        _status=_swapObject.Swap(_object, _textures,_inputField, _status);
    }

}

