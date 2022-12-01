using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefaultCalculate : MonoBehaviour, IAspectRatioHandlerCalculate
{
    public float Calculate()
    {
        return((float)((float)(Display.main.systemWidth) / (float)(Display.main.systemHeight)));
    }
}
