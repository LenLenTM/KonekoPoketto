using TMPro;
using UnityEngine;

public class GenerateNew : MonoBehaviour
{
    public GameObject AdoptOrNew;
    public GameObject CustomCat;
    public GameObject Click;
    public GameObject textField;
    private void OnMouseDown()
    {
        Click.GetComponent<AudioSource>().Play();
        AdoptOrNew.SetActive(false);
        CustomCat.SetActive(true);
        textField.GetComponent<TextMeshProUGUI>().text = "";
    }
}
