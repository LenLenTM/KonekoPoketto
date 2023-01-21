using UnityEngine;

public class GenerateNew : MonoBehaviour
{
    public GameObject AdoptOrNew;
    public GameObject CustomCat;
    public GameObject Click;

    private void OnMouseDown()
    {
        Click.GetComponent<AudioSource>().Play();
        AdoptOrNew.SetActive(false);
        CustomCat.SetActive(true);
    }
}
