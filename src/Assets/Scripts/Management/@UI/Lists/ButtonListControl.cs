/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 15/11/2021
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script define la l�gica entorno a la instanciaci�n de botones en el listado de pacientes, 
//   y maneja su posterior destrucci�n.
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonListControl : MonoBehaviour
{
    [Header("Elementos UI")]
    public GameObject buttonTemplate;
    private static List<GameObject> buttons = new List<GameObject>();
    [Header("Instancias")]
    public static ButtonListControl instance;
    private DatabaseModule _databaseModule;
    private void Awake()
    {
        _databaseModule= GetComponent<DatabaseModule>();
        instance = this;
    }
    private void Start()
    {
        StartCoroutine(StartupCoroutine());
    }
    public IEnumerator StartupCoroutine()
    {
        yield return StartCoroutine(GenerateCoroutine());
    }

    public IEnumerator GenerateCoroutine()
    {
        yield return StartCoroutine(_databaseModule.ReadUsersTotalAmountCoroutine());
        Clear();

        for(int i = 0; i < _databaseModule.GetList().Count; i++)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            button.GetComponent<ButtonListButton>().SetText(_databaseModule.GetList()[i]);
            button.transform.SetParent(buttonTemplate.transform.parent, false);
            buttons.Add(button);
        }

    }
    

    public void Clear()
    {
        if (buttons.Count > 0)
        {
            foreach (GameObject button in buttons)
            {
                Debug.Log("Destruyendo...");
                Destroy(button.gameObject);
            }
                    _databaseModule.GetList().Clear();
                    buttons.Clear();
        }
        else
        {
            Debug.Log("Nada que destruir...");
        }


    }


}
