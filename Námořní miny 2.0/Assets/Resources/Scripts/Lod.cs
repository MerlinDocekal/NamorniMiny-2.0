using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Lod : MonoBehaviour
{
    public int Velikost { get; private set; }
    public bool RotovanoHorizontalne { get; private set; }
    private int hp;
    private bool znicena = false;
    private float x;
    private float y;

    public void NastavitLod(int velikost, bool rotovanoHorizontalne, float x, float y)
    {
        this.Velikost = velikost;
        this.RotovanoHorizontalne = rotovanoHorizontalne;
        this.x = x;
        this.y = y;
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


            Lod lod = ShipManager.Instance.lodeGrid2Dic[new Vector2(this.x, this.y)];
            if (lod.Velikost == 1)
            {
                lod.GetComponent<SpriteRenderer>().sprite = ShipManager.Instance.lodZnicenaSprite1;
            }
            else if (lod.Velikost == 3)
            {
                lod.GetComponent<SpriteRenderer>().sprite = ShipManager.Instance.lodZnicenaSprite3;
            }

            if (PlayerManager.Instance.HrajeHrac1)
            {
                ShipManager.Instance.lodeGrid2Dic.Remove(new Vector2(this.x, this.y));
                if(ShipManager.Instance.lodeGrid2Dic.Count == 0)
                {
                    Debug.Log("První hráè vítìzí!");
                }
            }
            else
            {
                ShipManager.Instance.lodeGrid1Dic.Remove(new Vector2(this.x, this.y));
                if (ShipManager.Instance.lodeGrid1Dic.Count == 0)
                {
                    Debug.Log("Druhý hráè vítìzí!");
                }
            }
        }
    }
}
