/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 25/11/2021
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script establece la gama de colores a emplear, atendiendo a las capacidades visuales.
//   La informaci�n es le�da durante el Login, de los datos de RTDB.
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorBlindnessAdapter : MonoBehaviour
{
    [Header("Elementos UI")]
    [Header("Materiales")]
    public Material red;
    public Material blue;
    public Material green;
    public Material orange;
    public Material yellow;
    public Material light_blue;
    public Material dark_blue;
    public Material dark_red;

    [Header("Variables")]
    private Color userColor;

    
    private Color _userColor;

    private Dictionary<Material, string> Colors;

    public void ReadVision(string _vision)
    {
        if(_vision=="Normal")
        {
            Colors=new Dictionary<Material, string>
            {
                {red, "#F83E3E" },
                {green, "#5ACE74" },
                {blue, "#016BA5" },
                {yellow, "#FFEB04" },
                {orange, "#E7A703" },
                {light_blue, "#0C92D9" },
                {dark_blue, "#0000FF" },
                {dark_red, "#FF0000" }
            };
            SetColors(Colors);
        }
        else if(_vision== "Protanopia"){

            Colors=new Dictionary<Material, string>
            {
                {red, "#786719" },
                {green, "#4C83F7" },
                {blue, "#0059E3" },
                {yellow, "#FFF000" },
                {orange, "#D4BC12" },
                {light_blue, "#0059E3" },
                {dark_blue, "#0059E3" },
                {dark_red, "#786719" }
            };
            SetColors(Colors);

            
        }
        else if(_vision=="Deuteranopia")
        {
            Colors=new Dictionary<Material, string>
            {
                {red, "#BBA300" },
                {green, "#665944" },
                {blue, "#2017FF" },
                {yellow, "#FFE104" },
                {orange, "#CCB200" },
                {light_blue, "#554A87" },
                {dark_blue, "#554A87" },
                {dark_red, "#BBA300" }
            };
            SetColors(Colors);
        }
        else if(_vision=="Tritanopia")
        {
            Colors=new Dictionary<Material, string>
            {
                {red, "#E40303" },
                {green, "#007575" },
                {blue, "#582929" },
                {yellow, "#FFE0E0" },
                {orange, "#FF7373" },
                {light_blue, "#582929" },
                {dark_blue, "#582929" },
                {dark_red, "#E40303" }
            };
            SetColors(Colors);
        }
        else
        {
            Colors=new Dictionary<Material, string>
            {
                {red, "#F83E3E" },
                {green, "#5ACE74" },
                {blue, "#016BA5" },
                {yellow, "#FFEB04" },
                {orange, "#E7A703" },
                {light_blue, "#0C92D9" },
                {dark_blue, "#0000FF" },
                {dark_red, "#FF0000" }
            };
            SetColors(Colors);
        }

    }

    public void SetColors(Dictionary<Material, string> _colors)
    {
        foreach (var _color in _colors){
            ColorUtility.TryParseHtmlString(_color.Value, out _userColor);
            _color.Key.SetColor("_Color", _userColor);
        }
    }
}
