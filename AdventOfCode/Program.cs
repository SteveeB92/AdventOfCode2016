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
			using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
			using (BufferedStream bufferedStream = new BufferedStream(fileStream))
			using (StreamReader streamReader = new StreamReader(bufferedStream))
			{
				int xLocation = 0;
				int yLocation = 0;
                int previousXLocation = 0;
                int previousYLocation = 0;
				int currentDirection = 3600;
                var coordinatesVisited = new HashSet<Tuple<int, int>>();
                coordinatesVisited.Add(new Tuple<int, int>(xLocation, yLocation));
                bool firstLocationVsitedTwiceFound = false;

                string line = streamReader.ReadToEnd();
				string[] instructions = line.Split(',');
                foreach (string instruction in instructions)
                {
                    string trimmedInstruction = instruction.Trim();
                    Directions direction = (Directions)trimmedInstruction.ToCharArray()[0];
                    int moveAmount = int.Parse(trimmedInstruction.Substring(1));
                    switch (direction)
                    {
                        case Directions.RIGHT:
                            //Turn the character right
                            currentDirection += 90;
                            break;
                        case Directions.LEFT:
                            //Turn the character left
                            currentDirection -= 90;
                            break;
                        default:
                            Console.Write($"Direction not found {trimmedInstruction.ToCharArray()[0]}");
                            break;
                    }

                    switch (currentDirection % 360)
                    {
                        case 0:
                            yLocation += moveAmount;
                            break;
                        case 90:
                            xLocation += moveAmount;
                            break;
                        case 180:
                            yLocation -= moveAmount;
                            break;
                        case 270:
                            xLocation -= moveAmount;
                            break;
                    }
                    if (!firstLocationVsitedTwiceFound)
                    {
                        Tuple<int, int> coordinates = new Tuple<int, int>(xLocation, yLocation);
                        for (int x = Math.Min(previousXLocation, coordinates.Item1); x <= Math.Max(previousXLocation, coordinates.Item1); x++)
                        {
                            for (int y = Math.Min(previousYLocation, coordinates.Item2); y <= Math.Max(previousYLocation, coordinates.Item2); y++)
                            {
                                if (previousXLocation == x && previousYLocation == y)
                                    continue;
                                if (!coordinatesVisited.Add(new Tuple<int, int>(x, y)))
                                {
                                    int distanceToCoords = Math.Abs(x) + Math.Abs(y);
                                    Console.WriteLine($"First location: X Location: { x }, Y Location { y }, Distance {distanceToCoords}");
                                    firstLocationVsitedTwiceFound = true;
                                }
                            }
                        }
                        previousXLocation = xLocation;
                        previousYLocation = yLocation;
                    }
				}
				int distance = Math.Abs(xLocation) + Math.Abs(yLocation);
				Console.Write($"X Location: { xLocation }, Y Location { yLocation }, Distance {distance}");
				Console.ReadKey(true);
			}
		}
	}
}
