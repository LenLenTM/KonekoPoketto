using System;
using System.Collections;
using System.Collections.Generic;
using Code;
using UnityEngine;

public class LitterBox : MonoBehaviour
{
    public GameObject stinkyParticles;

    private void OnMouseDown()
    {
        Savegame savegame = Savegame.loadSavegame();
        savegame.litterBox.dirtyness = 0;
        stinkyParticles.SetActive(false);
        WriteSaveGame.createNewSaveGame(Savegame.encodeSavegame(savegame));
    }
}
