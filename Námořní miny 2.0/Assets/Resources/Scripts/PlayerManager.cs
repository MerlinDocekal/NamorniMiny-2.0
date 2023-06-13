using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    public bool HrajeHrac1 { get; private set; }

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
        HrajeHrac1 = true;
        
        NaklikavaniLodiHrace1();
    }

    public void PrepnoutHrace()
    {
        HrajeHrac1 = !HrajeHrac1;
        Debug.Log("Hraje hr·Ë 1: " + HrajeHrac1);

        if(HrajeHrac1)
        {
            ShipManager.Instance.SkrytLode(2);
            ShipManager.Instance.ZobrazitLode(1);
        }
        else
        {
            ShipManager.Instance.SkrytLode(1);
            ShipManager.Instance.ZobrazitLode(2);
        }
    }

    private void NaklikavaniLodiHrace1()
    {
        GameObject.Find("Grid2").SetActive(false);
        GameObject.Find("TlacitkaHrace2").SetActive(false);
        GameObject.Find("ButtonPrepnoutHrace_1").SetActive(false);
    }

    private void NaklikavaniLodiHrace2()
    {
        GameObject.Find("Grid1").SetActive(false);
        GameObject.Find("TlacitkaHrace1").SetActive(false);
    }
}
