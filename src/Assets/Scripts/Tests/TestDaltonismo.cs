/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 25/11/2021
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script define la l�gica del test de Daltonismo. 
//
// # Update:Ahora se presenta feedback al usuario mediante corutinas. El resultado de test establece de qu�
//   patolog�a es m�s probable que padezca el paciente, y guarda la informaci�n en RTDB.
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Analytics;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;


public class TestDaltonismo : MonoBehaviour
{
    [Header("Elementos UI")]
    [Header("Botones")]
    public Text button1;
    public Text button2;
    public Text button3;

    [Header("Textos")]
    public GameObject rondas_txt;

    [Header("Variables")]
    private static int rondas;
    private string opc1;
    private string opc2;
    private string opc3;
    public int okcounter;
    public int protanopiacounter;
    public int tritanopiacounter;
    public static string test_name;
    public string results;
    private static Dictionary<int, string> soluciones;

    [Header("Instancias")]
    public static TestDaltonismo instance;
    private InitModule _initModule;
    private DatabaseModule _module;
    private SceneModule _sceneModule;
    private StoreModule _storeModule;


    private void Awake()
    {
        instance = this;
        _initModule = GetComponent<InitModule>();
        _module = GetComponent<DatabaseModule>();
        _sceneModule = GetComponent<SceneModule>();
        _storeModule = GetComponent<StoreModule>();
    }

    void Start()
    {
        soluciones = new Dictionary<int, string>()
        {
            {1, "29"},
            {2, "5"},
            {3, "15"},
            {4, "6"},
            {5, "16"},
            {6, "NADA"},
            {7, "26"}
        };
        test_name = "Vision";
        Debug.Log(test_name);
        rondas = 0;
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        if (rondas == 7)
        {
            if (protanopiacounter > tritanopiacounter&&protanopiacounter>okcounter)
            {
                Debug.Log("PROTANOPIA");
                results ="Protanopia";
            }
            else if (tritanopiacounter > protanopiacounter &&tritanopiacounter>okcounter)
            {
                Debug.Log("TRITANOPIA");
                results = "Tritanopia";
            }
            else
            {
                Debug.Log("VISION NORMAL");
                results = "Normal";
            }
            rondas = 0;
            yield return new WaitForSeconds(1);
            _module.WriteTestData(PanelManager.instance.GetName(),test_name, results);
            _storeModule.WriteTestData(PanelManager.instance.GetName(),test_name, results);
            yield return new WaitForSeconds(2);
            _sceneModule.Load("MenuTest");
        }
        else
        {
            rondas++;
            rondas_txt.GetComponent<UnityEngine.UI.Text>().text = (rondas).ToString();
            switch (Random.Range(1, 4))
            {
                case 1:
                    opc1 = soluciones[rondas];
                    opc2 = "OTRO NÚMERO";
                    opc3 = "NADA";
                    if (opc1 == "NADA") opc3 = "5";

                    break;
                case 2:
                    opc1 = "OTRO NÚMERO";
                    opc2 = soluciones[rondas];
                    opc3 = "NADA";
                    if (opc2 == "NADA") opc3 = "5";
                    break;
                case 3:
                    opc1 = "NADA";
                    opc2 = "OTRO NÚMERO";
                    opc3 = soluciones[rondas];
                    if (opc3 == "NADA") opc1 = "5";
                    break;
            }
            button1.GetComponent<UnityEngine.UI.Text>().text = opc1;
            button2.GetComponent<UnityEngine.UI.Text>().text = opc2;
            button3.GetComponent<UnityEngine.UI.Text>().text = opc3;
            yield return null;  
        }

    }


    public void check_opt_1()
    {
        if (button1.text == soluciones[rondas])
        {
            okcounter++;
        }
        else if (button1.text == "OTRO NÚMERO")
        {
            protanopiacounter++;
        }
        else
        {
            tritanopiacounter++;
        }
        StartCoroutine(Generate());
    }

    public void check_opt_2()
    {
        if (button2.text == soluciones[rondas])
        {
            okcounter++;
        }
        else if (button2.text == "OTRO NÚMERO")
        {
            protanopiacounter++;
        }
        else
        {
            tritanopiacounter++;
        }
        StartCoroutine(Generate());
    }

    public void check_opt_3()
    {
        if (button3.text == soluciones[rondas])
        {
            okcounter++;
        }
        else if (button3.text == "OTRO NÚMERO")
        {
            protanopiacounter++;
        }
        else
        {
            tritanopiacounter++;
        }
        StartCoroutine(Generate());
    }

}