/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 14/10/2021
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script funciona de manera similar a los componentes GUI aplicables en Unity,
//   habilitando la reproducción de sonidos.
////////////////////////////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class PlayMe : MonoBehaviour
{
    [Header("Variables")]
    public AudioClip sound;
    private Button button { 
        get 
        { 
            return GetComponent<Button>();
        }
    }
    public AudioSource source { 
        get 
        { 
            return GetComponent<AudioSource>();
        } 
    }


    void Start()

    {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
        button.onClick.AddListener(() => PlaySound());
    }
    void PlaySound()
    {
        source.PlayOneShot(sound);
    }

}