using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    class Program
    {
        private static string path = @"..\..\Day9.txt";
        static void Main(string[] args)
        {
            DecompressFile decompressedFile = new DecompressFile(path, true);
            int lengthOfFile = decompressedFile.DecompressedLengthOfFilePart1();
            Console.Out.WriteLine($"Part 1. Length of Decompressed File: {lengthOfFile}");

            decompressedFile = new DecompressFile(path, false);
            long lengthOfFilePart2 = decompressedFile.DecompressedLengthOfFilePart2();

            Console.Out.WriteLine($"Part 2. Length of Decompressed File: {lengthOfFilePart2}");
            Console.ReadKey();
        }
    }
}
