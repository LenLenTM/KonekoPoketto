using UnityEngine;

namespace Code
{
    public class Toy : Item
    {
        public int playValue;

        public Toy(string name, string graphic, int playValue)
        {
            this.name = name;
            this.graphic = graphic;
            this.playValue = playValue;
        }
    }
}