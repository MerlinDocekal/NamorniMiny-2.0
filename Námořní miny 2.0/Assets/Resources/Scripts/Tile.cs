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

    public int CisloGridu { get; set; }
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
        switch (UIManager.Instance.PozadovanaAkceProTileOnClick)
        {
            case 0:
                break;
            case 1:
                ShipManager.Instance.UmistitLod(Souradnice.x, Souradnice.y, UIManager.Instance.pozadovanaVelikostLodiProTileOnClick, UIManager.Instance.jePozadovanaRotaceLodiHorizontalne, CisloGridu);
                break;
            case 2:
                GridManager.Instance.UmistitMinu(Souradnice.x, Souradnice.y, CisloGridu);
                break;
        }
    }
}
