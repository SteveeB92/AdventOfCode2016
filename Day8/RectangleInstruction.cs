using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public class RectangleInstruction
    {

        public const string RECTANGLE = "rect";
        private const char SIZE_SEPERATOR = 'x';
        public int x { get; private set; }
        public int y { get; private set; }
        
        public RectangleInstruction(string line)
        {
            string instruction = line.Substring(RECTANGLE.Length);
            x = int.Parse(instruction.Substring(0, instruction.IndexOf(SIZE_SEPERATOR)));
            y = int.Parse(instruction.Substring(instruction.IndexOf(SIZE_SEPERATOR) + 1));
        }
    }
}
