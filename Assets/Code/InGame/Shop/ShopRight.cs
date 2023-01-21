using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopRight : MonoBehaviour
{
    public GameObject focusShop;
    public GameObject Left;
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
            //LEFT
            if (focusShop.transform.position.x > -5f)
            {
                Click.GetComponent<AudioSource>().Play();
                focusShop.transform.Translate(-5, 0, 0);
            }

            if (focusShop.transform.position.x <= -5f)
            {
                transform.GameObject().SetActive(false);
            }

            Left.SetActive(true);
            Left.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }
    }
}
