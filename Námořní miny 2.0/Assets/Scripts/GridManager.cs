using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int sirka;
    [SerializeField] private int vyska;

    [SerializeField] private Tile tilePrefab;

    [SerializeField] private Transform kamera;

    private void Start()
    {
        GenerovatGrid();
    }

    void GenerovatGrid()
    {
        for (int x = 0; x < sirka; x++)
        {
            for (int y = 0; y < vyska; y++)
            {
                Tile spawnedTile = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity);
                
                spawnedTile.name = $"Tile {x} {y}";
            }
        }

        kamera.transform.position = new Vector3((float) sirka/2 - 0.5f, (float) vyska/2 - 0.5f, -20);
    }
}
