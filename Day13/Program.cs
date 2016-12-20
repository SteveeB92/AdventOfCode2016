using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13
{
    class Program
    {
        private const int PUZZLE_INPUT = 1364;
        static void Main(string[] args)
        {
            Office office = new Office(50, 60, PUZZLE_INPUT);
            int shortestPathDistance = office.FindShortestPathToLocation(31, 39);
            Console.Out.WriteLine($"Shortest path distance: {shortestPathDistance}");
            Console.ReadKey();
        }
    }
}
