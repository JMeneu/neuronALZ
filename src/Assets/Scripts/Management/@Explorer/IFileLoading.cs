using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using NativeFilePickerNamespace;


public interface IFileLoading
{
    public IEnumerator Load(string _path, RawImage _rawImage);
    public RawImage LoadFile(string _path, RawImage _rawImage);
}
