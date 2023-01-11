using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeleteSavegame : MonoBehaviour
{

    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;

    public Sprite Pusheen;

    private void OnMouseDown()
    {
        if (name.Equals("Delete_3"))
        {
            GameObject picture = slot3.transform.GetChild(0).gameObject;
            picture.GetComponent<Image>().sprite = Pusheen;
            GameObject text = slot3.transform.GetChild(1).gameObject;
            text.GetComponent<TextMeshProUGUI>().text = "Create a cat";
            File.Delete("Save3.txt");
        }
        else if (name.Equals("Delete_2"))
        {
            GameObject picture = slot2.transform.GetChild(0).gameObject;
            picture.GetComponent<Image>().sprite = Pusheen;
            GameObject text = slot2.transform.GetChild(1).gameObject;
            text.GetComponent<TextMeshProUGUI>().text = "Create a cat";
            File.Delete("Save2.txt");
        }
        else
        {
            GameObject picture = slot1.transform.GetChild(0).gameObject;
            picture.GetComponent<Image>().sprite = Pusheen;
            GameObject text = slot1.transform.GetChild(1).gameObject;
            text.GetComponent<TextMeshProUGUI>().text = "Create a cat";
            File.Delete("Save1.txt");
        }
        transform.gameObject.SetActive(false);
    }
}
