/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: MIGUEL PEREZ MATEO
// # Date: 30/09/2021
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script maneja el listado de usuarios que figuran en Firebase, y los renderiza en pantalla.
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class userList : MonoBehaviour
{
    private string[] users = new string[] { "Matt", "Joanne", "Robert" };

    public RectTransform prefab;

    public ScrollRect scrollView;

    public RectTransform content;

    List<ExampleItemView> views = new List<ExampleItemView>();

    //private FileManager fileManager;

    // Start is called before the first frame update
    void Start()
    {
        //fileManager = GameObject.Find("FileManager").GetComponent<FileManager>();
        UpdateItems();
    }

    // Update is called once per frame
    public void UpdateItems()
    {
        StartCoroutine(FetchItemModelsFromServer(results =>
            OnReceivedNewModels(results)));
    }

    void OnReceivedNewModels(ExampleItemModel[] models)
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
        views.Clear();
        int i = 0;
        foreach (var model in models)
        {
            var instance = GameObject.Instantiate(prefab.gameObject) as GameObject;
            instance.transform.SetParent(content, false);
            var view = InitializeItemView(instance, model);
            views.Add (view);
            ++i;
        }
    }

    ExampleItemView InitializeItemView(GameObject viewGameObject, ExampleItemModel model)
    {
        ExampleItemView view = new ExampleItemView(viewGameObject.transform);

        view.titleText.text = model.title;

        // view.iconImage.texture  =
        return view;
    }

    IEnumerator FetchItemModelsFromServer(Action<ExampleItemModel[]> onDone)
    {
        // En un futuro esta función retornará los valores extraidos del fichero local de usuarios
        yield return new WaitForSeconds(2f);

        //string Users = fileManager.ReadFile("UserList.json");
        //Debug.Log(Users);
        //DatosUsuariosList DatosUList = JsonUtility.FromJson<DatosUsuariosList>(Users);
        //Debug.Log(DatosUList.usuarios[0].nombre);
        
        var results = new ExampleItemModel[10];
        // Aquí se decide el número de usuarios 
        for (int i = 0; i < 10; ++i)
        {
            results[i] = new ExampleItemModel();
            results[i].title = "Usuario: " + i;
        }

        onDone (results);
    }

    public class ExampleItemView
    {
        public Text titleText;

        // public RawImage profileImage;
        public ExampleItemView(Transform rootView)
        {
            titleText = rootView.Find("User Name").GetComponent<Text>();
            // iconImage = rootView.Find("Profile Pic").GetComponent<RawImage>();
        }
    }

    public class ExampleItemModel
    {
        public string title;
        // public RawImage profileImage;
    }

    [System.Serializable]
    public class DatosUsuariosList{
        //public List<DatosUsuarios> usuarios;
    }
}
