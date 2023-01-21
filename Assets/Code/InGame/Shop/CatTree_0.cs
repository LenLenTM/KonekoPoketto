using System.IO;
using Code;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class CatTree_0 : MonoBehaviour
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
        float deltaTime = Time.time - time;
        if (deltaTime < 0.15f)
        {
            Click.GetComponent<AudioSource>().Play();
            Savegame savegame = Savegame.loadSavegame();

            TextAsset getNewTree = Resources.Load<TextAsset>("catTrees");
            CatTree[] catTree = JsonConvert.DeserializeObject<CatTree[]>(getNewTree.ToString());
            savegame.catTree = catTree[0];

            /**
            using (StreamReader getNewTree = new StreamReader("Assets/catTrees.json"))
            {
                string json = getNewTree.ReadToEnd();
                CatTree[] catTree = JsonConvert.DeserializeObject<CatTree[]>(json);
                savegame.catTree = catTree[0];
            } **/

            WriteSaveGame.createNewSaveGame(Savegame.encodeSavegame(savegame));

            FurballsShop.GetComponent<TextMeshProUGUI>().text = savegame.furballs.ToString() + " ₵";
            FurballsInGame.GetComponent<TextMeshProUGUI>().text = savegame.furballs.ToString() + " ₵";
        }
    }
}
