using UnityEngine;

namespace Code
{
    public class Cat
    {
        public int needForAffection;   //calculate with #
        public int playfull;           //calculate with #
        //TODO: private Furcolor furcolor + dont forget to implement in savegame-creation and decryption;  
        public int metabolism;         //calculate with #
        public int hunger;
        public int anger;
        public int tiredness;
        public int boredom;
        public int bodymass;
        public string name;            //given
        public string idlePicture;     //given
        
        //all int values range form 0 to 99
        
        public Cat(int needForAffection, int playfull, int metabolism, int hunger, int anger, int tiredness, int boredom, int bodymass, string name, string idlePicture)
        {
            this.needForAffection = needForAffection;
            this.playfull = playfull;
            this.metabolism = metabolism;
            this.hunger = hunger;
            this.anger = anger;
            this.tiredness = tiredness;
            this.boredom = boredom;
            this.bodymass = bodymass;
            this.name = name;
            this.idlePicture = idlePicture;
        }
    }
}