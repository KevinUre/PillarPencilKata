using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        /// <param name="existingText">Where to write the text to. Is a ref parameter for seperation for GUI textbox as a dependancy while maintaining easy GUI linkage</param>
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

        /// <summary>
        /// Removes the first instance of the given text from a string, searching back to front
        /// </summary>
        /// <param name="inputText">the text to be erased</param>
        /// <param name="exisitingText">the text to erase from. Is a ref parameter for seperation for GUI textbox as a dependancy while maintaining easy GUI linkage</param>
        public void Erase(string inputText, ref string exisitingText)
        {
            MatchCollection matches = Regex.Matches(exisitingText, inputText); //TODO: sanatize pattern to prevent injection attacks
            if (matches.Count == 0) //if text was not found
                return;
            Match lastMatch = matches[matches.Count - 1]; //get last match
            int matchStartIndex = lastMatch.Index;
            int substringCounter = 0;
            int substringLength = lastMatch.Length;
            string newPaperText = "";
            for (int paperIter = 0; paperIter < exisitingText.Length; paperIter++)
            {
                if (paperIter < matchStartIndex) //if we arent up to the match yet
                    newPaperText += exisitingText[paperIter];
                else if (substringCounter < substringLength)
                {
                    newPaperText += ' ';
                    substringCounter++;
                }
                else //if we are past the match
                    newPaperText += exisitingText[paperIter];
            }
            exisitingText = newPaperText;
        }
    }
}
