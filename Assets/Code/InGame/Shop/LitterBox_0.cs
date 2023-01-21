
using System.IO;
using Code;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using LitterBox = Code.LitterBox;

public class LitterBox_0 : MonoBehaviour
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
            
            TextAsset getNewBox = Resources.Load<TextAsset>("litterBox");
            LitterBox[] litterBoxes = JsonConvert.DeserializeObject<LitterBox[]>(getNewBox.ToString());
            savegame.litterBox = litterBoxes[0];
            
            /**
            using (StreamReader getNewBox = new StreamReader("Assets/litterBox.json"))
            {
                string json = getNewBox.ReadToEnd();
                LitterBox[] litterBoxes = JsonConvert.DeserializeObject<LitterBox[]>(json);
                savegame.litterBox = litterBoxes[0];
            }**/
            
            savegame.furballs -= 0;
            WriteSaveGame.createNewSaveGame(Savegame.encodeSavegame(savegame));
            
            FurballsShop.GetComponent<TextMeshProUGUI>().text = savegame.furballs.ToString() + " ₵";
            FurballsInGame.GetComponent<TextMeshProUGUI>().text = savegame.furballs.ToString() + " ₵";
        }
    }
}
