/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 14/10/2021
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script establece eun límte de fotogramas a la aplicación, pero a su vez
//   inhabilita el tope establecido por defecto por Unity, tasado en 30 FPS.
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frames_limit : MonoBehaviour
{
    [Header("Variables")]
    private int fps = 90;

    private void Start(){
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = fps;

    }
}
