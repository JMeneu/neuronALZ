/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: MIGUEL PEREZ MATEO
// # Date: 30/09/2021
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script maneja la información almacenada en la lista de usuarios.
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using System.IO;    
using UnityEngine;

public class FileManager : MonoBehaviour
{   
    public DatosUsuarios data;
    public string a;
    // Start is called before the first frame update
    //void Start()  {  
    //}

    public void WriteFile(string data){
        string filename = "UserList.json"; // En un futuro esto debería ser un parámetro
        //Debug.Log(data);
        //string json = JsonUtility.ToJson(data); // Esta función toma un objeto con campos y lo traduce a JSON
        string json = data; // a eliminar
        //Debug.Log(json);
        string path = GetFilePath(filename); 
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using(StreamWriter writer = new StreamWriter(fileStream)){
            writer.Write(json);
        }
        //Debug.Log("El archivo ha sido escrito");
    }

    public string ReadFile(string filename){
        string json;
        data = new DatosUsuarios();
        string path = GetFilePath(filename);
        if(File.Exists(path)){
            //Debug.Log("El archivo existe");    
            using(StreamReader reader = new StreamReader(path)){
                json = reader.ReadToEnd();
                //Debug.Log("Y contiene");    
                //Debug.Log(json);    
            }
        }
        else{
            //Debug.LogWarning("El archivo especificado no existe");
            json = "";
        }
        
        return json;
        // JsonUtility.FromJsonOverwrite(json, data); // Esta función sobreescribe datos en un objeto (data) A partir de la info que contiene json
        // En un futuro debemos asignarla a un vector de Usuarios, y no simplemente a un único objeto "DatosUsuarios"
    }

    private string GetFilePath(string filename){
        //Debug.Log(Application.persistentDataPath);
        return Application.persistentDataPath + "/" + filename;
    }
    
}
