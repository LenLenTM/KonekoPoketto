using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Image = UnityEngine.UI.Image;

namespace Code
{
    public class ChooseShelterCat : MonoBehaviour
    {

        public GameObject Shelter;
        public GameObject InGame;
        private void OnMouseDown()
        {
            GameObject picture = gameObject.transform.GetChild(0).gameObject;
            GameObject name = gameObject.transform.GetChild(1).gameObject;

            GameGenerator.createNewGame(name.GetComponent<TextMeshProUGUI>().text, picture.GetComponent<Image>().sprite.name);
            Shelter.SetActive(false);
            InGame.SetActive(true);
        }
    }
}