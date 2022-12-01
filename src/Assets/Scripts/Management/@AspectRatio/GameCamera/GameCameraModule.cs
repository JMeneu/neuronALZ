/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 9/01/2022
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script describe la lógica modular básica de adaptación de la cámara a los juegos, estableciendo
//   el escalado conveniente en los objetos.
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameCameraModule : MonoBehaviour
{
    private GameCameraHandler _gameCameraHandler;
    private void Awake()
    {
        _gameCameraHandler= GetComponent<GameCameraHandler>();
    }
    private void Start()
    {
        Camera.main.orthographicSize= _gameCameraHandler.SetSize();
        Camera.main.transform.position= _gameCameraHandler.SetPosition();
    }
}
