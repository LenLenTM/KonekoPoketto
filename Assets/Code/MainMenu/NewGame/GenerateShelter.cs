
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Random = System.Random;


public class Cats
{
    public string name;
}

public class GenerateShelter : MonoBehaviour
{
    public GameObject AdoptOrNew;
    public GameObject Shelter;
    public GameObject Click;

    public List<GameObject> catPictures;
    public List<GameObject> catNameTags;
    public List<Sprite> catSpriteList = new List<Sprite>(14);

    public void OnMouseDown()
    {
        Click.GetComponent<AudioSource>().Play();
        
        AdoptOrNew.SetActive(false);
        Shelter.SetActive(true);

        generateCats();
    }

    private void generateCats()
    {
        List<Cats> catNameArray = new List<Cats>();

        TextAsset catNamesFile = Resources.Load<TextAsset>("catNames");
        
        catNameArray = JsonConvert.DeserializeObject<List<Cats>>(catNamesFile.ToString());
        Random random = new Random();
        catNameArray = catNameArray.OrderBy(_ => random.Next()).ToList();
        catNameArray.RemoveRange(6, 14);
        

        Random random2 = new Random();
        catSpriteList = catSpriteList.OrderBy(_ => random2.Next()).ToList();
        catSpriteList.RemoveRange(6, 8);
        
        for (int i = 0; i < 6; i++)
        {
            catPictures[i].GetComponent<Image>().sprite = catSpriteList[i];
            catNameTags[i].GetComponent<TextMeshProUGUI>().text = catNameArray[i].name;
        }
    }
    void Update()
    {
        
    }
}
