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
        public int EraserDurability;

        public Pencil (int startingDurability, int startingLength, int initialEraserDurability)
        {
            initialDurability = startingDurability;
            Durability = startingDurability;
            Length = startingLength;
            EraserDurability = initialEraserDurability;
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
                int neededDurability = RequiredDurability(inputText[i]);
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
        /// Returns the durability required to write a specified character
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private int RequiredDurability(char input)
        {
            int neededDurability;
            if (Char.IsUpper(input))
                neededDurability = 2;
            else if (input == ' ')
                neededDurability = 0;
            else
                neededDurability = 1; //should cover both lower case and punctuation
            return neededDurability;
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
            if (inputText == null || exisitingText == null)
                return;
            MatchCollection matches = Regex.Matches(exisitingText, inputText); //TODO: sanatize pattern to prevent injection attacks
            if (matches.Count == 0) //if text was not found
                return;
            Match lastMatch = matches[matches.Count - 1]; //get last match
            int matchStartIndex = lastMatch.Index;
            int substringLength = lastMatch.Length;
            int operationStartIndex = matchStartIndex + substringLength-1;
            char[] newPaperText = exisitingText.ToArray<Char>();
            for(int backwardspaperIter = operationStartIndex; backwardspaperIter > matchStartIndex-1; backwardspaperIter--)
            {
                if(EraserDurability > 0)
                {
                    newPaperText[backwardspaperIter] = ' ';
                    if(exisitingText[backwardspaperIter] != ' ')
                        EraserDurability--;
                }
            }
            exisitingText = new string(newPaperText);
        }

        /// <summary>
        /// Fills the last gap of spaces in the given text with a given phrase
        /// </summary>
        /// <param name="inputText">The text to be inserted</param>
        /// <param name="exisitingText">the text to to insert into</param>
        public void EditAppend(string inputText, ref string exisitingText)
        {
            if (inputText == null || exisitingText == null)
                return;
            MatchCollection matches = Regex.Matches(exisitingText, @"   +");
            Match lastMatch = matches[matches.Count - 1]; //get last match
            int operationStartIndex = lastMatch.Index + 1; // +1 to ignore the leading space
            char[] newPaperText = exisitingText.ToArray<Char>();
            int inputIterater = 0;
            for(int i = operationStartIndex; inputIterater < inputText.Length; i++)
            {
                int neededDurability = RequiredDurability(inputText[inputIterater]);
                if (Durability - neededDurability >= 0)
                {
                    if (newPaperText[i] == ' ' || inputText[inputIterater] == ' ')
                        newPaperText[i] = inputText[inputIterater];
                    else
                        newPaperText[i] = '@';
                    Durability -= neededDurability;
                }
                inputIterater++;
            }
            exisitingText = new string(newPaperText);
        }
    }
}
