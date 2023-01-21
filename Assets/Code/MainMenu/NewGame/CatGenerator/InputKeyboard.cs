using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputKeyboard : MonoBehaviour
{

    private void OnMouseDown()
    {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false);
        TouchScreenKeyboard.hideInput = true;
    }
}
