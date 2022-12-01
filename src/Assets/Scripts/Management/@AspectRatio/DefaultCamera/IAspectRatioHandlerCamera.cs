using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IAspectRatioHandlerCamera
{
    public Vector3 SetPosition(float _aspectRatio);
    public Vector3 SetPosition();
    public float SetSize(float _aspectRatio);
    public float SetSize();
}
