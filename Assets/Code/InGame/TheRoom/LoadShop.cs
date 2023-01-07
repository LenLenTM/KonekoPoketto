using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LoadShop : MonoBehaviour
{

    public GameObject InGame;
    public GameObject Shop;
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        InGame.SetActive(false);
        Shop.SetActive(true);
    }

    void Update()
    {
    }
}
