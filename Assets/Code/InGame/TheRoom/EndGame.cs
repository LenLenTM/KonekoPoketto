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
    public GameObject Click;
    
    private float time;
    private void OnMouseDown()
    {
        time = Time.time;
    }
    private void OnMouseUp()
    {
        float deltaTime = Time.time - time;

        if (deltaTime < 0.15f)
        {
            transform.GameObject().SetActive(false);
            Click.GetComponent<AudioSource>().Play();
            InGame.SetActive(false);
            MainMenu.SetActive(true);
            DeathScreen.SetActive(false);
        }
    }
}
