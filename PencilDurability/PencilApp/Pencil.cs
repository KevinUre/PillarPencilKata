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
        public int Durability;
        private int initialDurability;
        public int Length;

        public Pencil (int startingDurability, int startingLength)
        {
            initialDurability = startingDurability;
            Durability = startingDurability;
            Length = startingLength;
        }

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
                    neededDurability = 1;
                if (Durability - neededDurability < 0)
                    existingText += " ";
                else
                {
                    existingText += inputText[i];
                    Durability -= neededDurability;
                }
            }
        }

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
