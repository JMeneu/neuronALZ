using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DefaultUp : MonoBehaviour,IButtonColorHandlerUp
{
    public void PointerUp(Color _color, bool _isWhite)
    {
        if (_isWhite)
        {
            GetComponentInChildren<Text>().color = _color;
        }
        else
        {
            GetComponentInChildren<Text>().color = Color.white;
        }
    }
}
