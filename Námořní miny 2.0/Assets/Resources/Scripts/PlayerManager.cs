using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    public bool HrajeHrac1 { get; private set; }
    public bool fazeUmistovaniLodi = false;


    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        UmistovaniLodiHrace1();
        HrajeHrac1 = true;
    }

    public void PrepnoutHrace()
    {
        if (fazeUmistovaniLodi && HrajeHrac1)
        {
            UIManager.Instance.SkrytObrazovku();
        }
        else if(fazeUmistovaniLodi)
        {
            UIManager.Instance.SkrytObrazovku();
        }
        else
        {
            UIManager.Instance.SkrytObrazovku();
        }

        HrajeHrac1 = !HrajeHrac1;
    }

    public void UmistovaniLodiHrace1()
    {
        fazeUmistovaniLodi = true;
        GridManager.Instance.grid2.SetActive(false);
        UIManager.Instance.tlacitkaHrace2.SetActive(false);
        UIManager.Instance.buttonPrepnoutHrace_1.SetActive(false);
    }

    public void UmistovaniLodiHrace2()
    {
        GridManager.Instance.grid2.SetActive(true);

        ShipManager.Instance.lodeGrid2.SetActive(true);

        UIManager.Instance.UIManagerInit();
        UIManager.Instance.tlacitkaHrace2.SetActive(true);
        UIManager.Instance.buttonPrepnoutHrace_2.SetActive(false);
    }

    public void UkoncitFaziUmistovaniLodi()
    {
        HrajeHrac1 = true;
        GridManager.Instance.grid1.SetActive(true);
        GridManager.Instance.grid2.SetActive(true);

        ShipManager.Instance.lodeGrid1.SetActive(true);
        ShipManager.Instance.lodeGrid2.SetActive(true);
        ShipManager.Instance.SkrytLode(2);

        UIManager.Instance.buttonMina.SetActive(true);
        UIManager.Instance.tlacitkaHrace1.SetActive(true);
        UIManager.Instance.tlacitkaHrace2.SetActive(true);
        UIManager.Instance.buttonPrepnoutHrace_2.SetActive(false);
        UIManager.Instance.buttonPrepnoutHrace_1.SetActive(true);
    }
}
