using System;
using System.IO;

namespace Day8
{
    public class Screen
    {
        public bool[,] screenDisplay { get; set; }
        
        public Screen (int screenWidth, int screenHeight, string path)
        {
            this.screenDisplay = new bool[screenHeight, screenWidth];
            InitialiseScreen(path);
        }

        public void InitialiseScreen(string path)
        {
            using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
            using (BufferedStream bufferedStream = new BufferedStream(fileStream))
            using (StreamReader streamReader = new StreamReader(bufferedStream))
            {
                while (!streamReader.EndOfStream)
                {
                    ProcessLine(streamReader.ReadLine());
                }
            }
        }

        public void ProcessLine(string line)
        {
            if (line.Substring(0, RectangleInstruction.RECTANGLE.Length).Equals(RectangleInstruction.RECTANGLE))
            {
                RectangleInstruction rectangleInstruction = new RectangleInstruction(line);
                ProcessRectangleInstruction(rectangleInstruction);
            }
            else if (line.Substring(0, RotateRowInstruction.ROTATE_ROW.Length).Equals(RotateRowInstruction.ROTATE_ROW))
            {
                RotateRowInstruction rotateRowInstruction = new RotateRowInstruction(line, screenDisplay.GetLength(1));
                ProcessRotateRow(rotateRowInstruction);
            }
            else if (line.Substring(0, RotateColumnInstruction.ROTATE_COLUMN.Length).Equals(RotateColumnInstruction.ROTATE_COLUMN))
            {
                RotateColumnInstruction rotateColumnInstruction = new RotateColumnInstruction(line, screenDisplay.GetLength(0));
                ProcessRotateColumn(rotateColumnInstruction);
            }
        }

        /// <summary>
        /// Turns on the top left hand corner of the _screenDisplay array by the specified amount.
        /// </summary>
        /// <param name="rectangleSize">String representation of the width and height to turn on e.g "4x2"</param>
        public void ProcessRectangleInstruction(RectangleInstruction rectangleInstruction)
        {
            if (rectangleInstruction.x > screenDisplay.GetLength(1))
                throw new ArgumentOutOfRangeException("x", rectangleInstruction.x, $"Rectangle width {rectangleInstruction.x} is greater than display size {screenDisplay.GetLength(1)}");
            if (rectangleInstruction.y > screenDisplay.GetLength(0))
                throw new ArgumentOutOfRangeException("y", rectangleInstruction.y, $"Rectangle height {rectangleInstruction.y} is greater than display size {screenDisplay.GetLength(0)}");

            //Always start in top left hand corner
            for (int i = 0; i < rectangleInstruction.x; i++)
                for (int j = 0; j < rectangleInstruction.y; j++)
                    screenDisplay[j,i] = true;
        }

        /// <summary>
        /// rotate row y=A by B shifts all of the pixels in row A (0 is the top row) right by B pixels. 
        /// Pixels that would fall off the right end appear at the left end of the row.
        /// </summary>
        /// <param name="instruction">e.g "y=5 by 20"</param>
        public void ProcessRotateRow(RotateRowInstruction rotateRowInstruction)
        {
            int width = screenDisplay.GetLength(1);
            bool[,] copyOfScreenDisplay = (bool[,])screenDisplay.Clone();
            for (int i = 0; i < width; i++)
            {
                screenDisplay[rotateRowInstruction.row, (i + rotateRowInstruction.shiftAmount) % width] = copyOfScreenDisplay[rotateRowInstruction.row, i];
            }
        }

        /// <summary>
        /// rotate column x=A by B shifts all of the pixels in column A (0 is the left column) down by B pixels. 
        /// Pixels that would fall off the bottom appear at the top of the column.
        /// </summary>
        /// <param name="instruction">e.g. "x=3 by 2"</param>
        public void ProcessRotateColumn(RotateColumnInstruction rotateColumnInstruction)
        {
            int height = screenDisplay.GetLength(0);
            bool[,] copyOfScreenDisplay = (bool[,]) screenDisplay.Clone();
            for (int i = 0; i < height; i++)
            {
                screenDisplay[(i + rotateColumnInstruction.shiftAmount) % height, rotateColumnInstruction.column] = copyOfScreenDisplay[i, rotateColumnInstruction.column];
            }
        }

        public int AmountOfPixelsTurnedOn()
        {
            int amountOfPixelsOn = 0;
            for (int i = 0; i < screenDisplay.GetLength(0); i++)
                for (int j = 0; j < screenDisplay.GetLength(1); j++)
                    amountOfPixelsOn += screenDisplay[i, j] ? 1 : 0;

            return amountOfPixelsOn;
        }

        public void PrintScreenToConsole()
        {
            for (int i = 0; i < screenDisplay.GetLength(0); i++)
            {
                for (int j = 0; j < screenDisplay.GetLength(1); j++)
                    Console.Write(screenDisplay[i, j] ? 'm' : ' ');
                Console.WriteLine();
            }
        }
    }
}
