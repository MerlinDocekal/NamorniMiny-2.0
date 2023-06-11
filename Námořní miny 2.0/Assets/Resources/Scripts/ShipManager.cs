using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class ShipManager : MonoBehaviour
{
    public static ShipManager Instance { get; private set; }

    [SerializeField] private Lod lodPrefab1;
    [SerializeField] private Lod lodPrefab3;
    [SerializeField] private Lod lodPrefab5;
    [SerializeField] private Lod lodPrefab7;

    public Dictionary<Vector2, Lod> lodeGrid1Dic = new Dictionary<Vector2, Lod>();
    public Dictionary<Vector2, Lod> lodeGrid2Dic = new Dictionary<Vector2, Lod>();

    public GameObject lodeGrid1;
    public GameObject lodeGrid2;

    private int pocetLodi1_1 = 5;
    private int pocetLodi3_1 = 4;
    private int pocetLodi5_1 = 3;
    private int pocetLodi7_1 = 2;

    private int pocetLodi1_2 = 5;
    private int pocetLodi3_2 = 4;
    private int pocetLodi5_2 = 3;
    private int pocetLodi7_2 = 2;

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

        lodeGrid1 = new GameObject("LodeGrid1");
        lodeGrid1.transform.SetParent(GameObject.Find("ShipManager").transform);
        lodeGrid2 = new GameObject("LodeGrid2");
        lodeGrid2.transform.SetParent(GameObject.Find("ShipManager").transform);
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
            //Debug.Log("Neni mimo hranice gridu: " + neniMimoHraniceGridu);

            LayerMask mask = LayerMask.GetMask("Lode");
            if (Physics2D.Raycast(new Vector2((x - ((float)velikostLodi / 2)), y), new Vector2(1, 0), velikostLodi, mask).collider == null)
            {
                nekolidujeSLodi = true;
            }
            else
            {
                nekolidujeSLodi = false;
            }
            //Debug.Log("Nekoliduje s lodi: " + nekolidujeSLodi);
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
            Lod lod = gameObject.AddComponent<Lod>();
            switch (velikostLodi)
            {
                case 1:
                    lod = Instantiate(lodPrefab1, new Vector3(x, y, -1), quaternion);
                    lod.NastavitLod(velikostLodi, jeLodHorizontalne, x, y);
                    if (cisloGridu == 1)
                    {
                        lodeGrid1Dic[new Vector2(x, y)] = lod;
                        lod.transform.SetParent(lodeGrid1.transform);
                        pocetLodi1_1--;
                        Debug.Log("Počet lodí celkem: " + (pocetLodi1_1 + pocetLodi3_1 + pocetLodi5_1 + pocetLodi7_1));
                        if (pocetLodi1_1 == 0)
                        {
                            GameObject.Find("ButtonUmistitLod1_1").SetActive(false);
                            if((pocetLodi1_1 + pocetLodi3_1 + pocetLodi5_1 + pocetLodi7_1) == 0)
                            {
                                GameObject.Find("ButtonPrepnoutHrace_1").SetActive(true);
                            }
                        }
                    }
                    else
                    {
                        lodeGrid2Dic[new Vector2(x, y)] = lod;
                        lod.transform.SetParent(lodeGrid2.transform);
                        pocetLodi1_2--;
                        if (pocetLodi1_2 == 0)
                        {
                            GameObject.Find("ButtonUmistitLod1_2").SetActive(false);
                            if (pocetLodi1_2 + pocetLodi3_2 + pocetLodi5_2 + pocetLodi7_2 == 0)
                            {
                                GameObject.Find("ButtonPrepnoutHrace_2").SetActive(true);
                            }
                        }
                    }
                    break;
                case 3:
                    lod = Instantiate(lodPrefab3, new Vector3(x, y, -1), quaternion);
                    lod.NastavitLod(velikostLodi, jeLodHorizontalne, x, y);
                    if (cisloGridu == 1)
                    {
                        lodeGrid1Dic[new Vector2(x, y)] = lod;
                        lod.transform.SetParent(lodeGrid1.transform);
                        pocetLodi3_1--;
                        Debug.Log("Počet lodí celkem: " + (pocetLodi1_1 + pocetLodi3_1 + pocetLodi5_1 + pocetLodi7_1));
                        if (pocetLodi3_1 == 0)
                        {
                            GameObject.Find("ButtonUmistitLod3_1").SetActive(false);
                            if ((pocetLodi1_1 + pocetLodi3_1 + pocetLodi5_1 + pocetLodi7_1) == 0)
                            {
                                GameObject.Find("ButtonPrepnoutHrace_1").SetActive(true);
                            }
                        }
                    }
                    else
                    {
                        lodeGrid2Dic[new Vector2(x, y)] = lod;
                        lod.transform.SetParent(lodeGrid2.transform);
                        pocetLodi3_2--;
                        if (pocetLodi3_2 == 0)
                        {
                            GameObject.Find("ButtonUmistitLod3_2").SetActive(false);
                            if (pocetLodi1_2 + pocetLodi3_2 + pocetLodi5_2 + pocetLodi7_2 == 0)
                            {
                                GameObject.Find("ButtonPrepnoutHrace_2").SetActive(true);
                            }
                        }
                    }
                    break;
                case 5:
                    lod = Instantiate(lodPrefab5, new Vector3(x, y, -1), quaternion);
                    lod.NastavitLod(velikostLodi, jeLodHorizontalne, x, y);
                    if (cisloGridu == 1)
                    {
                        lodeGrid1Dic[new Vector2(x, y)] = lod;
                        lod.transform.SetParent(lodeGrid1.transform);
                        pocetLodi5_1--;
                        Debug.Log("Počet lodí celkem: " + (pocetLodi1_1 + pocetLodi3_1 + pocetLodi5_1 + pocetLodi7_1));
                        if (pocetLodi5_1 == 0)
                        {
                            GameObject.Find("ButtonUmistitLod5_1").SetActive(false);
                            if ((pocetLodi1_1 + pocetLodi3_1 + pocetLodi5_1 + pocetLodi7_1) == 0)
                            {
                                GameObject.Find("ButtonPrepnoutHrace_1").SetActive(true);
                            }
                        }
                    }
                    else
                    {
                        lodeGrid2Dic[new Vector2(x, y)] = lod;
                        lod.transform.SetParent(lodeGrid2.transform);
                        pocetLodi5_2--;
                        if (pocetLodi5_2 == 0)
                        {
                            GameObject.Find("ButtonUmistitLod5_2").SetActive(false);
                            if (pocetLodi1_2 + pocetLodi3_2 + pocetLodi5_2 + pocetLodi7_2 == 0)
                            {
                                GameObject.Find("ButtonPrepnoutHrace_2").SetActive(true);
                            }
                        }
                    }
                    break;
                case 7:
                    lod = Instantiate(lodPrefab7, new Vector3(x, y, -1), quaternion);
                    lod.NastavitLod(velikostLodi, jeLodHorizontalne, x, y);
                    if (cisloGridu == 1)
                    {
                        lodeGrid1Dic[new Vector2(x, y)] = lod;
                        lod.transform.SetParent(lodeGrid1.transform);
                        pocetLodi7_1--;
                        Debug.Log("Počet lodí celkem: " + (pocetLodi1_1 + pocetLodi3_1 + pocetLodi5_1 + pocetLodi7_1));
                        if (pocetLodi7_1 == 0)
                        {
                            GameObject.Find("ButtonUmistitLod7_1").SetActive(false);
                            if ((pocetLodi1_1 + pocetLodi3_1 + pocetLodi5_1 + pocetLodi7_1) == 0)
                            {
                                GameObject.Find("ButtonPrepnoutHrace_1").SetActive(true);
                            }
                        }
                    }
                    else
                    {
                        lodeGrid2Dic[new Vector2(x, y)] = lod;
                        lod.transform.SetParent(lodeGrid2.transform);
                        pocetLodi7_2--;
                        if (pocetLodi7_2 == 0)
                        {
                            GameObject.Find("ButtonUmistitLod7_2").SetActive(false);
                            if (pocetLodi1_2 + pocetLodi3_2 + pocetLodi5_2 + pocetLodi7_2 == 0)
                            {
                                GameObject.Find("ButtonPrepnoutHrace_2").SetActive(true);
                            }
                        }
                    }
                    break;
                default:
                    break;
            }

            //Debug.Log("Lod vytvořena");
        }
        else
        {
            //Debug.Log("Lod nevytvořena");
        }
    }

    /// <summary>
    /// Skryje lodě na Gridu za grid.
    /// </summary>
    /// <param name="cisloGridu">Číslo Gridu (1, 2), *3* skryje na obou.</param>
    public void SkrytLode(int cisloGridu)
    {
        switch (cisloGridu)
        {
            case 1:
                GameObject lodeGrid1 = GameObject.Find("LodeGrid1");
                Vector3 pomocnik = lodeGrid1.transform.position;
                pomocnik.z = 1;
                lodeGrid1.transform.position = pomocnik;
                break;
            case 2:
                GameObject lodeGrid2 = GameObject.Find("LodeGrid2");
                pomocnik = lodeGrid2.transform.position;
                pomocnik.z = 1;
                lodeGrid2.transform.position = pomocnik;
                break;
            case 3:
                lodeGrid1 = GameObject.Find("LodeGrid1");
                pomocnik = lodeGrid1.transform.position;
                pomocnik.z = 1;
                lodeGrid1.transform.position = pomocnik;

                lodeGrid2 = GameObject.Find("LodeGrid2");
                pomocnik = lodeGrid2.transform.position;
                pomocnik.z = 1;
                lodeGrid2.transform.position = pomocnik;
                break;            
            default:          
                break;
            
        }
    }
    /// <summary>
    /// Zobrazí lodě na Gridu před grid.
    /// </summary>
    /// <param name="cisloGridu">Číslo Gridu (1, 2), *3* zobrazí na obou.</param>
    public void ZobrazitLode(int cisloGridu)
    {
        switch (cisloGridu)
        {
            case 1:
                GameObject lodeGrid1 = GameObject.Find("LodeGrid1");
                Vector3 pomocnik = lodeGrid1.transform.position;
                pomocnik.z = -1;
                lodeGrid1.transform.position = pomocnik;
                break;
            case 2:
                GameObject lodeGrid2 = GameObject.Find("LodeGrid2");
                pomocnik = lodeGrid2.transform.position;
                pomocnik.z = -1;
                lodeGrid2.transform.position = pomocnik;
                break;
            case 3:
                lodeGrid1 = GameObject.Find("LodeGrid1");
                pomocnik = lodeGrid1.transform.position;
                pomocnik.z = -1;
                lodeGrid1.transform.position = pomocnik;

                lodeGrid2 = GameObject.Find("LodeGrid2");
                pomocnik = lodeGrid2.transform.position;
                pomocnik.z = -1;
                lodeGrid2.transform.position = pomocnik;
                break;
            default:
                break;

        }
    }
}
