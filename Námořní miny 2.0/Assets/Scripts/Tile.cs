using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


//Zdroj: https://www.youtube.com/watch?v=kkAjpQAM-jE


public class Tile : MonoBehaviour
{
    [SerializeField] private GameObject highlight;
    [SerializeField] private Sprite spriteTest;

    public Vector2 Souradnice { get; private set; }
    public new SpriteRenderer renderer; //Vytváøí instanci SpriteRenderer

    public void NastavitSouradnice(Vector2 souradnice)
    {
        this.Souradnice = souradnice;
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
        this.NakliknutiLodi();
        return;
    }

    private void NakliknutiLodi()
    {
        renderer.sprite = spriteTest;
        GridManager gm = GameObject.Find("GridManager").GetComponent<GridManager>();
        Tile policko = gameObject.AddComponent<Tile>();
        policko = gm.VratitPolickoNaPozici(new Vector2((float)this.Souradnice.x + 1, (float)this.Souradnice.y), 1);
        policko.renderer.sprite = spriteTest;
        policko = gm.VratitPolickoNaPozici(new Vector2((float)this.Souradnice.x - 1, (float)this.Souradnice.y), 1);
        policko.renderer.sprite = spriteTest;

        highlight.SetActive(false);
        return;
    }

}
