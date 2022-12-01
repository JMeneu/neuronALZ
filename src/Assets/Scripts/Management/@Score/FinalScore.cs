/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 14/10/2021
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script define la puntuación final obtenida, analizando la instancia creada de Score.
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public GameObject target;

    void Start()
    {
        target.GetComponent<UnityEngine.UI.Text>().text = (Score.instance.final_score).ToString();
    }
}