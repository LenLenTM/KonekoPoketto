using System;
using System.Collections;
using System.Collections.Generic;
using Code;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UnlockBall : MonoBehaviour
{
    public GameObject BallIdle;
    public GameObject FurballsShop;
    public GameObject FurballsInGame;
    public GameObject Click;
    
    private float time;
    private void OnMouseDown()
    {
        time = Time.time;
    }

    private void OnMouseUp()
    {
        Savegame savegame = Savegame.loadSavegame();
        
        float deltaTime = Time.time - time;
        
        if (savegame.furballs >= 40 && deltaTime < 0.15f)
        {
            Click.GetComponent<AudioSource>().Play();
            //BallIdle.SetActive(true);
            savegame.furballs -= 40;
            savegame.toys[0] = 1;
            WriteSaveGame.createNewSaveGame(Savegame.encodeSavegame(savegame));
            
            FurballsShop.GetComponent<TextMeshProUGUI>().text = savegame.furballs.ToString() + " ₵";
            FurballsInGame.GetComponent<TextMeshProUGUI>().text = savegame.furballs.ToString() + " ₵";
        }
    }

    void Update()
    {
        
    }
}
