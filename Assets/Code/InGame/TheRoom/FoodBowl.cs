using System;
using System.Collections;
using System.Collections.Generic;
using Code;
using UnityEngine;
using UnityEngine.UI;

public class FoodBowl : MonoBehaviour
{
    public Sprite foodBowlFull;
    public Sprite foodBowlEmpty;
    public GameObject refillBowlSound;
    
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
            if (GetComponent<Image>().sprite.name.Equals("FoodBowl_Empty"))
            {
                refillBowlSound.GetComponent<AudioSource>().Play();
                GetComponent<Image>().sprite = foodBowlFull;
                Savegame savegame = Savegame.loadSavegame();
                savegame.foodBowl = true;
                WriteSaveGame.createNewSaveGame(Savegame.encodeSavegame(savegame));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
