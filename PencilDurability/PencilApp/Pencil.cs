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
            existingText += inputText;
            Durability -= 5;
        }
    }
}
