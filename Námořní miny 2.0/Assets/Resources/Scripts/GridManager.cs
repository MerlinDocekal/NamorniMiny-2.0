using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//Zdroj: https://www.youtube.com/watch?v=kkAjpQAM-jE


public class GridManager : MonoBehaviour
{
    public static GridManager Instance { get; private set; }

    [SerializeField] private int sirka;
    [SerializeField] private int vyska;

    [SerializeField] private Tile polickoPrefab;


    [SerializeField] Mine minaZasah;
    [SerializeField] Mine minaVedle;

    [SerializeField] private Transform kamera;

    public int pozadovanaAkceProTileOnClick = 0;

    private Dictionary<Vector2, Tile> polickaGridu1 = new Dictionary<Vector2, Tile>();
    private Dictionary<Vector2, Tile> polickaGridu2 = new Dictionary<Vector2, Tile>();

    private Dictionary<Vector2, Mine> minyGridu1 = new Dictionary<Vector2, Mine>();
    private Dictionary<Vector2, Mine> minyGridu2 = new Dictionary<Vector2, Mine>();

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
        polickaGridu1 = new Dictionary<Vector2, Tile>();
        polickaGridu2 = new Dictionary<Vector2, Tile>();

        for (int x = 0; x < sirka; x++)
        {
            for (int y = 0; y < vyska; y++)
            {
                Tile vytvorenePolicko = Instantiate(polickoPrefab, new Vector3(x, y, 0), Quaternion.identity);
                
                vytvorenePolicko.name = $"Tile_1 {x} {y}";
                vytvorenePolicko.NastavitSouradnice(new Vector2(x, y));
                vytvorenePolicko.CisloGridu = 1;
                polickaGridu1[new Vector2(x, y)] = vytvorenePolicko;



                vytvorenePolicko = Instantiate(polickoPrefab, new Vector3(x + 23, y, 0), Quaternion.identity);

                vytvorenePolicko.name = $"Tile_2 {x} {y}";
                vytvorenePolicko.NastavitSouradnice(new Vector2(x + 23, y));
                vytvorenePolicko.CisloGridu = 2;
                polickaGridu2[new Vector2(x, y)] = vytvorenePolicko;
            }
        }


        kamera.transform.position = new Vector3((float)sirka + 1f, (float)vyska / 2 - 0.5f, -20);
    }

    /// <summary>
    /// Vr�t� pol��ko na zadan� pozici ze zadan�ho Gridu
    /// </summary>
    /// <param name="pozice">Pozice ve form�tu Vector2(x, y)</param>
    /// <param name="cisloGridu">��slo Gridu, kter�mu pol��ko n�le�� (1, 2)</param>
    /// <returns></returns>
    public Tile VratitPolickoNaPozici(Vector2 pozice, int cisloGridu)
    {
        Tile policko = null;
        if (cisloGridu == 1)
        {
            if (polickaGridu1.TryGetValue(pozice, out var tile))
            {
                policko = tile;
            }
        }
        else if (cisloGridu == 2)
        {
            if (polickaGridu2.TryGetValue(pozice, out var tile))
            {
                policko = tile;
            }
        }

        return policko;
    }

    public void UmistitMinu(float x, float y, int cisloGridu)
    {
        Mine mina = Instantiate(minaZasah, new Vector3(x, y, -2), Quaternion.identity);
        if (cisloGridu == 1)
        {
            minyGridu1[new Vector2 (x, y)] = mina;
        }
        else
        {
            minyGridu2[new Vector2(x, y)] = mina;
        }
    }

}
