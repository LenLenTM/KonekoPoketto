using UnityEngine;

public class GenerateNew : MonoBehaviour
{
    public GameObject AdoptOrNew;
    public GameObject CustomCat;

    private void OnMouseDown()
    {
        AdoptOrNew.SetActive(false);
        CustomCat.SetActive(true);
    }
}
