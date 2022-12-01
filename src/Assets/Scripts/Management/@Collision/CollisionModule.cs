/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 9/01/2022
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script describe la lógica modular básica para el análisis de colisiones entre objetos, permitiendo
//   un manejo estándar de esta serie de eventos.
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionModule : MonoBehaviour
{
    private CollisionHandler _handler;
    [SerializeField]
    private string game;
    [SerializeField]
    private GameObject _otherObject;

    private void Awake(){
        _handler= GetComponent<CollisionHandler>();
    }
    private void OnTriggerEnter2D(Collider2D _object)
    {
        _handler.Collision(_otherObject, _object, game);
    }
}
