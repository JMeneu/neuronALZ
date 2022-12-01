using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class DefaultPhotoFitter : MonoBehaviour,ICameraHandlerPhotoFitter
{
    private Texture2D aux;
    public Texture2D PhotoRotateFit(Texture2D _texture, bool clockwise, int rotationAngle)
    {
        int local_angle = 0;
        while (rotationAngle > local_angle)
        {
            Color32[] original = _texture.GetPixels32();
            Color32[] rotated = new Color32[original.Length];
            int w = _texture.width;
            int h = _texture.height;
            int iRotated, iOriginal;
            for (int j = 0; j < h; ++j)
            {
                for (int i = 0; i < w; ++i)
                {
                    iRotated = (i + 1) * h - j - 1;
                    iOriginal = clockwise ? original.Length - 1 - (j * w + i) : j * w + i;
                    rotated[iRotated] = original[iOriginal];
                }
            }
            Texture2D rotatedTexture = new Texture2D(h, w);
            rotatedTexture.SetPixels32(rotated);
            rotatedTexture.Apply();
            _texture = rotatedTexture;
            local_angle += 90;
            aux = rotatedTexture;
        }
        Debug.Log("Foto rotada!");
        return aux;
    }
}
