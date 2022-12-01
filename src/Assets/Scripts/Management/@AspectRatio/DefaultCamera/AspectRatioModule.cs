/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 9/01/2022
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script describe la lógica modular básica de adaptación a diferentes ratios de pantalla. La 
//   adaptación se hace efectiva mediante el ajuste del tamaño y posición de la cámara, que se establecen
//   en función de la relación de aspecto actual
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AspectRatioModule : MonoBehaviour
{
    private AspectRatioHandler _aspectRatioHandler;
    private float _aspectRatio;
    private Camera _main;
    private void Awake()
    {
        _main= Camera.main;
        _aspectRatioHandler= GetComponent<AspectRatioHandler>();
    }
    private void Start()
    {
        _aspectRatio= _aspectRatioHandler.Calculate();
        _main.orthographicSize=_aspectRatioHandler.SetSize(_aspectRatio);
        _main.transform.position=_aspectRatioHandler.SetPosition(_aspectRatio);
    }
    private void Update()
    {
        _main.transform.position=_aspectRatioHandler.SetPosition(_aspectRatio);
    }
}
