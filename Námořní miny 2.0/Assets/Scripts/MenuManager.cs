using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //public void Play()
    //{
    //    SceneManager.LoadScene(0);
    //}

    //public void Quit()
    //{
    //    Application.Quit();
    //}

     void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Select stage    
                if (hit.transform.name == "Cube")
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }

}
