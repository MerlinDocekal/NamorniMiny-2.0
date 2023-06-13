using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    /// <summary>
    /// 1 - umístit loï; 2 - umístit minu
    /// </summary>
    public int PozadovanaAkceProTileOnClick { get; set; }
    public int pozadovanaVelikostLodiProTileOnClick = 0;
    public bool jePozadovanaRotaceLodiHorizontalne = true;

    private int pocetLodi1VeFaziUmisteni;
    private int pocetLodi3VeFaziUmisteni;
    private int pocetLodi5VeFaziUmisteni;
    private int pocetLodi7VeFaziUmisteni;

    public bool umoznenoUmisteniLode1;
    public bool umoznenoUmisteniLode3;
    public bool umoznenoUmisteniLode5;
    public bool umoznenoUmisteniLode7;

    private GameObject buttonPrepnoutHrace_1;

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

        pocetLodi1VeFaziUmisteni = 5;
        pocetLodi3VeFaziUmisteni = 4;
        pocetLodi5VeFaziUmisteni = 3;
        pocetLodi7VeFaziUmisteni = 2;

        umoznenoUmisteniLode1 = true;
        umoznenoUmisteniLode3 = true;
        umoznenoUmisteniLode5 = true;
        umoznenoUmisteniLode7 = true;

        buttonPrepnoutHrace_1 = GameObject.Find("ButtonPrepnoutHrace_1");
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

    public void UmistenaLod(int velikostLodi, int cisloGridu)
    {
        bool dosazenoLimituLode = false;
        switch(velikostLodi)
        {
            case 1:
                pocetLodi1VeFaziUmisteni--;
                if(pocetLodi1VeFaziUmisteni == 0 )
                {
                    dosazenoLimituLode = true;
                    umoznenoUmisteniLode1 = false;
                }
                break;
            case 3:
                pocetLodi3VeFaziUmisteni--;
                if (pocetLodi3VeFaziUmisteni == 0)
                {
                    dosazenoLimituLode = true;
                    umoznenoUmisteniLode3 = false;
                }
                break;
            case 5:
                pocetLodi5VeFaziUmisteni--;
                if (pocetLodi5VeFaziUmisteni == 0)
                {
                    dosazenoLimituLode = true;
                    umoznenoUmisteniLode5 = false;
                }
                break;
            case 7:
                pocetLodi7VeFaziUmisteni--;
                if (pocetLodi7VeFaziUmisteni == 0)
                {
                    dosazenoLimituLode = true;
                    umoznenoUmisteniLode7 = false;
                }
                break;
            default:
                break;
        }

        if(dosazenoLimituLode)
        {
            string nazev = "ButtonUmistitLod" + velikostLodi + "_" + cisloGridu;
            GameObject.Find(nazev).SetActive(false);
            if((pocetLodi1VeFaziUmisteni + pocetLodi3VeFaziUmisteni + pocetLodi5VeFaziUmisteni + pocetLodi7VeFaziUmisteni) == 0)
            {
                buttonPrepnoutHrace_1.SetActive(true);
            }
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("GameScreen");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("ukonèení hry");
    }
}