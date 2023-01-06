using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
    public class LoadGame : MonoBehaviour
    {

        public List<Sprite> catList;
        public Image catImage;
        public Image catTree;
        public Image foodBowl;
        public Image catBed;
        public Image litterBox;

        public void loadRoom()
        {
            Savegame savegame = Savegame.loadSavegame();
            foreach (var x in catList)
            {
                if (x.name.Substring(0, 5) == savegame.cat.name.Substring(0, 5))
                {
                    catImage.sprite = x;
                }
            }
        }
        
    }
}