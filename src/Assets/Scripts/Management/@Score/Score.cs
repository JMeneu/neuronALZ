/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 27/10/2021
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script describe c�mo evoluciona la puntuaci�n en las distintas escenas, en tiempo real. 
//   La puntuaci�n final se obtiene en final_score, que obtiene la informaci�n se score. 
// # Update:
//   Se a�ade la puntuaci�n de otros juegos (Vasos). 
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [Header("Scoring Text")]
    public GameObject txt;

    [Header("Scoring variables")]
    public float score = 0;
    public int final_score;
    public float timer = 60f;
    public static Score instance;
    public Scene currentScene;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        txt.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        currentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        string sceneName = currentScene.name;

        if (sceneName == "Sumas")
        {
                txt.GetComponent<UnityEngine.UI.Text>().text = final_score.ToString();
        }
        else if (sceneName == "Restas")
        {
            txt.GetComponent<UnityEngine.UI.Text>().text = final_score.ToString();
        }
        else if (sceneName == "Laberinto")
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                score = (int)timer;
            }
            txt.GetComponent<UnityEngine.UI.Text>().text = score.ToString();

        }
        else if (sceneName == "Figuras")
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                score = (int)timer;
            }
            txt.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        }
        else if (sceneName == "Teléfono")
        {
            txt.GetComponent<UnityEngine.UI.Text>().text = final_score.ToString();
        }
        else if (sceneName == "Vasos")
        {
            txt.GetComponent<UnityEngine.UI.Text>().text = final_score.ToString();
        }
        else
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                score = (int)timer;
            }
            txt.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        }

    }
}




