/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: MIGUEL PEREZ MATEO
// # Date: 30/09/2021
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script maneja el movimiento del panel Password. Modificado por JORGE MENEU MORENO para que
//   no se viera una vez colocado.
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class olvideContra : MonoBehaviour
{
    [Header("Elementos UI")]
    [SerializeField]
    private GameObject _canvasPassword;
    [Header("Variables")]
    private Vector3 _origin,_placeHolder;
    private RectTransform _rt;
    
    void Start(){
        _rt = _canvasPassword.GetComponent<RectTransform>();
        _origin = new Vector3(0f, 0f, -2f);
        _placeHolder = new Vector3(500f, 0f, -2f);
    }
    public void showPassPopup()
    {
        _rt.localPosition = _origin;
    }

    public void hidePassPopup()
    {
        _rt.localPosition = _placeHolder;
    }
}
