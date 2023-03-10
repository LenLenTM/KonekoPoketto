using System;
using System.Collections;
using System.Collections.Generic;
using Code;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = System.Random;

public class GameContentHandler : MonoBehaviour
{
    public List<Sprite> catIdlesSprites;
    public List<Sprite> foodBowlSprites;
    public List<Sprite> catTreeSprites;
    public List<Sprite> litterBoxSprites;
    public List<Sprite> catBedSprites;
    public List<Sprite> roomBackgrounds;
    public List<Sprite> hungerSteps;
    public List<Sprite> boredomSteps;
    public List<Sprite> healthSteps;
    public List<Sprite> pooSteps;

    public Image catImage;
    public Image catTree;
    public Image foodBowl;
    public Image litterBox;
    public Image catBed;

    public GameObject stinkyParticles;

    public List<GameObject> catPositionsNeeds;
    public List<GameObject> catPositionsChill;

    public GameObject InGame;
    public GameObject TheRoom;
    public GameObject TheEndRoom;
    public GameObject TheCat;
    public GameObject DeathSceen;
    
    public GameObject furballsInGame;
    public GameObject furballsShop;
    public GameObject hunger;
    public GameObject boredom;
    public GameObject healthPoints;
    public GameObject poopNeed;
    public GameObject tiredness;

    public GameObject Ball;
    public GameObject Rod;

    public GameObject catEatingSound;
    public GameObject catPoopSound;

    private bool inGameSwitch = false;
    
    private float time = 0.0f;
    private float timePeriodNeeds = 5; //default: 1800  -> Test: 5
    private float timePeriodMovement = 2; //also change if condition ín update loop (modulo) default: 120 -> test: 2

    void Start()
    {
    }
    
    void Update()
    {
        if (InGame.activeSelf && !inGameSwitch)
        {
            loadGamestate();
            inGameSwitch = true;
        }

        if (!InGame.activeSelf)
        {
            inGameSwitch = false;
        }

        time += Time.deltaTime;
        if (time >= timePeriodNeeds)
        {

            if (InGame.activeSelf)
            {
                updateCatNeeds();
                Debug.Log("Updated");
            }

            if ((time % 3) >= timePeriodMovement && InGame.activeSelf)
            {
                updateCatPosition();
            }

            time = time - timePeriodNeeds;
        }


    }
    
    void updateCatPosition()
    {
        Debug.Log("Update Position");
        Savegame savegame = Savegame.loadSavegame();
        
        //eat
        if (savegame.cat.hunger < 70 && (foodBowl.sprite.name.Equals("FoodBowl_Full")))
        {
            TheCat.transform.position = catPositionsNeeds[1].transform.position;
            catEatingSound.GetComponent<AudioSource>().Play();
            int difference = 99;
            difference = difference - savegame.cat.hunger;
            if (savegame.cat.hunger < 70)
            {
                savegame.cat.hunger += 30;
            }
            else
            {
                savegame.cat.hunger += difference;
            }
            
            foodBowl.sprite = foodBowlSprites[0];
            savegame.furballs += 5;
            savegame.foodBowl = false;
            savegame.cat.hasEaten = true;
        }
        
        //poop
        else if (savegame.cat.needsToPoo >= 25 && savegame.litterBox.dirtyness < savegame.litterBox.pooCapacity)
        {
            savegame.cat.hasEaten = false;
            TheCat.transform.position = catPositionsNeeds[2].transform.position;
            savegame.cat.needsToPoo = 0;
            savegame.litterBox.dirtyness += 25;
            catPoopSound.GetComponent<AudioSource>().Play();
        }
        else
        {
            randomiseCatPosition(savegame);
        }
        //litter box particles
        if (savegame.litterBox.dirtyness >= savegame.litterBox.pooCapacity && !stinkyParticles.activeSelf)
        {
            stinkyParticles.SetActive(true);
        }
        WriteSaveGame.createNewSaveGame(Savegame.encodeSavegame(savegame));
    }
    void updateCatNeeds()
    {
        Savegame savegame = Savegame.loadSavegame();

        //hunger
        int newHunger = (int)(savegame.cat.hunger - 4 * ((float)savegame.cat.metabolism / 100));
        if (newHunger < 0)
        {
            newHunger = 0;
        }
        savegame.cat.hunger = newHunger;

        //boredom
        int newBoredom = (int)(savegame.cat.boredom - 4 * ((float)savegame.cat.playfull / 100));
        if (newBoredom < 0)
        {
            newBoredom = 0;
        }
        savegame.cat.boredom = newBoredom;
        
        //pooUrgency
        if (savegame.cat.hasEaten)
        {
            savegame.cat.needsToPoo += 25;
        }
        
        //healt points
        if (savegame.cat.hunger == 0 || savegame.cat.boredom == 0 || savegame.cat.needsToPoo > 25)
        {
            if (savegame.cat.hunger == 0)
            {
                savegame.cat.healthPoints -= 3;
            }
            else if (savegame.cat.needsToPoo >= 50)
            {
                savegame.cat.healthPoints -= 2;
            }
            else if (savegame.cat.boredom == 0)
            {
                savegame.cat.healthPoints -= 1;
            }
            if (savegame.cat.healthPoints <= 0)
            {
                savegame.cat.healthPoints = 0;
                savegame.alive = false;
                loadGamestate();
            }
        }
        if (savegame.cat.hunger > 0 && savegame.cat.boredom > 0 && savegame.cat.needsToPoo < 50 && savegame.cat.healthPoints < 99)
        {
            savegame.cat.healthPoints += 4;
            if (savegame.cat.healthPoints > 99)
            {
                savegame.cat.healthPoints = 99;
            }
        }
        
        updateIcons(savegame);
        updateFurballs(savegame);
        WriteSaveGame.createNewSaveGame(Savegame.encodeSavegame(savegame));
    }

