using System.IO;
using Code.InGame;
using Newtonsoft.Json;
using UnityEngine;

namespace Code
{
    public class WriteSaveGame
    {
        public static bool createNewSaveGame(string savegame)
        {
            int slot;
            using (StreamReader slotNumber = new StreamReader("gameData.json"))
            {
                string json = slotNumber.ReadToEnd();
                slot = JsonConvert.DeserializeObject<GameData>(json).gameSlot;
            }
            
            if (slot == 1)
            {
                writeSave("Save1.txt", savegame);
            }
            else if (slot == 2)
            {
                writeSave("Save2.txt", savegame);
            }
            else
            {
                writeSave("Save3.txt", savegame);
            }
            return true;
        }
        

        private static void writeSave(string filename, string savegame)
        {
            File.WriteAllText(filename, savegame);
        }

        private void autoSave()
        {
            
        }
    }
}