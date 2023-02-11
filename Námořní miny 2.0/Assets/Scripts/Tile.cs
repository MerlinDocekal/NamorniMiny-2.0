using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


//Zdroj: https://www.youtube.com/watch?v=kkAjpQAM-jE


public class Tile : MonoBehaviour
{
    [SerializeField] private GameObject highlight;
    [SerializeField] private Sprite spriteTest;

    public int SouradniceX { get; private set; }
    public int SouradniceY { get; private set; }

    public new SpriteRenderer renderer; //Vytváøí instanci SpriteRenderer


    public void NastavitSouradnice(int x, int y)
    {
        this.SouradniceX = x;
        this.SouradniceY = y;
        return;
    }

    private void Start()
    {
        renderer = this.GetComponent<SpriteRenderer>(); //Nacpe do instance SpriteRenderer prefabu Tile
        return;
    }

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
        return;
    }

    private void OnMouseExit()
    { 
        highlight.SetActive(false);
        return;
    }

    private void OnMouseDown()
    {
        renderer.sprite = spriteTest;




        highlight.SetActive(false);
        return;
    }

    private void NakliknutiLodi()
    {
        return;
    }

}
