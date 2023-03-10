using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitShop : MonoBehaviour
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
            InGame.SetActive(true);
            Shop.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
