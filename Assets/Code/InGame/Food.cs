using UnityEngine;

namespace Code.InGame
{
    public class Food : Item
    {
        public int nourishing;

        public Food(string name, string graphic, int nourishing)
        {
            this.name = name;
            this.graphic = graphic;
            this.nourishing = nourishing;
        }
    }
}