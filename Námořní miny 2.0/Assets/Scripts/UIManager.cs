using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
        print("jj");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("ukon�en� hry");
    }



}
