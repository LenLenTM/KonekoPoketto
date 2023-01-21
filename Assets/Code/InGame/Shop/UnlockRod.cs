using System;
using System.Collections;
using System.Collections.Generic;
using Code;
using TMPro;
using UnityEngine;

public class UnlockRod : MonoBehaviour
{
    public GameObject RodIdle;
    public GameObject FurballsShop;
    public GameObject FurballsInGame;
    public GameObject Click;
    public GameObject SwipeInProgress;

    private float time;
    private void OnMouseDown()
    {
        time = Time.time;
    }

    private void OnMouseUp()
    {
        Savegame savegame = Savegame.loadSavegame();
        
        float deltaTime = Time.time - time;

        if (savegame.furballs >= 140 && deltaTime < 0.15f)
        {
            Click.GetComponent<AudioSource>().Play();
            //RodIdle.SetActive(true);
            savegame.furballs -= 140;
            savegame.toys[1] = 1;
            WriteSaveGame.createNewSaveGame(Savegame.encodeSavegame(savegame));
            
            FurballsShop.GetComponent<TextMeshProUGUI>().text = savegame.furballs.ToString() + " ₵";
            FurballsInGame.GetComponent<TextMeshProUGUI>().text = savegame.furballs.ToString() + " ₵";
        }
    }

void Update()
    {
        
    }
}
