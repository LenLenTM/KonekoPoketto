using UnityEngine;

namespace Code
{
    public class CatBed : Item
    {
        public int relaxValue;

        public CatBed(string name, string graphic, int relaxValue)
        {
            this.name = name;
            this.graphic = graphic;
            this.relaxValue = relaxValue;
        }
    }
}