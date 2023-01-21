using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LoadShop : MonoBehaviour
{

    public GameObject InGame;
    public GameObject Shop;
    public GameObject Click;
    
    private float time;
    private void OnMouseDown()
    {
        time = Time.time;
    }

    private void OnMouseUp()
    {
        float deltaTime = Time.time - time;

        if (deltaTime < 0.15f)
        {
            Click.GetComponent<AudioSource>().Play();
            InGame.SetActive(false);
            Shop.SetActive(true);
        }
    }

    void Update()
    {
    }
}
