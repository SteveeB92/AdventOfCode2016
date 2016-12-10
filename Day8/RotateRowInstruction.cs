using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public class RotateRowInstruction : Instructions
    {
        public const string ROTATE_ROW = "rotate row";
        public int row { get; private set; }

        public RotateRowInstruction(string line, int screenSize)
        {
            int row;
            ParseAxisAndShiftAmount(line.Substring(ROTATE_ROW.Length), out row, screenSize);
            this.row = row;
        }
    }
}
