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

    [SerializeField] public Sprite lodZnicenaSprite1;
    [SerializeField] public Sprite lodZnicenaSprite3;

    public Dictionary<Vector2, Lod> lodeGrid1Dic = new Dictionary<Vector2, Lod>();
    public Dictionary<Vector2, Lod> lodeGrid2Dic = new Dictionary<Vector2, Lod>();

    public GameObject lodeGrid1;
    public GameObject lodeGrid2;

    public bool umoznitaUmisteniLode1;


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
            switch (velikostLodi)
            {
                case 1:
                    if (UIManager.Instance.umoznenoUmisteniLode1)
                    {
                        Lod lod = gameObject.AddComponent<Lod>();
                        lod = Instantiate(lodPrefab1, new Vector3(x, y, -1), quaternion);
                        lod.NastavitLod(velikostLodi, jeLodHorizontalne, x, y);
                        if (cisloGridu == 1)
                        {
                            lodeGrid1Dic[new Vector2(x, y)] = lod;
                            lod.transform.SetParent(lodeGrid1.transform);
                        }
                        else
                        {
                            lodeGrid2Dic[new Vector2(x, y)] = lod;
                            lod.transform.SetParent(lodeGrid2.transform);
                        }

                        UIManager.Instance.UmistenaLod(velikostLodi, cisloGridu);
                    }
                    break;
                case 3:
                    if (UIManager.Instance.umoznenoUmisteniLode3)
                    {
                        Lod lod = gameObject.AddComponent<Lod>();
                        lod = Instantiate(lodPrefab3, new Vector3(x, y, -1), quaternion);
                        lod.NastavitLod(velikostLodi, jeLodHorizontalne, x, y);
                        if (cisloGridu == 1)
                        {
                            lodeGrid1Dic[new Vector2(x, y)] = lod;
                            lod.transform.SetParent(lodeGrid1.transform);
                        }
                        else
                        {
                            lodeGrid2Dic[new Vector2(x, y)] = lod;
                            lod.transform.SetParent(lodeGrid2.transform);
                        }

                        UIManager.Instance.UmistenaLod(velikostLodi, cisloGridu);
                    }
                    break;
                case 5:
                    if (UIManager.Instance.umoznenoUmisteniLode5)
                    {
                        Lod lod = gameObject.AddComponent<Lod>();
                        lod = Instantiate(lodPrefab5, new Vector3(x, y, -1), quaternion);
                        lod.NastavitLod(velikostLodi, jeLodHorizontalne, x, y);
                        if (cisloGridu == 1)
                        {
                            lodeGrid1Dic[new Vector2(x, y)] = lod;
                            lod.transform.SetParent(lodeGrid1.transform);
                        }
                        else
                        {
                            lodeGrid2Dic[new Vector2(x, y)] = lod;
                            lod.transform.SetParent(lodeGrid2.transform);
                        }

                        UIManager.Instance.UmistenaLod(velikostLodi, cisloGridu);
                    }
                    break;
                case 7:
                    if (UIManager.Instance.umoznenoUmisteniLode7)
                    {
                        Lod lod = gameObject.AddComponent<Lod>();
                        lod = Instantiate(lodPrefab7, new Vector3(x, y, -1), quaternion);
                        lod.NastavitLod(velikostLodi, jeLodHorizontalne, x, y);
                        if (cisloGridu == 1)
                        {
                            lodeGrid1Dic[new Vector2(x, y)] = lod;
                            lod.transform.SetParent(lodeGrid1.transform);
                        }
                        else
                        {
                            lodeGrid2Dic[new Vector2(x, y)] = lod;
                            lod.transform.SetParent(lodeGrid2.transform);
                        }

                        UIManager.Instance.UmistenaLod(velikostLodi, cisloGridu);
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
                Vector3 pomocnik = lodeGrid1.transform.position;
                pomocnik.z = 2;
                lodeGrid1.transform.position = pomocnik;
                break;
            case 2:
                pomocnik = lodeGrid2.transform.position;
                pomocnik.z = 2;
                lodeGrid2.transform.position = pomocnik;
                break;
            case 3:
                pomocnik = lodeGrid1.transform.position;
                pomocnik.z = 2;
                lodeGrid1.transform.position = pomocnik;

                pomocnik = lodeGrid2.transform.position;
                pomocnik.z = 2;
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
                Vector3 pomocnik = lodeGrid1.transform.position;
                pomocnik.z = -1;
                lodeGrid1.transform.position = pomocnik;
                break;
            case 2:
                pomocnik = lodeGrid2.transform.position;
                pomocnik.z = -1;
                lodeGrid2.transform.position = pomocnik;
                break;
            case 3:
                pomocnik = lodeGrid1.transform.position;
                pomocnik.z = -1;
                lodeGrid1.transform.position = pomocnik;

                pomocnik = lodeGrid2.transform.position;
                pomocnik.z = -1;
                lodeGrid2.transform.position = pomocnik;
                break;
            default:
                break;

        }
    }
}
