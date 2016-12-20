using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19
{
    public class Elf
    {
        public Elf _nextElf { get; set; }
        public int _position { get; private set; }
        public int _presentCount { get; set; }

        public Elf(int position, int presentCount)
        {
            _position = position;
            _presentCount = presentCount;
        }
    }
}
