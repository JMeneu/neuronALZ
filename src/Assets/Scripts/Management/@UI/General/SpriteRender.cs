using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpriteRender : MonoBehaviour
{
    [Header("Renderizador de sprites")]
    public Image spriteRenderer;
    public Sprite[] spriteArray;
    public GameObject rounds;
    void Start()
    {
        spriteRenderer = GetComponent<Image>();
    }

    void Update()
    {
        ChangeSprite(spriteArray[int.Parse(rounds.GetComponent<UnityEngine.UI.Text>().text)-1]);
    }

    void ChangeSprite(Sprite example)
    {
        spriteRenderer.sprite = example;
    }
}
