using System;
using System.Collections;
using System.Collections.Generic;
using Code;
using Unity.VisualScripting;
using UnityEngine;

public class LitterBoxTrigger : MonoBehaviour
{
    public GameObject stinkyParticles;
    public GameObject CleanLitterBoxSound;

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
            Savegame savegame = Savegame.loadSavegame();
            if (savegame.litterBox.dirtyness > 0)
            {
                savegame.litterBox.dirtyness = 0;
                stinkyParticles.SetActive(false);
                savegame.furballs += 5;
                WriteSaveGame.createNewSaveGame(Savegame.encodeSavegame(savegame));
                CleanLitterBoxSound.GetComponent<AudioSource>().Play();
            }
        }
    }
}
