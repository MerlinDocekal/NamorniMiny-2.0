using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrepnoutHrace : MonoBehaviour
{
    public void ButtonClicked()
    {
        PlayerManager playerManager = GameObject.FindObjectOfType(typeof(PlayerManager)) as PlayerManager;
        playerManager.PrepnoutHrac();
    }
}
