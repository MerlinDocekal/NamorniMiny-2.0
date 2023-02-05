using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Zdroj: https://www.youtube.com/watch?v=kkAjpQAM-jE


public class Tile : MonoBehaviour
{
    [SerializeField] GameObject highlight;

    void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

   void OnMouseExit()
    { 
        highlight.SetActive(false);
    }
}
