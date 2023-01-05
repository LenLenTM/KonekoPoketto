using UnityEngine;

namespace Code
{
    public class CatTree : Item
    {
        public int levels;

        public CatTree(string name, string graphic, int levels)
        {
            this.name = name;
            this.graphic = graphic;
            this.levels = levels;
        }
    }
}