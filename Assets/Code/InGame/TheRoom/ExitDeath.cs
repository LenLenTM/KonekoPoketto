using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDeath : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject DeathScreen;
    private void OnMouseDown()
    {
        MainMenu.SetActive(true);
        DeathScreen.SetActive(false);
    }
}
