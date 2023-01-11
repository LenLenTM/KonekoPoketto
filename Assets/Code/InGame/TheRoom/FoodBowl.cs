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
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        if (GetComponent<Image>().sprite.name.Equals("FoodBowl_Empty"))
        {
            GetComponent<Image>().sprite = foodBowlFull;
            Savegame savegame = Savegame.loadSavegame();
            savegame.foodBowl = true;
            WriteSaveGame.createNewSaveGame(Savegame.encodeSavegame(savegame));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
