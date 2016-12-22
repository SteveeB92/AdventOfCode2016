using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridComputing
{
    class Program
    {
        private const string PATH = @"..\..\Disk Usage.txt";
        static void Main(string[] args)
        {
            FileSystem fileSystem = new FileSystem(PATH);
            Console.Out.WriteLine($"Amount of valid pairs {fileSystem.amountOfPairs}");
            Console.ReadKey();
        }
    }
}
