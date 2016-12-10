using System;

namespace Day8
{
    public class Instructions
    {
        protected const string BY_SEPERATOR = "by";

        public int shiftAmount { get; private set; }

        public void ParseAxisAndShiftAmount(string instruction, out int axis, int screenSize)
        {
            int shiftAmount;
            if (!(int.TryParse(instruction.Substring(3, instruction.IndexOf(BY_SEPERATOR) - 4), out axis) &
                 int.TryParse(instruction.Substring(instruction.IndexOf(BY_SEPERATOR) + BY_SEPERATOR.Length), out shiftAmount)))
                throw new Exception($"Failed to parse instruction {instruction}");

            this.shiftAmount = shiftAmount % screenSize;
        }
    }
}
