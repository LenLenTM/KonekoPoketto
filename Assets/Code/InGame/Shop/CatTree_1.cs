using System.IO;
using Code;
using Newtonsoft.Json;
using UnityEngine;

public class CatTree_1 : MonoBehaviour
{

    private void OnMouseDown()
    {
        Savegame savegame = Savegame.loadSavegame();
        using (StreamReader getNewTree = new StreamReader("Assets/catTrees.json"))
        {
            string json = getNewTree.ReadToEnd();
            CatTree[] catTree = JsonConvert.DeserializeObject<CatTree[]>(json);
            savegame.catTree = catTree[1];
        }
        WriteSaveGame.createNewSaveGame(Savegame.encodeSavegame(savegame));
    }
}
