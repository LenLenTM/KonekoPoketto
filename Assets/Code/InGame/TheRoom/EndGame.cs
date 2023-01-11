using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Code;
using Code.InGame;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    public GameObject InGame;
    public GameObject MainMenu;
    public GameObject DeathScreen;
    private void OnMouseDown()
    {
        InGame.SetActive(false);
        MainMenu.SetActive(true);
        DeathScreen.SetActive(false);
        
        transform.gameObject.SetActive(false);
    }
}
