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

    /// <summary>
    /// Vytvoøí loï na požadovaných souøadnicích.
    /// </summary>
    /// <param name="x">Souøadnice x.</param>
    /// <param name="y">Souøadnice y.</param>
    /// <param name="velikostLodi">Požadovaná velikost lodi (1, 3, 5, 7).</param>
    /// <param name="jeLodHorizontalne">Zda-li má být loï rotována.</param>
    /// <param name="cisloGridu">Èíslo Gridu (1, 2)</param>
    /// 


    bool jeLodHorizontalne = true;
    public void Rotace1()
    {
        jeLodHorizontalne = false;
        Debug.Log("Lod se otocila");
    }
    public void Rotace2()
    {
        jeLodHorizontalne = false;
        Debug.Log("Lod se otocila");
    }

    public void NaklikavaniLodeA1()
    {
        NakliknoutLod(10, 10, 1, jeLodHorizontalne, 1);
    }
    public void NaklikavaniLodeB1()
    {
        NakliknoutLod(10, 10, 1, jeLodHorizontalne, 2);
    }
    public void NaklikavaniLodeA3()
    {
        NakliknoutLod(10, 10, 3, jeLodHorizontalne, 1);
    }
    public void NaklikavaniLodeB3()
    {
        NakliknoutLod(10, 10, 3, jeLodHorizontalne, 2);
    }
    public void NaklikavaniLodeA5()
    {
        NakliknoutLod(10, 10, 5, jeLodHorizontalne, 1);
    }
    public void NaklikavaniLodeB5()
    {
        NakliknoutLod(10, 10, 5, jeLodHorizontalne, 2);
    }
    public void NaklikavaniLodeA7()
    {
        NakliknoutLod(10, 10, 7, jeLodHorizontalne, 1);
    }
    public void NaklikavaniLodeB7()
    {
        NakliknoutLod(10, 10, 7, jeLodHorizontalne, 2);
    }
    public void NakliknoutLod(float x, float y, int velikostLodi, bool jeLodHorizontalne, int cisloGridu)
    {
        Quaternion quaternion;
        bool neniMimoHraniceGridu;
        bool nekolidujeSLodi;

        if (jeLodHorizontalne)
        {
            quaternion = Quaternion.Euler(new Vector3(0, 0, 90));
            neniMimoHraniceGridu = ((x % 23) + velikostLodi / 2) <= 19 && ((x % 23) - velikostLodi / 2) >= 0;

            LayerMask mask = LayerMask.GetMask("Lode");
            if (Physics2D.Raycast(new Vector2((x - ((float)velikostLodi / 2)), y), new Vector2(1, 0), velikostLodi, mask).collider == null)
            {
                nekolidujeSLodi = true;
            }
            else
            {
                nekolidujeSLodi = false;
            }
        }
        else
        {
            quaternion = Quaternion.identity;
            neniMimoHraniceGridu = ((y + velikostLodi / 2) <= 19 && (y - velikostLodi / 2) >= 0);

            LayerMask mask = LayerMask.GetMask("Lode");
            if (Physics2D.Raycast(new Vector2(x, (y - ((float)velikostLodi / 2))), new Vector2(0, 1), velikostLodi, mask).collider == null)
            {
                nekolidujeSLodi = true;
            }
            else
            {
                nekolidujeSLodi = false;
            }

        }

        if (neniMimoHraniceGridu && nekolidujeSLodi)
        {

            switch (velikostLodi)
            {
                case 1:
                    Lod lod = Instantiate(lodPrefab1, new Vector3(x, y, -1), quaternion);
                    if (cisloGridu == 1)
                    {
                        lodeVelikost1Grid1[new Vector2(x, y)] = lod;
                    }
                    else
                    {
                        lodeVelikost1Grid2[new Vector2(x, y)] = lod;
                    }
                    break;
                case 3:
                    lod = Instantiate(lodPrefab3, new Vector3(x, y, -1), quaternion);
                    if (cisloGridu == 1)
                    {
                        lodeVelikost3Grid1[new Vector2(x, y)] = lod;
                    }
                    else
                    {
                        lodeVelikost3Grid2[new Vector2(x, y)] = lod;
                    }
                    break;
                case 5:
                    lod = Instantiate(lodPrefab5, new Vector3(x, y, -1), quaternion);
                    if (cisloGridu == 1)
                    {
                        lodeVelikost5Grid1[new Vector2(x, y)] = lod;
                    }
                    else
                    {
                        lodeVelikost5Grid2[new Vector2(x, y)] = lod;
                    }
                    break;
                case 7:
                    lod = Instantiate(lodPrefab7, new Vector3(x, y, -1), quaternion);
                    if (cisloGridu == 1)
                    {
                        lodeVelikost7Grid1[new Vector2(x, y)] = lod;
                    }
                    else
                    {
                        lodeVelikost7Grid2[new Vector2(x, y)] = lod;
                    }
                    break;

                default:
                    break;
            }
            Debug.Log("Lod vytvoøena");
        }
        else
        {
            Debug.Log("Lod nevytvoøena");
        }
    }
}
