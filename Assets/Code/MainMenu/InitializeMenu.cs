using System;
using System.IO;
using Code;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InitializeMenu : MonoBehaviour
{

    public GameObject CreateOrLoad1;
    public GameObject CreateOrLoad2;
    public GameObject CreateOrLoad3;

    public Sprite[] catPictures;
    
    void Start()
    {
        loadSavegames();
    }

    void loadSavegames()
    {
        Savegame savegame;
        
        if (File.Exists("Save1.txt"))
        {
            string file = File.ReadAllText("Save1.txt");
            savegame = Savegame.decodeSavegame(file);
            
            string cat = savegame.cat.idlePicture;
            string name = savegame.cat.name;
            adaptMenu(cat, name, 1);
        }
        if (File.Exists("Save2.txt"))
        {
            string file = File.ReadAllText("Save2.txt");
            savegame = Savegame.decodeSavegame(file);
            
            string cat = savegame.cat.idlePicture;
            string name = savegame.cat.name;
            adaptMenu(cat, name, 2);
        }
        if (File.Exists("Save3.txt"))
        {
            string file = File.ReadAllText("Save3.txt");
            savegame = Savegame.decodeSavegame(file);
            
            string cat = savegame.cat.idlePicture;
            string name = savegame.cat.name;
            adaptMenu(cat, name, 3);
        }
        
    }

    void adaptMenu(string cat, string name, int slot)
    {
        if (slot == 1)
        {
            GameObject catPicture = CreateOrLoad1.transform.GetChild(0).gameObject;
            GameObject catName = CreateOrLoad1.transform.GetChild(1).gameObject;
            catPicture.GetComponent<Image>().sprite = compareCatName(cat);
            catName.GetComponent<TextMeshProUGUI>().text = name;
        }
        else if (slot == 2)
        {
            GameObject catPicture = CreateOrLoad2.transform.GetChild(0).gameObject;
            GameObject catName = CreateOrLoad2.transform.GetChild(1).gameObject;
            catPicture.GetComponent<Image>().sprite = compareCatName(cat);
            catName.GetComponent<TextMeshProUGUI>().text = name;
        }
        else
        {
            GameObject catPicture = CreateOrLoad3.transform.GetChild(0).gameObject;
            GameObject catName = CreateOrLoad3.transform.GetChild(1).gameObject;
            catPicture.GetComponent<Image>().sprite = compareCatName(cat);
            catName.GetComponent<TextMeshProUGUI>().text = name;
        }
    }

    Sprite compareCatName(string cat)
    {
        foreach (var x in catPictures)
        {
            if (x.name.Substring(0, 5) == cat.Substring(0, 5))
            {
                
                return x;
            }
        }
        return catPictures[0];
    }
    void Update()
    {
        
    }
}
