using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class DefaultSetup : MonoBehaviour,ICameraHandlerSetup
{
    public WebCamDevice[] CameraExistance(GameObject _text)
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length == 0)
        {
            Debug.Log("No se ha detectado ninguna cámara!");
            _text.GetComponent<UnityEngine.UI.Text>().text = "No se ha detectado ninguna cámara en este dispositivo.";
        }
        return devices;
    }

    public WebCamTexture CameraSet(WebCamDevice[] webcamDevices, RawImage _background, WebCamTexture _webCamTexture, bool _camAvailable)
    {
        for(int i=0; i<webcamDevices.Length; i++)
        {
            if(webcamDevices[i].isFrontFacing){
                _webCamTexture = new WebCamTexture(webcamDevices[i].name, Screen.width, Screen.height);
                Debug.Log("hey");
            }
        }
        if(_webCamTexture == null)
        {
            Debug.Log("No se ha encontrado ninguna cámara frontal");
        } 
        _webCamTexture.Play();
        _background.texture = _webCamTexture;
        _camAvailable = true;

        RenderTexture PhotoTaken = new RenderTexture(_webCamTexture.width, _webCamTexture.height,0); 
        Graphics.Blit(_webCamTexture, PhotoTaken);
        return _webCamTexture;
    }



    public bool CameraStatus(WebCamTexture _webCamTexture, bool _camAvailable)
    {
        if (_webCamTexture == null)
        {
            _camAvailable = false;
            return false;
        }
        else
        {
            _camAvailable = true;
            return true;
        }
    }
}