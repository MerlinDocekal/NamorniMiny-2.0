using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    /// <summary>
    /// 1 - umístit loï; 2 - umístit minu
    /// </summary>
    public int PozadovanaAkceProTileOnClick { get; set; }
    public int pozadovanaVelikostLodiProTileOnClick = 0;
    public bool jePozadovanaRotaceLodiHorizontalne = true;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        PozadovanaAkceProTileOnClick = 1;
    }

    public void buttonPrepnoutHrace()
    {
        PlayerManager.Instance.PrepnoutHrace();
    }

    public void buttonRotaceLodi()
    {
        jePozadovanaRotaceLodiHorizontalne = !jePozadovanaRotaceLodiHorizontalne;
    }

    public void buttonUmistitLod1()
    {
        PozadovanaAkceProTileOnClick = 1;
        pozadovanaVelikostLodiProTileOnClick = 1;
    }

    public void buttonUmistitLod3()
    {
        PozadovanaAkceProTileOnClick = 1;
        pozadovanaVelikostLodiProTileOnClick = 3;
    }

    public void buttonUmistitLod5()
    {
        PozadovanaAkceProTileOnClick = 1;
        pozadovanaVelikostLodiProTileOnClick = 5;
    }

    public void buttonUmistitLod7()
    {
        PozadovanaAkceProTileOnClick = 1;
        pozadovanaVelikostLodiProTileOnClick = 7;
    }

    public void buttonUmistitMinu()
    {
        PozadovanaAkceProTileOnClick = 2;
    }
}