    void updateIcons(Savegame savegame)
    {
        int hungerValue = savegame.cat.hunger;
        if (hungerValue >= 100)
        {
            hungerValue = 99;
        }

        int boredomValue = savegame.cat.boredom;
        if (boredomValue >= 100)
        {
            boredomValue = 99;
        }

        if (savegame.cat.needsToPoo == 0)
        {
            poopNeed.GetComponent<Image>().sprite = pooSteps[9];
        }
        else if (savegame.cat.needsToPoo < 26)
        {
            poopNeed.GetComponent<Image>().sprite = pooSteps[4];
        }
        else if (savegame.cat.needsToPoo > 25)
        {
            poopNeed.GetComponent<Image>().sprite = pooSteps[0];
        }
        
        healthPoints.GetComponent<Image>().sprite = healthSteps[savegame.cat.healthPoints / 10];
        hunger.GetComponent<Image>().sprite = hungerSteps[hungerValue / 10];
        boredom.GetComponent<Image>().sprite = boredomSteps[boredomValue / 10];
    }

    void loadGamestate()
    {
        Savegame savegame = Savegame.loadSavegame();
        updateCat(savegame);
        updateCouch(savegame);
        updateCatTree(savegame);
        updateFurballs(savegame);
        updateIcons(savegame);
        updateFoodBowl(savegame);
        updateLitterBox(savegame);
        updateCatBed(savegame);
        randomiseCatPosition(savegame);
        updateToys(savegame);
        updateDeath(savegame);
    }


    void updateToys(Savegame savegame)
    {
        if (savegame.toys[0] == 1)
        {
            Ball.SetActive(true);
        }
        else
        {
            Ball.SetActive(false);
        }

        if (savegame.toys[1] == 1)
        {
            Rod.SetActive(true);
        }
        else
        {
            Rod.SetActive(false);
        }
    }
    void updateCatBed(Savegame savegame)
    {
        int index = (savegame.catBed.relaxValue / 10) - 1;
        catBed.sprite = catBedSprites[index];
    }

    void randomiseCatPosition(Savegame savegame)
    {
        Random random = new Random();
        int range = savegame.catTree.levels + 1;
        int index = random.Next(range);
        TheCat.transform.position = catPositionsChill[index].transform.position;
    }
    void updateLitterBox(Savegame savegame)
    {
        int index = (savegame.litterBox.pooCapacity / 25) - 1;
        if (index == 3)
        {
            index = 2;
        }
        litterBox.sprite = litterBoxSprites[index];
        if (savegame.litterBox.dirtyness >= savegame.litterBox.pooCapacity)
        {
            stinkyParticles.SetActive(true);
        }
    }
    void updateCouch(Savegame savegame)
    {
        if (savegame.catTree.levels > 2)
        {
            if (savegame.alive)
            {
                TheRoom.GetComponent<Image>().sprite = roomBackgrounds[1];
            }
            else
            {
                TheRoom.GetComponent<Image>().sprite = roomBackgrounds[3];
            }
           
        }
        else
        {
            if (savegame.alive)
            {
                TheRoom.GetComponent<Image>().sprite = roomBackgrounds[0];
            }
            else
            {
                TheRoom.GetComponent<Image>().sprite = roomBackgrounds[2];
            }
        }
    }

    void updateCat(Savegame savegame)
    {
        foreach (Sprite x in catIdlesSprites)
        {
            if (x.name.Substring(0, 5).Equals(savegame.cat.idlePicture.Substring(0, 5)))
            {
                catImage.sprite = x;
            }
        }
    }
    void updateCatTree(Savegame savegame)
    {
        catTree.sprite = catTreeSprites[savegame.catTree.levels - 1];
    }

    void updateFurballs(Savegame savegame)
    {
        furballsInGame.GetComponent<TextMeshProUGUI>().text = savegame.furballs.ToString() + " ₵";
        furballsShop.GetComponent<TextMeshProUGUI>().text = savegame.furballs.ToString() + " ₵";
    }

    void updateFoodBowl(Savegame savegame)
    {
        if (savegame.foodBowl)
        {
            foodBowl.sprite = foodBowlSprites[1];
        }
        else
        {
            foodBowl.sprite = foodBowlSprites[0];
        }
        
    }

    void updateDeath(Savegame savegame)
    {
        if (!savegame.alive)
        {
            InGame.SetActive(false);
            DeathSceen.SetActive(true);
            if (savegame.catTree.levels > 2)
            {
                TheEndRoom.GetComponent<Image>().sprite = roomBackgrounds[3];
            }
            else
            {
                TheEndRoom.GetComponent<Image>().sprite = roomBackgrounds[2];
            }
        }
    }
}
