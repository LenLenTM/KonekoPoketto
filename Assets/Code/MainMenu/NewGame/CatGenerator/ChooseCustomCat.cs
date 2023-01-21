using System;
using System.Collections.Generic;
using System.Text;
using Code;
using UnityEngine;
using TMPro;
using Random = System.Random;

public class ChooseCustomCat : MonoBehaviour
{
    public GameObject CustomCat;
    public GameObject InGame;
    public GameObject catNameInput;
    public GameObject catNameInputParent;
    public List<Sprite> catSpriteList;
    public GameObject Click;

    private void OnMouseDown()
    {
        Click.GetComponent<AudioSource>().Play();
        
        string name = catNameInput.GetComponent<TextMeshProUGUI>().text;
        catNameInput.GetComponent<TextMeshProUGUI>().text = String.Empty;
        //catNameInputParent.GetComponent<TextMeshPro>().text = "";

        if (name.EndsWith("?"))
        {
            name = name.Remove(name.Length - 1);
        }

        byte[] by = Encoding.ASCII.GetBytes(name);
        int catPictureNumber = 0;

        foreach (byte x in by)
        {
            catPictureNumber += x;
        }
        Random random = new Random(1312);
        catPictureNumber = (catPictureNumber + random.Next()) % 14;

        GameGenerator.createNewGame(name, catSpriteList[catPictureNumber].name);
        CustomCat.SetActive(false);
        InGame.SetActive(true);
    }
}
