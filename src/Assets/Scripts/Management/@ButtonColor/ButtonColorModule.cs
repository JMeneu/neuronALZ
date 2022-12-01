/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 9/01/2022
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script describe la lógica modular básica de la coloración de botones estructurales, dependiendo
//   de su estado pulsado o no pulsado. Se analiza en primer lugar si el botón es de texto blanco o no,
//   y posteriormente, se ajustan los colores del texto y fondo al pulsar y dejar de pulsar.
////////////////////////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ButtonColorModule : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private ButtonColorHandler _buttonColorHandler;
    private void Awake(){

        _buttonColorHandler= GetComponent<ButtonColorHandler>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _buttonColorHandler.PointerDown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _buttonColorHandler.PointerUp();
    }
}
