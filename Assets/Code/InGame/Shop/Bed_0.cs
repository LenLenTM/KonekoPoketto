using System.Collections;
using System.Collections.Generic;
using System.IO;
using Code;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class Bed_0 : MonoBehaviour
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
        
        if (savegame.furballs >= 0 && deltaTime < 0.15f)
        {
            Click.GetComponent<AudioSource>().Play();

            TextAsset getNewBed = Resources.Load<TextAsset>("catBeds");
            CatBed[] catBeds = JsonConvert.DeserializeObject<CatBed[]>(getNewBed.ToString());
            savegame.catBed = catBeds[0];
            
            /**using (StreamReader getNewBed = new StreamReader("Assets/catBeds.json"))
            {
                string json = getNewBed.ReadToEnd();
                CatBed[] catBeds = JsonConvert.DeserializeObject<CatBed[]>(json);
                savegame.catBed = catBeds[0];
            } **/
            
            savegame.furballs -= 0;
            WriteSaveGame.createNewSaveGame(Savegame.encodeSavegame(savegame));
            
            FurballsShop.GetComponent<TextMeshProUGUI>().text = savegame.furballs.ToString() + " ₵";
            FurballsInGame.GetComponent<TextMeshProUGUI>().text = savegame.furballs.ToString() + " ₵";
        }
    }
}
