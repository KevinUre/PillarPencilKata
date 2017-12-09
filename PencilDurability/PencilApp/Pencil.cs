using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PencilApp
{
    public class Pencil
    {
        /// <summary>
        /// The reminaing durability of the pencil tip. Without durability the pencil writes only spaces.
        /// </summary>
        public int Durability;
        /// <summary>
        /// The durability the pencil started with. this is the new durability when sharpened
        /// </summary>
        private int initialDurability;
        /// <summary>
        /// current lenght of the pencil. a pencil with zero length will not sharpen
        /// </summary>
        public int Length;

        public Pencil (int startingDurability, int startingLength)
        {
            initialDurability = startingDurability;
            Durability = startingDurability;
            Length = startingLength;
        }

        /// <summary>
        /// appends a string to another string so long as the pencil has durability to use. Adds spaces if not.
        /// </summary>
        /// <param name="inputText">The text to be written by the pencil</param>
        /// <param name="existingText">Where to write the text to</param>
        public void Write(string inputText, ref string existingText)
        {
            if (inputText == null)
                return;
            for(int i = 0; i < inputText.Length; i++)
            {
                int neededDurability;
                if (Char.IsUpper(inputText[i]))
                    neededDurability = 2;
                else if (inputText[i] == ' ')
                    neededDurability = 0;
                else
                    neededDurability = 1; //should cover both lower case and punctuation
                if (Durability - neededDurability < 0)
                    existingText += " "; //write spaces if durability runs out
                else
                {
                    existingText += inputText[i];
                    Durability -= neededDurability;
                }
            }
        }

        /// <summary>
        /// Restores the pencil's original durability at the cost of one unit of length
        /// </summary>
        public void Sharpen()
        {
            if(Length > 0)
            {
                Durability = initialDurability;
                Length--;
            }
        }
    }
}
