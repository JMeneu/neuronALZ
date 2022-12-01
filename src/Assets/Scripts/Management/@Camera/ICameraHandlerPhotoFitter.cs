using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public interface ICameraHandlerPhotoFitter
{
    public Texture2D PhotoRotateFit(Texture2D _texture, bool clockwise, int rotationAngle);
}
