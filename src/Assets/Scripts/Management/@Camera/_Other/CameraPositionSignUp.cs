using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionSignUp : MonoBehaviour
{
    [Header("Elementos UI")]
    [SerializeField]
    private GameObject _mainCamera;
    [Header("Variables")]
    private Vector3 _origin0 = new Vector3(0f,0f,-10f), _origin1 = new Vector3(28.2f,0f,-10f), _origin2 = new Vector3(56.4f,0f,-10f);
    public void gotoPanel(int _panelIndex)
    {
        if(_panelIndex == 0)
        {
            _mainCamera.transform.position = _origin0;
        }
        else if(_panelIndex == 1)
        {
            _mainCamera.transform.position = _origin1;
        }
        else if(_panelIndex == 2)
        { 
            _mainCamera.transform.position = _origin2;
        }
        else if(_panelIndex == 3)
        {

        }
        
    }
}
