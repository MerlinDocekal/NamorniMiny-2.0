using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Lod : MonoBehaviour
{
    public int Velikost { get; set; }
    public bool RotovanoHorizontalne { get; set; }
    private int hp;
    private bool znicena = false;

    public void NastavitHP()
    {
        hp = Velikost;
    }

    public void ZasahnoutLod()
    {
        hp--;
        Debug.Log("HP: " + hp);
        if(hp == 0 )
        {
            znicena = true;
            Debug.Log("Loï znièena.");
        }
    }
}
