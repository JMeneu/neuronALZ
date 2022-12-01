using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractionModule : MonoBehaviour
{
    private PanelModule _panelModule;
    public float _timer;
    private float _interaction;
    [SerializeField]
    private GameObject _object;

    private void Awake()
    {
        _panelModule= GetComponent<PanelModule>();
    }
    private void Start()
    {
        _interaction = Time.realtimeSinceStartup;
        _panelModule.Demo();

    }
    private void Update()
    {
        if (Input.anyKey)
        {
            _interaction = Time.realtimeSinceStartup;
        }
        else
        {
            if ((Time.realtimeSinceStartup - _interaction) > _timer)
            {
                _panelModule.Demo();
            }

        }
    }
}
