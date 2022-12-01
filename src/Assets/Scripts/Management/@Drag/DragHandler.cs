using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragHandler:MonoBehaviour
{
    private IInputHandler _defaultInput;
    private ICameraHandler _defaultPointCamera;
    private IPositionHandler _defaultPosition;

    private void Awake(){
        _defaultInput=GetComponent<DefaultInput>();
        _defaultPointCamera=GetComponent<DefaultPointCamera>();
        _defaultPosition=GetComponent<DefaultPosition>();
    }

    public void Drag(GameObject _object)
    {
        var _input = _defaultInput.ReadInput();
        var _cameraPosition = _defaultPointCamera.MoveCamera(_input);
        _defaultPosition.MoveObject(_object, _cameraPosition);
    }
}
