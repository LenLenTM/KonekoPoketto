using System.IO;
using Code.InGame;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code
{
    public class GameGenerator : MonoBehaviour
    {
        private static string starterFoodSprite = "dryFood.png";
        private static string starterToySprite = "mouse.png";
        private static string starterCatTreeSprite = "stump.png";
        private static string starterCatBedSprite = "towel.png";
        private static string starterLitterBoxSprite = "pot.png";

        public static void createNewGame(string catName, string catSprite)
        {
            Food starterFood = new Food("DryFood", starterFoodSprite, 20);
            Toy starterToy = new Toy("Mouse", starterToySprite, 20);
            CatTree starterCatTree = new CatTree("Stump", starterCatTreeSprite, 1);
            CatBed starterCatBed = new CatBed("Towel", starterCatBedSprite, 15);
            LitterBox starterLitterBox = new LitterBox("Pot", starterLitterBoxSprite, 10, 99);
            Cat myCat = CatGenerator.generateCat(catName, catSprite);

            Savegame savegame = new Savegame(starterFood, starterToy, starterCatTree, starterCatBed, starterLitterBox, myCat, 0);

            string gameTextEncoded = Savegame.encodeSavegame(savegame);
            WriteSaveGame.createNewSaveGame(gameTextEncoded);
        }
    }
}