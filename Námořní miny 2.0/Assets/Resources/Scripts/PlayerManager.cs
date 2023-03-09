using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Lod lodPrefab1;
    [SerializeField] private Lod lodPrefab3;
    [SerializeField] private Lod lodPrefab5;
    [SerializeField] private Lod lodPrefab7;

    public Dictionary<Vector2, Lod> lodeVelikost1Grid1 = new Dictionary<Vector2, Lod>();
    public Dictionary<Vector2, Lod> lodeVelikost3Grid1 = new Dictionary<Vector2, Lod>();
    public Dictionary<Vector2, Lod> lodeVelikost5Grid1 = new Dictionary<Vector2, Lod>();
    public Dictionary<Vector2, Lod> lodeVelikost7Grid1 = new Dictionary<Vector2, Lod>();

    public Dictionary<Vector2, Lod> lodeVelikost1Grid2 = new Dictionary<Vector2, Lod>();
    public Dictionary<Vector2, Lod> lodeVelikost3Grid2 = new Dictionary<Vector2, Lod>();
    public Dictionary<Vector2, Lod> lodeVelikost5Grid2 = new Dictionary<Vector2, Lod>();
    public Dictionary<Vector2, Lod> lodeVelikost7Grid2 = new Dictionary<Vector2, Lod>();


    ShipManager shipManager;
    public void Awake()
    {
        shipManager = GameObject.FindObjectOfType<ShipManager>() as ShipManager;
    }

    public void Rotace1()
    {
        shipManager.rotace = !shipManager.rotace;
    }

    public void NaklikavaniLodeA1()
    {
        shipManager.velikostLodi = 1;
        shipManager.grid = 1;
    }
    public void NaklikavaniLodeB1()
    {
        shipManager.velikostLodi = 1;
        shipManager.grid = 2;
    }
    public void NaklikavaniLodeA3()
    {
        shipManager.velikostLodi = 3;
        shipManager.grid = 1;
    }
    public void NaklikavaniLodeB3()
    {
        shipManager.velikostLodi = 3;
        shipManager.grid = 2;
    }
    public void NaklikavaniLodeA5()
    {
        shipManager.velikostLodi = 5;
        shipManager.grid = 1;
    }
    public void NaklikavaniLodeB5()
    {
        shipManager.velikostLodi = 5;
        shipManager.grid = 2;
    }
    public void NaklikavaniLodeA7()
    {
        shipManager.velikostLodi = 7;
        shipManager.grid = 1;
    }
    public void NaklikavaniLodeB7()
    {
        shipManager.velikostLodi = 7;
        shipManager.grid = 1;
    }
}
