using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    private SceneModule _module;
    [SerializeField]
    private Text _title;
    private string _aux;

    private void Awake()
    {
        _module= GetComponent<SceneModule>();
    }
    private void Start()
    {
        StartCoroutine(LoadTitle());
    }

    private IEnumerator LoadTitle()
    {
        _aux=_module.ReadHistory();
        _title.GetComponent<UnityEngine.UI.Text>().text= _aux;
        yield return new WaitForSeconds(3);
        _module.Load(_aux,"parameter", SceneManagerPro.GetParameters("parameter"));
    }
}
