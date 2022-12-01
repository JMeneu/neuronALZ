using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ButtonColorHandler: MonoBehaviour
{
    [SerializeField]
    private Color _color;
    [SerializeField]
    private bool _isButtonWhite;
    private IButtonColorHandlerDown _defaultDown;
    private IButtonColorHandlerUp _defaultUp;

    private void Awake(){

        _defaultDown= GetComponent<DefaultDown>();
        _defaultUp= GetComponent<DefaultUp>();
    }
    public void PointerDown()
    {
        _defaultDown.PointerDown(_color,_isButtonWhite);
    }

    public void PointerUp()
    {
        _defaultUp.PointerUp(_color, _isButtonWhite);
    }
}
