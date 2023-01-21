using System;
using System.Collections;
using System.Collections.Generic;
using Code;
using UnityEngine;

public class CatInteraction : MonoBehaviour
{
    public GameObject Herzen;
    public GameObject WhoolActivated;
    public GameObject BallActivated;
    public GameObject RodActivated;

    public GameObject meowSound;
    public GameObject purringSound;
    
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
            Herzen.SetActive(true);
            Herzen.GetComponent<ParticleSystem>().Play();
        
            Savegame savegame = Savegame.loadSavegame();

            if (WhoolActivated.activeSelf || BallActivated.activeSelf || RodActivated.activeSelf)
            {
                if (WhoolActivated.activeSelf)
                {
                    savegame.cat.boredom += 15;
                    WhoolActivated.SetActive(false);
                }
                else if (BallActivated.activeSelf)
                {
                    savegame.cat.boredom += 22;
                    BallActivated.SetActive(false);
                }
                else if (RodActivated.activeSelf)
                {
                    savegame.cat.boredom += 35;
                    RodActivated.SetActive(false);
                }

                if (savegame.cat.boredom > 100)
                {
                    savegame.cat.boredom = 100;
                }
                meowSound.GetComponent<AudioSource>().Play();
                savegame.furballs += 3;
            }
            else
            {
                savegame.cat.healthPoints += 3;
                if (savegame.cat.healthPoints >= 100)
                {
                    savegame.cat.healthPoints = 99;
                }
                purringSound.GetComponent<AudioSource>().Play();
                savegame.furballs += 2;
            }
        
            WriteSaveGame.createNewSaveGame(Savegame.encodeSavegame(savegame));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
