using UnityEngine;

namespace Code
{
    public class LitterBox : Item
    {
        public int pooCapacity;
        public int cleanliness;

        public LitterBox(string name, string graphic, int pooCapacity, int cleanliness)
        {
            this.name = name;
            this.graphic = graphic;
            this.pooCapacity = pooCapacity;
            this.cleanliness = cleanliness;
        }
    }
}