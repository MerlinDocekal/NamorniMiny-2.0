using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    [SerializeField] private Lod lodPrefab1;
    [SerializeField] private Lod lodPrefab3;
    [SerializeField] private Lod lodPrefab5;
    [SerializeField] private Lod lodPrefab7;

    private Dictionary<Vector2, Lod> lodeVelikost1 = new Dictionary<Vector2, Lod>();
    private Dictionary<Vector2, Lod> lodeVelikost3 = new Dictionary<Vector2, Lod>();
    private Dictionary<Vector2, Lod> lodeVelikost5 = new Dictionary<Vector2, Lod>();
    private Dictionary<Vector2, Lod> lodeVelikost7 = new Dictionary<Vector2, Lod>();

    /// <summary>
    /// Vytvoří loď na požadovaných souřadnicích.
    /// </summary>
    /// <param name="x">Souřadnice x.</param>
    /// <param name="y">Souřadnice y.</param>
    /// <param name="velikostLodi">Požadovaná velikost lodi (1, 3, 5, 7).</param>
    /// <param name="jeLodHorizontalne">Zda-li má být loď rotována.</param>
    public void NakliknoutLod(float x, float y, int velikostLodi, bool jeLodHorizontalne)
    {
        Quaternion quaternion;
        bool neniMimoHraniceGridu;
        bool nekolidujeSLodi;

        if (jeLodHorizontalne)
        {
            quaternion = Quaternion.Euler(new Vector3(0, 0, 90));
            neniMimoHraniceGridu = ((x + velikostLodi / 2) <= 19 && (x - velikostLodi / 2) >= 0);

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
                    lodeVelikost1[new Vector2(x, y)] = lod;
                    break;
                case 3:
                    lod = Instantiate(lodPrefab3, new Vector3(x, y, -1), quaternion);
                    lodeVelikost3[new Vector2(x, y)] = lod;
                    break;
                case 5:
                    lod = Instantiate(lodPrefab5, new Vector3(x, y, -1), quaternion);
                    lodeVelikost5[new Vector2(x, y)] = lod;
                    break;
                case 7:
                    lod = Instantiate(lodPrefab7, new Vector3(x, y, -1), quaternion);
                    lodeVelikost7[new Vector2(x, y)] = lod;
                    break;

                default:
                    break;
            }
            Debug.Log("Lod vytvořena");
        }
        else
        {
            Debug.Log("Lod nevytvořena");
        }
    }    
}
