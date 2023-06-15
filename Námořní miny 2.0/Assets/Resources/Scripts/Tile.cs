using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


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
                if (!UIManager.Instance.vypalenaMina)
                {
                    GridManager.Instance.UmistitMinu(Souradnice.x, Souradnice.y, CisloGridu);
                }
                break;
        }
    }
}
