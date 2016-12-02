using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    
    class Program
    {

        enum Directions
        {
            RIGHT = 'R',
            LEFT = 'L'
        }

        private static string path = @"..\..\Day1.txt";
        static void Main(string[] args)
        {
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                int xLocation = 0;
                int yLocation = 0;
                int currentDirection = 0;
                string line = sr.ReadToEnd();
                string[] instructions = line.Split(',');
                foreach(string instruction in instructions)
                {
                    string trimmedInstruction = instruction.Trim();
                    Directions direction = (Directions)trimmedInstruction.ToCharArray()[0];
                    int moveAmount = int.Parse(trimmedInstruction.Substring(1));

                    switch (direction)
                    {
                        case Directions.RIGHT:
                            //Turn the character right and move the character that amount
                            currentDirection += 90;
                            break;
                        case Directions.LEFT:
                            currentDirection -= 90;
                            break;
                        default:
                            break;
                    }

                    if (currentDirection % 360 == 0)
                    {
                        yLocation += moveAmount;
                    }
                    else if (currentDirection % 270 == 0)
                    {
                        xLocation -= moveAmount;
                    }
                    else if (currentDirection % 180 == 0)
                    {
                        yLocation -= moveAmount;
                    }
                    else 
                    {
                        xLocation += moveAmount;
                    }

                }
                int distance = (xLocation > 0 ? xLocation : xLocation * -1)
                                + (yLocation > 0 ? yLocation : yLocation * -1);
                Console.Write($"X Location: { xLocation }, Y Location { yLocation }, Distance {distance}");
                Console.Out.Write($"X Location: { xLocation }, Y Location { yLocation }");
            }
        }
    }
}
