using System;
using System.Collections;
using System.Collections.Generic;
using Code;
using UnityEngine;

public class CatInteraction : MonoBehaviour
{
    public GameObject Herzen;
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        Herzen.SetActive(true);
        Herzen.GetComponent<ParticleSystem>().Play();
        
        Savegame savegame = Savegame.loadSavegame();
        savegame.cat.healthPoints += 3;

        WriteSaveGame.createNewSaveGame(Savegame.encodeSavegame(savegame));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
