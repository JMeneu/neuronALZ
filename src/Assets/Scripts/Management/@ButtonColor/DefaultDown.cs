using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DefaultDown : MonoBehaviour, IButtonColorHandlerDown
{
    public void PointerDown(Color _color, bool _isWhite)
    {
        if (_isWhite)
        {
            GetComponentInChildren<Text>().color = Color.white;
        }
        else
        {
            GetComponentInChildren<Text>().color = _color;
        }
    }
}
