/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 9/01/2022
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script describe la lógica modular básica del manejo del gesto de arrastre, empleado en juegos 
//   y probablemente empleado en otras funcionalidades futuras. El módulo lee la posición del dedo sobre
//   el objeto, y en cuanto éste se mueve, se realiza una transformación en la posición del objeto.
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragModule : MonoBehaviour
{

    [SerializeField]
    private GameObject _object;
    private DragHandler _handler;

    private void Awake(){
        _handler= GetComponent<DragHandler>();
    }

    private void OnMouseDrag()
    {
        _handler.Drag(_object);
    }
}
