using System;
using System.IO;
using Code.InGame;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code
{
    public class GameGenerator : MonoBehaviour
    {
        private static string starterFoodSprite = "FoodBowl_Empty";
        private static string starterToySprite = "mouse.png";
        private static string starterCatTreeSprite = "CatTree_0";
        private static string starterCatBedSprite = "CatBed_0";
        private static string starterLitterBoxSprite = "LitterBox_0";

        public static void createNewGame(string catName, string catSprite)
        {
            Food starterFood = new Food("DryFood", starterFoodSprite, 20);
            Toy starterToy = new Toy("Mouse", starterToySprite, 20);
            CatTree starterCatTree = new CatTree("Caveman Cat", starterCatTreeSprite, 1);
            CatBed starterCatBed = new CatBed("Pawd", starterCatBedSprite, 15);
            LitterBox starterLitterBox = new LitterBox("Basic Poo", starterLitterBoxSprite, 10, 0);
            Cat myCat = CatGenerator.generateCat(catName, catSprite);
            DateTime date = DateTime.Now;

            Savegame savegame = new Savegame(starterFood, starterToy, starterCatTree, starterCatBed, starterLitterBox, myCat, 2000, date, false, true);

            string gameTextEncoded = Savegame.encodeSavegame(savegame);
            WriteSaveGame.createNewSaveGame(gameTextEncoded);
        }
    }
}