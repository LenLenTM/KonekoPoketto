using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitShop : MonoBehaviour
{
    public GameObject InGame;
    public GameObject Shop;
    void Start()
    {
        
    }

    private void OnMouseUp()
    {
        InGame.SetActive(true);
        Shop.SetActive(false);
    }

    void Update()
    {
        
    }
}