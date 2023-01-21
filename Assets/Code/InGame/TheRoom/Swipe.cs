using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    private Vector2 startTocuhPosition;
    private Vector2 endTouchPosition;
    public GameObject focus;
    public GameObject focusShop;
    public GameObject Shop;
    public GameObject deathScreen;
    public GameObject Right;
    public GameObject Left;
    
    void Update()
    {
        if (!deathScreen.activeSelf)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTocuhPosition = Input.GetTouch(0).position;
            }


            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTouchPosition = Input.GetTouch(0).position;

                if (endTouchPosition.x > startTocuhPosition.x && endTouchPosition.x - startTocuhPosition.x > 320)
                {
                    //RIGHT
                    if (Shop.activeSelf)
                    {
                        if (focusShop.transform.position.x < 5f)
                        {
                            focusShop.transform.Translate(5, 0, 0);
                        }
                        if (focusShop.transform.position.x >= 5f)
                        {
                            Left.SetActive(false);
                        }
                        Right.SetActive(true);
                    }
                    else
                    {
                        if (focus.transform.position.x < 5.5f)
                        {
                            focus.transform.Translate(5.5f, 0, 0);
                        }
                    }


                }

                if (endTouchPosition.x < startTocuhPosition.x && startTocuhPosition.x - endTouchPosition.x > 320)
                {
                    //LEFT
                    if (Shop.activeSelf)
                    {
                        if (focusShop.transform.position.x > -5f)
                        {
                            focusShop.transform.Translate(-5, 0, 0);
                        }
                        if (focusShop.transform.position.x <= -5f)
                        {
                            Right.SetActive(false);
                        }
                        Left.SetActive(true);
                    }
                    else
                    {
                        if (focus.transform.position.x > -5.5f)
                        {
                            focus.transform.Translate(-5.5f, 0, 0);
                        }
                    }
                }
            }
        }
    }
}
