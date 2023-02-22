using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    [SerializeField] public Lod lodPrefab;

    public void NakliknoutLod(float x, float y)
    {
        Instantiate(lodPrefab, new Vector3(x, y, -1), Quaternion.identity);
    }    
}
