using System.Collections;
using System.Collections.Generic;
using System.IO;
using Code;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class LitterBox_2 : MonoBehaviour
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
        if (savegame.furballs >= 750 && deltaTime < 0.15f)
        {
            Click.GetComponent<AudioSource>().Play();
            
            TextAsset getNewBox = Resources.Load<TextAsset>("litterBox");
            LitterBox[] litterBoxes = JsonConvert.DeserializeObject<LitterBox[]>(getNewBox.ToString());
            savegame.litterBox = litterBoxes[2];
            
            /**
            using (StreamReader getNewBox = new StreamReader("Assets/litterBox.json"))
            {
                string json = getNewBox.ReadToEnd();
                LitterBox[] litterBoxes = JsonConvert.DeserializeObject<LitterBox[]>(json);
                savegame.litterBox = litterBoxes[2];
            }**/
            
            savegame.furballs -= 750;
            WriteSaveGame.createNewSaveGame(Savegame.encodeSavegame(savegame));
            
            FurballsShop.GetComponent<TextMeshProUGUI>().text = savegame.furballs.ToString() + " ₵";
            FurballsInGame.GetComponent<TextMeshProUGUI>().text = savegame.furballs.ToString() + " ₵";
        }
    }
}
