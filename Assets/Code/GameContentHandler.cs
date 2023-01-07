using System.Collections;
using System.Collections.Generic;
using Code;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameContentHandler : MonoBehaviour
{
    public List<Sprite> catIdlesSprites;
    public List<Sprite> foodBowlSprites;
    public List<Sprite> catTreeSprites;
    public List<Sprite> roomBackgrounds;

    public Image catImage;
    public Image catTree;
    
    public GameObject InGame;
    public GameObject TheRoom;
    public GameObject furballs;

    private bool inGameSwitch = false;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (InGame.activeSelf && !inGameSwitch)
        {
            loadGamestate();
            inGameSwitch = true;
        }

        if (!InGame.activeSelf)
        {
            inGameSwitch = false;
        }
    }

    void loadGamestate()
    {
        Savegame savegame = Savegame.loadSavegame();
        updateCouch(savegame);
        updateCatTree(savegame);
        updateFurballs(savegame);
    }

    void updateCouch(Savegame savegame)
    {
        if (savegame.catTree.levels > 2)
        {
            TheRoom.GetComponent<Image>().sprite = roomBackgrounds[1];
        }
        else
        {
            TheRoom.GetComponent<Image>().sprite = roomBackgrounds[0];
        }
    }

    void updateCatTree(Savegame savegame)
    {
        foreach (Sprite x in catIdlesSprites)
        {
            if (x.name.Substring(0, 5).Equals(savegame.cat.idlePicture.Substring(0, 5)))
            {
                catImage.sprite = x;
            }
        }
        catTree.sprite = catTreeSprites[savegame.catTree.levels - 1];
    }

    void updateFurballs(Savegame savegame)
    {
        furballs.GetComponent<TextMeshProUGUI>().text = savegame.furballs.ToString() + " ₵";
    }
}
