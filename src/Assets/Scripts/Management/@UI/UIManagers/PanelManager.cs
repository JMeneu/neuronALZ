/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 15/11/2021
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script define la activaci�n y desactivaci�n de paneles, dentro del MenuMedia. Adicionalmente,
//   en algunos de estos paneles se almacena informaci�n relativa al paciente.
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public Text local_name;

    [Header("Instancias")]
    public static PanelManager instance;


    void Awake()
    {
        instance = this;
    }
    public void Select_Media(Text name)
    {
        local_name = name;
    }
    public string GetName()
    {
        return local_name.text;
    }
}
