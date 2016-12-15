using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13
{
    public class Location
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public int movesTakenToReach;

        public Location(int x, int y, int movesTakenToReach)
        {
            this.x = x;
            this.y = y;
            this.movesTakenToReach = movesTakenToReach;
        }
        
    }
}
