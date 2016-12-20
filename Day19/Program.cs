using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19
{
    class Program
    {
        static void Main(string[] args)
        {
            ElephantGame game = new ElephantGame(3014387);
            int positionOfWinner = game._winningElf._position;
            Console.Out.Write($"Position of Winning Elf {positionOfWinner}");
            Console.ReadKey();
        }
    }
}
