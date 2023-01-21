using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball_Idle : MonoBehaviour
{
    public GameObject WhoolActivated;
    public GameObject BallActivated;
    public GameObject RodActivated;
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
            BallActivated.SetActive(true);
            WhoolActivated.SetActive(false);
            RodActivated.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
