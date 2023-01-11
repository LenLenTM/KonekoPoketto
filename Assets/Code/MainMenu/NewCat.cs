using System;
using System.IO;
using Code;
using Code.InGame;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class NewCat : MonoBehaviour
{
    public GameObject AdoptOrNew;
    public GameObject LittleCatMeow;
    public GameObject MainMenu;
    public GameObject InGame;
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        if (transform.GetChild(1).GetComponent<TextMeshProUGUI>().text.Equals("Create a cat"))
        {
            defineSlot();
            LittleCatMeow.SetActive(false);
            AdoptOrNew.SetActive(true);
            MainMenu.SetActive(false);
        }
        else
        {
            defineSlot();
            MainMenu.SetActive(false);
            LittleCatMeow.SetActive(false);
            InGame.SetActive(true);
        }
    }

    void defineSlot()
    {
        int slot = Int32.Parse(this.name.Substring(12));
        GameData gameData = new GameData(slot);
        string toWrite = JsonConvert.SerializeObject(gameData);
        File.WriteAllText("gameData.json", toWrite);
    }
    void Update()
    {
        
    }
}
