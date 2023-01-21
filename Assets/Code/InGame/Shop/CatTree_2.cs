using System.Collections;
using System.Collections.Generic;
using System.IO;
using Code;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class CatTree_2 : MonoBehaviour
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
        if (savegame.furballs >= 450 && deltaTime < 0.15f)
        {
            Click.GetComponent<AudioSource>().Play();
            
            TextAsset getNewTree = Resources.Load<TextAsset>("catTrees");
            CatTree[] catTree = JsonConvert.DeserializeObject<CatTree[]>(getNewTree.ToString());
            savegame.catTree = catTree[2];
            
            /**
            using (StreamReader getNewTree = new StreamReader("Assets/catTrees.json"))
            {
                string json = getNewTree.ReadToEnd();
                CatTree[] catTree = JsonConvert.DeserializeObject<CatTree[]>(json);
                savegame.catTree = catTree[2];
            } **/
            
            savegame.furballs -= 450;
            WriteSaveGame.createNewSaveGame(Savegame.encodeSavegame(savegame));
            
            FurballsShop.GetComponent<TextMeshProUGUI>().text = savegame.furballs.ToString() + " ₵";
            FurballsInGame.GetComponent<TextMeshProUGUI>().text = savegame.furballs.ToString() + " ₵";
        }
    }
}
