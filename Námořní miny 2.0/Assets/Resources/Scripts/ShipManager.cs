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


    public void NakliknoutLod(float x, float y, int velikostLodi, bool rotace)
    {
        if (rotace)
        {
            if ((x + velikostLodi / 2) <= 19 && (x - velikostLodi / 2) >= 0)
            {
                Lod lodPrefab = GameObject.FindAnyObjectByType(typeof(Lod)) as Lod;

                switch (velikostLodi)
                {
                    case 1:
                        lodPrefab = lodPrefab1;
                        Lod lod = Instantiate(lodPrefab, new Vector3(x, y, -1), Quaternion.Euler(new Vector3(0, 0, 90)));
                        lodeVelikost1[new Vector2(x, y)] = lod;
                        break;
                    case 3:
                        lodPrefab = lodPrefab3;
                        lod = Instantiate(lodPrefab, new Vector3(x, y, -1), Quaternion.Euler(new Vector3(0, 0, 90)));
                        lodeVelikost3[new Vector2(x, y)] = lod;
                        break;
                    case 5:
                        lodPrefab = lodPrefab5;
                        lod = Instantiate(lodPrefab, new Vector3(x, y, -1), Quaternion.Euler(new Vector3(0, 0, 90)));
                        lodeVelikost5[new Vector2(x, y)] = lod;
                        break;
                    case 7:
                        lodPrefab = lodPrefab7;
                        lod = Instantiate(lodPrefab, new Vector3(x, y, -1), Quaternion.Euler(new Vector3(0, 0, 90)));
                        lodeVelikost7[new Vector2(x, y)] = lod;
                        break;

                    default:
                        break;
                }


            }
        }
        else
        {
            if ((y + velikostLodi / 2) <= 19 && (y - velikostLodi / 2) >= 0)
            {
                Lod lodPrefab = GameObject.FindAnyObjectByType(typeof(Lod)) as Lod;

                switch (velikostLodi)
                {
                    case 1:
                        lodPrefab = lodPrefab1;
                        Lod lod = Instantiate(lodPrefab, new Vector3(x, y, -1), Quaternion.identity);
                        lodeVelikost1[new Vector2(x, y)] = lod;
                        break;
                    case 3:
                        lodPrefab = lodPrefab3;
                        lod = Instantiate(lodPrefab, new Vector3(x, y, -1), Quaternion.identity);
                        lodeVelikost3[new Vector2(x, y)] = lod;
                        break;
                    case 5:
                        lodPrefab = lodPrefab5;
                        lod = Instantiate(lodPrefab, new Vector3(x, y, -1), Quaternion.identity);
                        lodeVelikost5[new Vector2(x, y)] = lod;
                        break;
                    case 7:
                        lodPrefab = lodPrefab7;
                        lod = Instantiate(lodPrefab, new Vector3(x, y, -1), Quaternion.identity);
                        lodeVelikost7[new Vector2(x, y)] = lod;
                        break;

                    default:
                        break;
                }
            }
        }
    }    
}
