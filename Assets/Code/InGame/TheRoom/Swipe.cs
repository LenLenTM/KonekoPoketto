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
    
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTocuhPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if (endTouchPosition.x < startTocuhPosition.x)
            {
                //RIGHT
                if (Shop.activeSelf)
                {
                    if (focusShop.transform.position.x < 5.5f)
                    {
                        for (int i = 0; i < 550; i++)
                        {
                            focusShop.transform.Translate(0.01f, 0, 0);
                        }
                    }
                }
                else
                {
                    if (focus.transform.position.x < 5.5f)
                    {
                        for (int i = 0; i < 550; i++)
                        {
                            focus.transform.Translate(0.01f, 0, 0);
                        }
                    }
                }
                
                
            }

            if (endTouchPosition.x > startTocuhPosition.x)
            {
                
                //LEFT
                if (Shop.activeSelf)
                {
                    if (focusShop.transform.position.x > -5.5f)
                    {
                        for (int i = 0; i < 550; i++)
                        {
                            focusShop.transform.Translate(-0.01f, 0, 0);
                        }
                    }
                }
                else
                {
                    if (focus.transform.position.x > -5.5f)
                    {
                        for (int i = 0; i < 550; i++)
                        {
                            focus.transform.Translate(-0.01f, 0, 0);
                        }
                    }
                }
            }
        }
    }
}
