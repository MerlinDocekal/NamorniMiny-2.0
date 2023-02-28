using System.Collections;
using System.Collections.Generic;
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
    /// Vytvo�� lo� na po�adovan�ch sou�adnic�ch.
    /// </summary>
    /// <param name="x">Sou�adnice x.</param>
    /// <param name="y">Sou�adnice y.</param>
    /// <param name="velikostLodi">Po�adovan� velikost lodi (1, 3, 5, 7).</param>
    /// <param name="rotace">Zda-li m� b�t lo� rotov�na.</param>
    public void NakliknoutLod(float x, float y, int velikostLodi, bool rotace)
    {
        Quaternion quaternion;
        bool neniMimoHraniceGridu;

        if(!rotace)
        {
            quaternion = Quaternion.identity;
            neniMimoHraniceGridu = ((x + velikostLodi / 2) <= 19 && (x - velikostLodi / 2) >= 0);
        }
        else
        {
            quaternion = Quaternion.identity;
            neniMimoHraniceGridu = ((y + velikostLodi / 2) <= 19 && (y - velikostLodi / 2) >= 0);
        }

        if (neniMimoHraniceGridu)
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
            Debug.Log("Lod vytvo�ena");
        }
        else
        {
            Debug.Log("Lod nevytvo�ena");
        }
    }    
}
