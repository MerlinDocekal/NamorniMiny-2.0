using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;


//Zdroj: https://www.youtube.com/watch?v=kkAjpQAM-jE


public class Tile : MonoBehaviour
{
    [SerializeField] private GameObject highlight;
    [SerializeField] private Sprite spriteTest;
    [SerializeField] private Lod lodPrefab;

    private ShipManager shipManager;
    public Vector2 Souradnice { get; private set; }

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
        //shipManager = gameObject.AddComponent<ShipManager>();
        //shipManager.NakliknutiLodi((int)Souradnice.x, (int)Souradnice.y);
        Instantiate(lodPrefab, new Vector3(Souradnice.x, Souradnice.y, -1), Quaternion.identity); //Quaternion.Euler(0, 0, 90) otoèí o 90°
        return;
    }
}
