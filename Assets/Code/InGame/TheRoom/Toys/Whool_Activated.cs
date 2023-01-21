using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Whool_Activated : MonoBehaviour
{
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
            transform.GameObject().SetActive(false);
        }
    }
}
