using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;


//Zdroj: https://www.youtube.com/watch?v=kkAjpQAM-jE


public class Tile : MonoBehaviour
{
    [SerializeField] private GameObject highlight;
    [SerializeField] private Sprite spriteTest;

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
        ShipManager shipManager = GameObject.FindObjectOfType(typeof(ShipManager)) as ShipManager;
        shipManager.NakliknoutLod(Souradnice.x, Souradnice.y, 3, true);
    }
}
