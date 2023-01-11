using UnityEngine;

namespace Code
{
    public class LitterBox : Item
    {
        public int pooCapacity;
        public int dirtyness;

        public LitterBox(string name, string graphic, int pooCapacity, int dirtyness)
        {
            this.name = name;
            this.graphic = graphic;
            this.pooCapacity = pooCapacity;
            this.dirtyness = dirtyness;
        }
    }
}