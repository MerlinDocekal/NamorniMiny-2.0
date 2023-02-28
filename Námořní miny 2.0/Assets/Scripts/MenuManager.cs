using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(0);
        print("jj");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("ukonèení hry");
    }

    public void OnMOuseUp()
    {
        print("ahoj");
    }

    //public void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;
    //        if (Physics.Raycast(ray, out hit))
    //        {
    //                SceneManager.LoadScene(0);
                
    //        }
    //    }
    //}

}
