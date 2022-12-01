/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 15/11/2021
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script implementa el texto a cada botón de la lista.
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListButton : MonoBehaviour
{
    [SerializeField]
    [Header("Variables")]
    private Text myText;

    public void SetText(string textString)
    {
        myText.text = textString; 
    }
}
