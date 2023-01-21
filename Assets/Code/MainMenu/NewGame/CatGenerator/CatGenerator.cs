using System;
using System.Text;
using Code.InGame;
using Unity.VisualScripting;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace Code
{
    public class CatGenerator
    {

        public static Cat generateCat(string name, string idlePicture)
        {
            Random random = new Random(1312);
            int hunger = random.NextInt(29, 69);
            int anger = random.NextInt(29, 69);
            int tiredness = random.NextInt(29, 69);
            int boredom = random.NextInt(29, 69);
            int bodymass = random.NextInt(29, 69);

            int[] preValues = hashCat(name);

            if (preValues[0] == 0)
            {
                
            }

            int needForAffection = preValues[0];
            int playfull = preValues[1];
            int metabolism = preValues[2];
            
            return new Cat(needForAffection, playfull, metabolism, hunger, anger, tiredness, boredom, bodymass, name, idlePicture, 0, 99, false);
        }

        public static int[] hashCat(string name)
        {
            byte[] ascii = Encoding.ASCII.GetBytes(name);
            string valueAsString = "";
            foreach (byte x in ascii)
            {
                valueAsString += x;
            }
            Random random = new Random(1312);

            long value;
            try
            {
                value = ((Int64.Parse(valueAsString) * random.NextInt(59, 75)) % 999999);
            }
            catch
            {
                value = (long)random.NextDouble(10000, 999999);
            }
            //valueAsString = value.ToString().PadLeft(6, (char)random.NextInt(0, 99));

            if (value < 10)
            {
                value *= 100000;
            }
            else if (value < 100)
            {
                value *= 10000;
            }
            else if (value < 1000)
            {
                value *= 1000;   
            }
            else if (value < 10000)
            {
                value *= 100;
            }
            else if (value < 100000)
            {
                value *= 10;
            }

            int nFA = (int)value / 10000;
            value = value % 10000;
            int play = (int)value / 100;
            value = value % 100;
            int metabol = (int)value;

            int[] parameters = {nFA, play, metabol};
            return parameters;
        }
        
    }
}