using System.IO;
using Code;
using Newtonsoft.Json;
using UnityEngine;

public class CatTree_0 : MonoBehaviour
{
    
    private void OnMouseDown()
    {
        Savegame savegame = Savegame.loadSavegame();
        using (StreamReader getNewTree = new StreamReader("Assets/catTrees.json"))
        {
            string json = getNewTree.ReadToEnd();
            CatTree[] catTree = JsonConvert.DeserializeObject<CatTree[]>(json);
            savegame.catTree = catTree[0];
        }
        WriteSaveGame.createNewSaveGame(Savegame.encodeSavegame(savegame));
    }
}
