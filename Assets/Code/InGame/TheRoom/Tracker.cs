using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{

    public GameObject TheRoom;
    public GameObject Shop;
    
    public Transform trackedObject;
    public Transform trackedShop;
    
    public float updateSpeed = 3;
    public Vector2 tracakingOffset;
    
    private Vector3 offset;
    private Vector3 offsetShop;

    void Start()
    {
        offset = (Vector3)tracakingOffset;
        offsetShop = (Vector3)tracakingOffset;
        offset.z = transform.position.z - trackedObject.position.z;
        offsetShop.z = transform.position.z - trackedShop.position.z;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (TheRoom.activeSelf)
        {
            transform.position = Vector3.MoveTowards(transform.position, trackedObject.position + offset, updateSpeed * Time.deltaTime);
        }
       else if (Shop.activeSelf)
        {
            transform.position = Vector3.MoveTowards(transform.position, trackedShop.position + offsetShop, updateSpeed * Time.deltaTime);
        }
    }
}
