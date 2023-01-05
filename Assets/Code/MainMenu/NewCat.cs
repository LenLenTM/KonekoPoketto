using System;
using System.IO;
using Code.InGame;
using Newtonsoft.Json;
using UnityEngine;

public class NewCat : MonoBehaviour
{
    public GameObject AdoptOrNew;
    public GameObject LittleCatMeow;
    public GameObject MainMenu;
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        LittleCatMeow.SetActive(false);
        AdoptOrNew.SetActive(true);
        MainMenu.SetActive(false);

        int slot = Int32.Parse(this.name.Substring(12));
        GameData gameData = new GameData(slot);

        string toWrite = JsonConvert.SerializeObject(gameData);
        
        File.WriteAllText("gameData.json", toWrite);
    }

    void Update()
    {
        
    }
}
