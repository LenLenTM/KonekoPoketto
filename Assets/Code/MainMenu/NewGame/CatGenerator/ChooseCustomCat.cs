using System.Collections.Generic;
using System.Text;
using Code;
using UnityEngine;
using TMPro;
using Random = System.Random;

public class ChooseCustomCat : MonoBehaviour
{
    public GameObject CustomCat;
    public GameObject TheRoom;
    public TMP_InputField catNameInput;
    public List<Sprite> catSpriteList;

    private void OnMouseDown()
    {
        string name = catNameInput.text;

        byte[] by = Encoding.ASCII.GetBytes(catNameInput.text);
        int catPictureNumber = 0;

        foreach (byte x in by)
        {
            catPictureNumber += x;
        }
        Random random = new Random(1312);
        catPictureNumber = (catPictureNumber + random.Next()) % 14;

        GameGenerator.createNewGame(name, catSpriteList[catPictureNumber].name);
        CustomCat.SetActive(false);
        TheRoom.SetActive(true);
        //LoadGame.loadRoom();
    }
}
