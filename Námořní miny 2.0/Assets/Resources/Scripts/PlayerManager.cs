using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    public bool HrajeHrac1 { get; private set; }
    private ShipManager shipManager;

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
        HrajeHrac1 = true;
        shipManager = GameObject.FindObjectOfType(typeof(ShipManager)) as ShipManager;
    }

    public void PrepnoutHrac()
    {
        HrajeHrac1 = !HrajeHrac1;
        Debug.Log("Hraje hr·Ë 1: " + HrajeHrac1);

        if(HrajeHrac1)
        {
            shipManager.SkrytLode(2);
            shipManager.ZobrazitLode(1);
        }
        else
        {
            shipManager.SkrytLode(1);
            shipManager.ZobrazitLode(2);
        }
    }
}
