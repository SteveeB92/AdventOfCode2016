using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {

        enum Directions
        {
            RIGHT = 'R',
            LEFT = 'L',
            UP = 'U',
            DOWN = 'D'
        }

        private const string PATH = @"..\..\Day2.txt";
        private const int MAX_X = 3;
        private const int MAX_Y = 3;
        private const int MIN_X = 1;
        private const int MIN_Y = 1;
        private const char EMPTY_CHAR = '-';

        private static char[][] part2Keypad = new char[][] { new char[] { EMPTY_CHAR, EMPTY_CHAR, '1', EMPTY_CHAR, EMPTY_CHAR },
                                                             new char[] { EMPTY_CHAR, '2', '3', '4', EMPTY_CHAR },
                                                             new char[] { '5', '6', '7', '8', '9'},
                                                             new char[] { EMPTY_CHAR, 'A', 'B', 'C', EMPTY_CHAR },
                                                             new char[] { EMPTY_CHAR, EMPTY_CHAR, 'D', EMPTY_CHAR, EMPTY_CHAR } };

        static void Main(string[] args)
        {
            string accessCode = getAccessCodePart1();
            Console.Out.WriteLine($"Part 1: {accessCode}");
            accessCode = getAccessCodePart2();
            Console.Out.WriteLine($"Part 2: {accessCode}");
            Console.ReadKey(true);
        }

        private static string getAccessCodePart1()
        {
            string accessCode = string.Empty;
            using (FileStream fileStream = File.Open(PATH, FileMode.Open, FileAccess.Read))
            using (BufferedStream bufferedStream = new BufferedStream(fileStream))
            using (StreamReader streamReader = new StreamReader(bufferedStream))
            {
                int x = 2;
                int y = 2; // Start at position 5
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    char[] instructions = line.ToCharArray();
                    foreach (Directions direction in instructions)
                    {
                        switch (direction)
                        {
                            case Directions.RIGHT:
                                x += x == MAX_X ? 0 : 1;
                                break;
                            case Directions.LEFT:
                                x -= x == MIN_X ? 0 : 1;
                                break;
                            case Directions.UP:
                                y -= y == MIN_Y ? 0 : 1;
                                break;
                            case Directions.DOWN:
                                y += y == MAX_Y ? 0 : 1;
                                break;
                            default:
                                break;
                        }
                    }
                    accessCode += ((y - 1) * MAX_X) + x;
                }
            }
            return accessCode;
        }

        private static string getAccessCodePart2()
        {
            string accessCode = string.Empty;
            using (FileStream fileStream = File.Open(PATH, FileMode.Open, FileAccess.Read))
            using (BufferedStream bufferedStream = new BufferedStream(fileStream))
            using (StreamReader streamReader = new StreamReader(bufferedStream))
            {
                int x = 1;
                int y = 3;// Start at position 5
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    char[] instructions = line.ToCharArray();
                    foreach (Directions direction in instructions)
                    {
                        switch (direction)
                        {
                            case Directions.RIGHT:
                                x += part2Keypad[y].Length > x + 1 && part2Keypad[y][x + 1] != EMPTY_CHAR ? 1 : 0;
                                break;
                            case Directions.LEFT:
                                x -= x > 0 && part2Keypad[y][x - 1] != EMPTY_CHAR ? 1 : 0;
                                break;
                            case Directions.UP:
                                y -= y > 0 && part2Keypad[y - 1][x] != EMPTY_CHAR ? 1 : 0;
                                break;
                            case Directions.DOWN:
                                y += part2Keypad.Length > y + 1 && part2Keypad[y + 1][x] != EMPTY_CHAR ? 1 : 0; ;
                                break;
                            default:
                                break;
                        }
                    }
                    accessCode += part2Keypad[y][x];
                }
            }

            return accessCode;
        }
    }
}
