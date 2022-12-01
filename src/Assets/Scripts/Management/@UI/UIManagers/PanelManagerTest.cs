/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 15/11/2021
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script define la activación y desactivación de paneles, dentro del Test.
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManagerTest : MonoBehaviour
{
    [Header("Elementos UI")]
    public GameObject main;
    public GameObject popup_select;
    public Text local_name;
    public static string userName;

    [Header("Instancias")]
    public static PanelManagerTest instance;


    void Awake()
    {
        instance = this;
        Default();
    }

    public void Default()
    {
        main.SetActive(true);
        popup_select.SetActive(false);
    }
    public void Select(Text name)
    {
        main.SetActive(false);
        popup_select.SetActive(true);
        local_name = name;
        userName = local_name.text;
        Debug.Log(userName);
    }
    public string GetName()
    {
        return userName;
    }

}