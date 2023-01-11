using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Code.InGame;
using Newtonsoft.Json;
using UnityEngine;

namespace Code
{
    public class Savegame
    {
        public Food food;
        public Toy toy;
        public CatTree catTree;
        public CatBed catBed;
        public LitterBox litterBox;
        public Cat cat;
        public int furballs;
        public DateTime date;
        public bool foodBowl;
        public bool alive;

        public Savegame(Food food, Toy toy, CatTree catTree, CatBed catBed, LitterBox litterBox, Cat cat, int furballs, DateTime date, bool foodBowl, bool alive)
        {
            this.food = food;
            this.toy = toy;
            this.catTree = catTree;
            this.catBed = catBed;
            this.litterBox = litterBox;
            this.cat = cat;
            this.furballs = furballs;
            this.date = date;
            this.foodBowl = foodBowl;
            this.alive = alive;
        }

        public static string encodeSavegame(Savegame savegame)
        {
            savegame.date = DateTime.Now;
            string gameToString = "";
            gameToString += savegame.food.name + "&" + savegame.food.graphic + "&" + savegame.food.nourishing + "&";
            gameToString += savegame.toy.name + "&" + savegame.toy.graphic + "&" + savegame.toy.playValue + "&";
            gameToString += savegame.catTree.name + "&" + savegame.catTree.graphic + "&" + savegame.catTree.levels + "&";
            gameToString += savegame.catBed.name + "&" + savegame.catBed.graphic + "&" + savegame.catBed.relaxValue + "&";
            gameToString += savegame.litterBox.name + "&" + savegame.litterBox.graphic + "&" + savegame.litterBox.pooCapacity + "&" + savegame.litterBox.dirtyness + "&";
            gameToString += savegame.cat.needForAffection + "&" + savegame.cat.playfull + "&" + savegame.cat.metabolism + "&" + savegame.cat.hunger + "&"
                            + savegame.cat.anger + "&" + savegame.cat.tiredness + "&" + savegame.cat.boredom + "&" + savegame.cat.bodymass + "&"
                            + savegame.cat.name + "&" + savegame.cat.idlePicture + "&" + savegame.cat.needsToPoo + "&" + savegame.cat.healthPoints + "&" + savegame.cat.hasEaten + "&"
                            + savegame.furballs + "&" + savegame.date + "&" + savegame.foodBowl + "&" + savegame.alive;
            
            byte[] ascii = Encoding.ASCII.GetBytes(gameToString);
            string file = "";
            foreach (byte x in ascii)
            {
                file = file + (x*2).ToString().PadLeft(4, '0');
            }
            
            return file;
        }
        
        public static Savegame decodeSavegame(string saveFile)
        {
            char[] ch = saveFile.ToCharArray();
            List<int> asciiCodes = new List<int>();
            for (int i = 0; i < ch.Length; i += 4)
            {
                string tmp = "";
                for (int j = 0; j < 4; j++)
                {
                    tmp += ch[i + j];
                }
                asciiCodes.Add(Int32.Parse(tmp) / 2);
            }

            string mySave = "";
            for (int i = 0; i < asciiCodes.Count; i++)
            {
                mySave += (char)asciiCodes[i];
            }
            string[] paramStrings = mySave.Split('&');
            
            Food food = new Food(paramStrings[0], paramStrings[1], Int32.Parse(paramStrings[2]));
            Toy toy = new Toy(paramStrings[3], paramStrings[4], Int32.Parse(paramStrings[5]));
            CatTree tree = new CatTree(paramStrings[6], paramStrings[7], Int32.Parse(paramStrings[8]));
            CatBed bed = new CatBed(paramStrings[9], paramStrings[10], Int32.Parse(paramStrings[11]));
            LitterBox litterBox = new LitterBox(paramStrings[12], paramStrings[13], Int32.Parse(paramStrings[14]), Int32.Parse(paramStrings[15]));
            Cat myCat = new Cat(Int32.Parse(paramStrings[16]), Int32.Parse(paramStrings[17]), Int32.Parse(paramStrings[18]), Int32.Parse(paramStrings[19]), Int32.Parse(paramStrings[20]),
                Int32.Parse(paramStrings[21]), Int32.Parse(paramStrings[22]), Int32.Parse(paramStrings[23]), paramStrings[24], paramStrings[25], Int32.Parse(paramStrings[26]), 
                Int32.Parse(paramStrings[27]), bool.Parse(paramStrings[28]));
            int furballs = Int32.Parse(paramStrings[29]);
            DateTime date = DateTime.Parse(paramStrings[30]);
            bool foodBowl = bool.Parse(paramStrings[31]);
            bool alive = bool.Parse(paramStrings[32]);
            
            return new Savegame(food, toy, tree, bed, litterBox, myCat, furballs, date, foodBowl, alive);
        }

        public static Savegame loadSavegame()
        {
            int slot;
            using (StreamReader slotJson = new StreamReader("gameData.json"))
            {
                string json = slotJson.ReadToEnd();
                slot = JsonConvert.DeserializeObject<GameData>(json).gameSlot;
            }

            string file = "";
            if (slot == 1)
            {
                file = File.ReadAllText("Save1.txt");
            }
            else if (slot == 2)
            {
                file = File.ReadAllText("Save2.txt");
            }
            else
            {
                file = File.ReadAllText("Save3.txt");
            }
            return Savegame.decodeSavegame(file);
        }
    }
}