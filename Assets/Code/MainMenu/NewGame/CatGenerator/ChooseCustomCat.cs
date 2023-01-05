using UnityEngine;
using TMPro;

public class ChooseCustomCat : MonoBehaviour
{
    public TMP_InputField catNameInput;

    private void OnMouseDown()
    {
        Debug.Log(catNameInput.text);
    }
}
