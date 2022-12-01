using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Loading_Spinner : MonoBehaviour
{
    [Header("Renderizador de sprites")]
    public Image spriteRenderer;
    public Sprite[] spriteArray;
    public float timer = 0.0f;
    public int centiseconds;
    public Text Banner;
    public Text subs;
    public GameObject Continuar;
    public string title;
    public string sub;
    void Start()
    {
        spriteRenderer = GetComponent<Image>();
        timer = 0;
        centiseconds = 0;
        title=Banner.text;
        sub=subs.text;
    }

    void Update()
    {
        //Time.timeScale = 1f;
        timer += (Time.deltaTime);
        centiseconds = (int)((timer*50) % 50);
        Debug.Log(centiseconds);
        if (timer >= 5)
        {
            ChangeSprite(spriteArray[50]);
            Banner.text = "¡Ya está!";
            subs.text = "Pulsa Continuar para comenzar.";
            Continuar.SetActive(true);
            timer = 0;
            centiseconds = 0;
            Banner.text = title;
            subs.text = sub;
        }
        else if (centiseconds == spriteArray.Length - 1)
        {
            timer = 0;
            centiseconds = 0;
            ChangeSprite(spriteArray[centiseconds]);
        }
        else
        {
            ChangeSprite(spriteArray[centiseconds]);
        }
    }

    void ChangeSprite(Sprite example)
    {
        spriteRenderer.sprite = example;
    }
}
