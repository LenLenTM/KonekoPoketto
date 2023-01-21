using System;
using System.IO;
using Code;
using Code.InGame;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InitializeMenu : MonoBehaviour
{

    public GameObject CreateOrLoad1;
    public GameObject CreateOrLoad2;
    public GameObject CreateOrLoad3;

    public Sprite[] catPictures;
    public Sprite gravestone;
    public GameObject[] deleter;
    public GameObject exitDeathScreen;
    public GameObject exitInGame;
    
    void Start()
    {
        loadSavegames();
    }

    void Update()
    {
        if (!exitDeathScreen.activeSelf || !exitInGame.activeSelf)
        {
            exitDeathScreen.SetActive(true);
            exitInGame.SetActive(true);
            loadSavegames();
        }
    }
    
    void loadSavegames()
    {
        Savegame savegame;
        
        if (File.Exists(Application.persistentDataPath + "/KonekoPokettoData/Save1.txt"))
        {
            string file = File.ReadAllText(Application.persistentDataPath + "/KonekoPokettoData/Save1.txt");
            savegame = Savegame.decodeSavegame(file);
            
            string cat = savegame.cat.idlePicture;
            string name = savegame.cat.name;
            
            setSlot(1);
            updateCat(savegame);
            adaptMenu(cat, name, 1, savegame);
            deleter[0].SetActive(true);
        }
        if (File.Exists(Application.persistentDataPath + "/KonekoPokettoData/Save2.txt"))
        {
            string file = File.ReadAllText(Application.persistentDataPath + "/KonekoPokettoData/Save2.txt");
            savegame = Savegame.decodeSavegame(file);
            
            string cat = savegame.cat.idlePicture;
            string name = savegame.cat.name;
            
            setSlot(2);
            updateCat(savegame);
            adaptMenu(cat, name, 2, savegame);
            deleter[1].SetActive(true);
        }
        if (File.Exists(Application.persistentDataPath + "/KonekoPokettoData/Save3.txt"))
        {
            string file = File.ReadAllText(Application.persistentDataPath + "/KonekoPokettoData/Save3.txt");
            savegame = Savegame.decodeSavegame(file);
            
            string cat = savegame.cat.idlePicture;
            string name = savegame.cat.name;
            
            setSlot(3);
            updateCat(savegame);
            adaptMenu(cat, name, 3, savegame);
            deleter[2].SetActive(true);
        }
        
    }

    void setSlot(int slot)
    {
        GameData gameData = new GameData(slot);
        string toWrite = JsonConvert.SerializeObject(gameData);
        
        if (!Directory.Exists(Application.persistentDataPath + "/KonekoPokettoData"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/KonekoPokettoData");
        }
        
        File.WriteAllText(Application.persistentDataPath + "/KonekoPokettoData/gameData.json", toWrite);
    }
    
    void updateCat(Savegame savegame)
    {
        DateTime saveTime = savegame.date;
        DateTime nowTime = DateTime.Now;
        TimeSpan elapsedTime = nowTime - saveTime;
        int elapsedHours = (int)elapsedTime.TotalHours;
        
        int timeHungerAtZero = (int)(savegame.cat.hunger / 4 * ((float)savegame.cat.metabolism / 100));
        int timeBoredomAtZero = (int)(savegame.cat.boredom / 4 * ((float)savegame.cat.playfull / 100));
        
        savegame.cat.hunger = (int)(savegame.cat.hunger - 2 * elapsedHours * ((float)(savegame.cat.metabolism / 100)));
        if (savegame.cat.hunger < 0)
        {
            savegame.cat.hunger = 0;
        }
        //TODO: implement increase of different catFood
        savegame.cat.boredom = (int)(savegame.cat.boredom - 2 * elapsedHours * ((float)savegame.cat.playfull / 100));
        if (savegame.cat.boredom < 0)
        {
            savegame.cat.boredom = 0;
        }

        if (savegame.litterBox.dirtyness > savegame.litterBox.pooCapacity && savegame.cat.hasEaten)
        {
            if (elapsedHours == 1)
            {
                savegame.cat.needsToPoo += 25;
            }

            if (elapsedHours >= 2)
            {
                savegame.cat.needsToPoo = 50;
            }
        }
        
        if (savegame.cat.hasEaten && savegame.litterBox.dirtyness < savegame.litterBox.pooCapacity)
        {
            savegame.cat.hasEaten = false;
            savegame.litterBox.dirtyness += 25;
            savegame.cat.needsToPoo = 0;

            //TODO: implement increase of different catFood
        }

        if (savegame.cat.hunger == 0 || savegame.cat.boredom == 0 || savegame.cat.needsToPoo >= 50)
        {
            int timeHungry = elapsedHours - timeHungerAtZero;
            int timeBored = elapsedHours - timeBoredomAtZero;
            int timeNeedPoo = elapsedHours - 2;

            if (savegame.cat.hunger == 0)
            {
                savegame.cat.healthPoints -= timeHungry * 6;
            }
            else if (savegame.cat.needsToPoo >= 50)
            {
                savegame.cat.healthPoints -= timeNeedPoo * 4;
            }
            else if (savegame.cat.boredom == 0)
            {
                savegame.cat.healthPoints -= timeBored * 2;
            }
        }

        if (savegame.cat.healthPoints <= 0)
        {
            savegame.alive = false;
            savegame.cat.healthPoints = 0;
        }
        
        if (savegame.cat.hunger > 0 && savegame.cat.boredom > 0 && savegame.cat.needsToPoo < 50 && savegame.cat.healthPoints < 99)
        {
            savegame.cat.healthPoints += 8 * elapsedHours;
        }
        if (savegame.cat.healthPoints > 99)
        {
            savegame.cat.healthPoints = 99;
        }

        WriteSaveGame.createNewSaveGame(Savegame.encodeSavegame(savegame));
    }

    void adaptMenu(string cat, string name, int slot, Savegame savegame)
    {
        if (slot == 1)
        {
            GameObject catPicture = CreateOrLoad1.transform.GetChild(0).gameObject;
            GameObject catName = CreateOrLoad1.transform.GetChild(1).gameObject;
            if (savegame.alive)
            {
                catPicture.GetComponent<Image>().sprite = compareCatName(cat);
            }
            else
            {
                catPicture.GetComponent<Image>().sprite = gravestone;
            }

            catName.GetComponent<TextMeshProUGUI>().text = name;
        }
        else if (slot == 2)
        {
            GameObject catPicture = CreateOrLoad2.transform.GetChild(0).gameObject;
            GameObject catName = CreateOrLoad2.transform.GetChild(1).gameObject;
            if (savegame.alive)
            {
                catPicture.GetComponent<Image>().sprite = compareCatName(cat);
            }
            else
            {
                catPicture.GetComponent<Image>().sprite = gravestone;
            }
            catName.GetComponent<TextMeshProUGUI>().text = name;
        }
        else
        {
            GameObject catPicture = CreateOrLoad3.transform.GetChild(0).gameObject;
            GameObject catName = CreateOrLoad3.transform.GetChild(1).gameObject;
            if (savegame.alive){
                catPicture.GetComponent<Image>().sprite = compareCatName(cat);
            }
            else
            {
                catPicture.GetComponent<Image>().sprite = gravestone;
            }
            catName.GetComponent<TextMeshProUGUI>().text = name;
        }
    }

    Sprite compareCatName(string cat)
    {
        foreach (var x in catPictures)
        {
            if (x.name.Substring(0, 5) == cat.Substring(0, 5))
            {
                
                return x;
            }
        }
        return catPictures[0];
    }
}
