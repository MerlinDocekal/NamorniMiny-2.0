using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class GridManager : MonoBehaviour
{
    public static GridManager Instance { get; private set; }

    private int sirka = 20;
    private int vyska = 20;

    [SerializeField] private Tile polickoPrefab;


    [SerializeField] Mine minaZasah;
    [SerializeField] Mine minaVedle;

    [SerializeField] private Transform kamera;

    public Dictionary<Vector2, Tile> polickaGrid1Dic = new Dictionary<Vector2, Tile>();
    public Dictionary<Vector2, Tile> polickaGrid2Dic = new Dictionary<Vector2, Tile>();

    public Dictionary<Vector2, Mine> minyGrid1Dic = new Dictionary<Vector2, Mine>();
    public Dictionary<Vector2, Mine> minyGrid2Dic = new Dictionary<Vector2, Mine>();

    private GameObject grid1;
    private GameObject grid2;

    private GameObject minyGrid1;
    private GameObject minyGrid2;

    private GameObject polickaGrid1;
    private GameObject polickaGrid2;

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

        GenerovatGrid();
    } 

    void GenerovatGrid()
    {
        polickaGrid1Dic = new Dictionary<Vector2, Tile>();
        polickaGrid2Dic = new Dictionary<Vector2, Tile>();

        grid1 = new GameObject("Grid1");
        grid1.transform.SetParent(GameObject.Find("GridManager").transform);
        grid2 = new GameObject("Grid2");
        grid2.transform.SetParent(GameObject.Find("GridManager").transform);

        polickaGrid1 = new GameObject("PolickaGrid1");
        polickaGrid1.transform.SetParent(grid1.transform);
        polickaGrid2 = new GameObject("PolickaGrid2");
        polickaGrid2.transform.SetParent(grid2.transform);

        minyGrid1 = new GameObject("MinyGrid1");
        minyGrid1.transform.SetParent(grid1.transform);
        minyGrid2 = new GameObject("MinyGrid2");
        minyGrid2.transform.SetParent(grid2.transform);

        for (int x = 0; x < sirka; x++)
        {
            for (int y = 0; y < vyska; y++)
            {
                Tile vytvorenePolicko = Instantiate(polickoPrefab, new Vector3(x, y, 0), Quaternion.identity);
                
                vytvorenePolicko.name = $"Tile_1 {x} {y}";
                vytvorenePolicko.NastavitSouradnice(new Vector2(x, y));
                vytvorenePolicko.CisloGridu = 1;
                vytvorenePolicko.transform.SetParent(polickaGrid1.transform);
                polickaGrid1Dic[new Vector2(x, y)] = vytvorenePolicko;



                vytvorenePolicko = Instantiate(polickoPrefab, new Vector3(x + 23, y, 0), Quaternion.identity);

                vytvorenePolicko.name = $"Tile_2 {x} {y}";
                vytvorenePolicko.NastavitSouradnice(new Vector2(x + 23, y));
                vytvorenePolicko.CisloGridu = 2;
                vytvorenePolicko.transform.SetParent(polickaGrid2.transform);
                polickaGrid2Dic[new Vector2(x, y)] = vytvorenePolicko;
            }
        }


        kamera.transform.position = new Vector3((float)sirka + 1f, (float)vyska / 2 - 0.5f, -20);
    }

    /// <summary>
    /// Vrátí políèko na zadané pozici ze zadaného Gridu
    /// </summary>
    /// <param name="pozice">Pozice ve formátu Vector2(x, y)</param>
    /// <param name="cisloGridu">Èíslo Gridu, kterému políèko náleží (1, 2)</param>
    /// <returns></returns>
    public Tile VratitPolickoNaPozici(Vector2 pozice, int cisloGridu)
    {
        Tile policko = null;
        if (cisloGridu == 1)
        {
            if (polickaGrid1Dic.TryGetValue(pozice, out var tile))
            {
                policko = tile;
            }
        }
        else if (cisloGridu == 2)
        {
            if (polickaGrid2Dic.TryGetValue(pozice, out var tile))
            {
                policko = tile;
            }
        }

        return policko;
    }

    public void UmistitMinu(float x, float y, int cisloGridu)
    {
        Mine mina;
        LayerMask mask = LayerMask.GetMask("Lode");
        RaycastHit2D raycastHit2D = Physics2D.Raycast(new Vector2(x, y), new Vector2(0, 0), 1, mask);
        if (raycastHit2D.collider == null)
        {
            mina = Instantiate(minaVedle, new Vector3(x, y, -2), Quaternion.identity);
            if (cisloGridu == 1)
            {
                minyGrid1Dic[new Vector2(x, y)] = mina;
                mina.transform.SetParent(minyGrid1.transform);
            }
            else
            {
                minyGrid2Dic[new Vector2(x, y)] = mina;
                mina.transform.SetParent(minyGrid2.transform);
            }
            Debug.Log("Loï nezasažena.");
        }
        else
        {
            mina = Instantiate(minaZasah, new Vector3(x, y, -2), Quaternion.identity);
            Lod lod = raycastHit2D.collider.gameObject.GetComponent<Lod>();
            mina.transform.SetParent(lod.transform);
            lod.ZasahnoutLod();
            Debug.Log("Loï zasažena.");
        }
    }

}
