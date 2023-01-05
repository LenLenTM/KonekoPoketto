using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Code
{
    public class ChooseShelterCat : MonoBehaviour
    {
        private void OnMouseUp()
        {
            GameObject picture = gameObject.transform.GetChild(0).gameObject;
            GameObject name = gameObject.transform.GetChild(1).gameObject;

            GameGenerator.createNewGame(name.GetComponent<TextMeshProUGUI>().text, picture.GetComponent<Image>().sprite.name);
        }
    }
}