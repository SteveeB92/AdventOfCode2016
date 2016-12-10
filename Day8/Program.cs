using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    class Program
    {
        private const string PATH = @"..\..\Day8.txt";
        static void Main(string[] args)
        {
            Screen screen = new Screen(50, 6, PATH);
            int amountOfPixelsLit = screen.AmountOfPixelsTurnedOn();
            Console.Out.WriteLine($"Part 1: Amount of pixels lit: {amountOfPixelsLit}");
            screen.PrintScreenToConsole();
            Console.ReadKey();
        }
    }
}
