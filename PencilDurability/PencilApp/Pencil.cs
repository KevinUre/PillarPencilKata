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

        public Pencil (int initialDurability)
        {
            Durability = initialDurability;
        }

        public void Write(string inputText, ref string existingText)
        {
            if (inputText == null)
                return;
            for(int i = 0; i < inputText.Length; i++)
            {
                if (Durability == 0)
                    break;
                existingText += inputText[i];
                if (inputText[i] != ' ')
                    Durability--;
            }
        }
    }
}
