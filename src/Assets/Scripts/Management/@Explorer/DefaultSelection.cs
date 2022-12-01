using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using NativeFilePickerNamespace;


public class DefaultSelection : MonoBehaviour, IFileSelectionHandler
{
	private string _path;
	public string SelectFile(string _extension)
	{
		if (NativeFilePicker.IsFilePickerBusy())
		{

		}
		else
		{
			string[] fileTypes = new string[] { _extension };
			NativeFilePicker.Permission permission = NativeFilePicker.PickFile((path) =>
			{
				if (path == null)
				{

				}
				else
				{
					_path = path;
					
				}

			}, fileTypes);
		}
		return _path;
	}
}
