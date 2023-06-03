using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    public static ShipManager Instance { get; private set; }

    [SerializeField] private Lod lodPrefab1;
    [SerializeField] private Lod lodPrefab3;
    [SerializeField] private Lod lodPrefab5;
    [SerializeField] private Lod lodPrefab7;

    public Dictionary<Vector2, Lod> lodeGrid1 = new Dictionary<Vector2, Lod>();
    public Dictionary<Vector2, Lod> lodeGrid2 = new Dictionary<Vector2, Lod>();
    //public Dictionary<Vector2, Lod> lodeVelikost1Grid1 = new Dictionary<Vector2, Lod>();
    //public Dictionary<Vector2, Lod> lodeVelikost3Grid1 = new Dictionary<Vector2, Lod>();
    //public Dictionary<Vector2, Lod> lodeVelikost5Grid1 = new Dictionary<Vector2, Lod>();
    //public Dictionary<Vector2, Lod> lodeVelikost7Grid1 = new Dictionary<Vector2, Lod>();

    //public Dictionary<Vector2, Lod> lodeVelikost1Grid2 = new Dictionary<Vector2, Lod>();
    //public Dictionary<Vector2, Lod> lodeVelikost3Grid2 = new Dictionary<Vector2, Lod>();
    //public Dictionary<Vector2, Lod> lodeVelikost5Grid2 = new Dictionary<Vector2, Lod>();
    //public Dictionary<Vector2, Lod> lodeVelikost7Grid2 = new Dictionary<Vector2, Lod>();

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
    }

    /// <summary>
    /// Vytvoří loď na požadovaných souřadnicích.
    /// </summary>
    /// <param name="x">Souřadnice x.</param>
    /// <param name="y">Souřadnice y.</param>
    /// <param name="velikostLodi">Požadovaná velikost lodi (1, 3, 5, 7).</param>
    /// <param name="jeLodHorizontalne">Zda-li má být loď rotována.</param>
    /// <param name="cisloGridu">Číslo Gridu (1, 2)</param>
    public void UmistitLod(float x, float y, int velikostLodi, bool jeLodHorizontalne, int cisloGridu)
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
            Lod lod = new Lod();
            lod.RotovanoHorizontalne = jeLodHorizontalne;
            switch (velikostLodi)
            {
                case 1:
                    lod = Instantiate(lodPrefab1, new Vector3(x, y, -1), quaternion);
                    lod.Velikost = 1;
                    break;
                case 3:
                    lod = Instantiate(lodPrefab3, new Vector3(x, y, -1), quaternion);
                    lod.Velikost = 3;
                    break;
                case 5:
                    lod = Instantiate(lodPrefab5, new Vector3(x, y, -1), quaternion);
                    lod.Velikost = 5;
                    break;
                case 7:
                    lod = Instantiate(lodPrefab7, new Vector3(x, y, -1), quaternion);
                    lod.Velikost = 7;
                    break;

                default:
                    break;
            }

            if(cisloGridu == 1)
            {
                lodeGrid1[new Vector2(x, y)] = lod;
            }
            else
            {
                lodeGrid2[new Vector2(x, y)] = lod;
            }
            Debug.Log("Lod vytvořena");
        }
        else
        {
            Debug.Log("Lod nevytvořena");
        }
    }    
}
