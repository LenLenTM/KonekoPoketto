using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadShop : MonoBehaviour
{

    public GameObject InGame;
    public GameObject Shop;
    void Start()
    {
        
    }

    private void OnMouseUp()
    {
        InGame.SetActive(false);
        Shop.SetActive(true);
    }

    void Update()
    {
        
    }
}
