using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour
{

    private void triggerAnimation()
    {
        GetComponent<Animator>().SetTrigger("TriggerReaper");
    }
}
