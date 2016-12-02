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
				int currentDirection = 360;
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
							xLocation -= moveAmount;
							break;
						case 180:
							yLocation -= moveAmount;
							break;
						case 270:
							xLocation += moveAmount;
							break;
					}

				}
				int distance = Math.Abs(xLocation) + Math.Abs(yLocation);
				Console.Write($"X Location: { xLocation }, Y Location { yLocation }, Distance {distance}");
				Console.ReadKey(true);
			}
		}
	}
}
