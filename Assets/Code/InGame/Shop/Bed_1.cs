using System.Collections;
using System.Collections.Generic;
using System.IO;
using Code;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Bed_1 : MonoBehaviour
{
    public GameObject FurballsShop;
    public GameObject FurballsInGame;
    public GameObject Click;
    
    private float time;
    private void OnMouseDown()
    {
        time = Time.time;
    }
    private void OnMouseUp()
    {
        Savegame savegame = Savegame.loadSavegame();
        
        float deltaTime = Time.time - time;
        
        if (savegame.furballs >= 300 && deltaTime < 0.15f)
        {
            Click.GetComponent<AudioSource>().Play();
            
            TextAsset getNewBed = Resources.Load<TextAsset>("catBeds");
            CatBed[] catBeds = JsonConvert.DeserializeObject<CatBed[]>(getNewBed.ToString());
            savegame.catBed = catBeds[1];
            
            /**using (StreamReader getNewBed = new StreamReader("Assets/catBeds.json"))
            {
                string json = getNewBed.ReadToEnd();
                CatBed[] catBeds = JsonConvert.DeserializeObject<CatBed[]>(json);
                savegame.catBed = catBeds[1];
            } **/
            
            savegame.furballs -= 300;
            WriteSaveGame.createNewSaveGame(Savegame.encodeSavegame(savegame));
            
            FurballsShop.GetComponent<TextMeshProUGUI>().text = savegame.furballs.ToString() + " ₵";
            FurballsInGame.GetComponent<TextMeshProUGUI>().text = savegame.furballs.ToString() + " ₵";
        }
    }
}
