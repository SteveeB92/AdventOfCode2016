using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public class RotateColumnInstruction : Instructions
    {
        public const string ROTATE_COLUMN = "rotate column";
        public int column { get; private set; }

        public RotateColumnInstruction(string line, int screenSize)
        {
            int column;
            ParseAxisAndShiftAmount(line.Substring(ROTATE_COLUMN.Length), out column, screenSize);
            this.column = column;
        }
    }
}
