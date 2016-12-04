using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class Program
    {
        private const string PATH = @"..\..\Day3.txt";

        public static void Main(string[] args)
        {
            int amountOfPossibleTriangles = amountOfPossibleTrianglesPart1(PATH);
            Console.Out.WriteLine($"Part 1. Possible Triangles: {amountOfPossibleTriangles}");

            amountOfPossibleTriangles = amountOfPossibleTrianglesPart2(PATH);
            Console.Out.WriteLine($"Part2. Possible Triangles: {amountOfPossibleTriangles}");

            Console.ReadKey();
        }

        public static int amountOfPossibleTrianglesPart1(string path)
        {
            int amountOfPossibleTriangles = 0;
            using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
            using (BufferedStream bufferedStream = new BufferedStream(fileStream))
            using (StreamReader streamReader = new StreamReader(bufferedStream))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    line = removeExcessSpaces(line);
                    string[] lengths = line.Split(' ');

                    if (isPossibleTriangle(lengths[0], lengths[1], lengths[2]))
                        amountOfPossibleTriangles++;
                }
            }
            return amountOfPossibleTriangles;
        }


        public static int amountOfPossibleTrianglesPart2(string path)
        {
            int amountOfPossibleTriangles = 0;
            using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
            using (BufferedStream bufferedStream = new BufferedStream(fileStream))
            using (StreamReader streamReader = new StreamReader(bufferedStream))
            {
                while (!streamReader.EndOfStream)
                {
                    /*  Format:
                     *  1  2  3
                     *  1  2  3
                     *  1  2  3
                     *  4  5  6
                     *  .  .  .
                     */
                    string[][] columns = new string[3][];
                    for (int i = 0; i < 3; i++)
                    {
                        string line = streamReader.ReadLine();
                        line = removeExcessSpaces(line);
                        string[] lengths = line.Split(' ');
                        columns[i] = lengths;
                    }

                    for (int x = 0; x < 3; x++)
                    {
                        amountOfPossibleTriangles += isPossibleTriangle(columns[0][x], columns[1][x], columns[2][x]) ? 1 : 0;
                    }
                }
            }
            return amountOfPossibleTriangles;
        }

        public static string removeExcessSpaces(string line)
        {
            return line.TrimStart().Replace("   ", " ").Replace("  ", " ");
        }

        public static bool isPossibleTriangle(string firstSideString, string secondSideString, string thirdSideString)
        {
            int firstSide = int.Parse(firstSideString);
            int secondSide = int.Parse(secondSideString);
            int thirdSide = int.Parse(thirdSideString);

            //If the smaller two sides are more than the other side than this is a possible triangle
            int smallestSidesLength = findLengthOfTwoSmallestSides(firstSide, secondSide, thirdSide);
            int largestSideLength = findLargestSideLength(firstSide, secondSide, thirdSide);
            return smallestSidesLength > largestSideLength;
        }

        public static int findLengthOfTwoSmallestSides(int firstSide, int secondSide, int thirdSide)
        {
            return Math.Min(firstSide + secondSide, Math.Min(secondSide + thirdSide, thirdSide + firstSide));
        }

        public static int findLargestSideLength(int firstSide, int secondSide, int thirdSide)
        {
            return Math.Max(firstSide, Math.Max(secondSide, thirdSide));
        }
    }
}
