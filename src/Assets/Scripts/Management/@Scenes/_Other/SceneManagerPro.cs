/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 14/10/2021
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script define la l�gica sobrecargada de SceneManager, para aplicarlo exclusivamente en la
//   carga de escenas que requieren par�metros (juegos y sus niveles). Para ello, se sobrecarga la funci�n Load()
//   y se crea un diccionario de tipo <string, int>, donde la key ser� el nombre de la variable y el value, el nivel.
//   Se dispone de los m�todos Get y Set para obtenrr y aplicar los par�metros deseados.
//   Es el �nico script que describe una clase que no hereda de Monobehaviour, y en la que todos sus miembros
//   y la propia clase son est�ticas para permitir un acceso continuo y global.
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneManagerPro
{
    private static Dictionary<string, int> parameters;
    public static string GetActiveSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
    public static void Load(string name)
    {
        SceneManager.LoadScene(name);
    }
    public static void Load(string name, string key, int value)
    {
        SetParameters(key, value);
        SceneManager.LoadScene(name);
    }
    public static Dictionary<string, int> GetSceneParameters()
    {
        return parameters;
    }

    public static int GetParameters(string key)
    {
        if (parameters == null || !parameters.ContainsKey(key))
        {
            return 0;
        }
        else
        {
            return parameters[key];
        }
    }
    public static void SetParameters(string key, int value)
    {
        if (parameters == null)
        {
            parameters = new Dictionary<string, int>();
        }
        if (parameters.ContainsKey(key))
        {
            parameters.Remove(key);
        }
       parameters.Add(key, value);
    }

}
