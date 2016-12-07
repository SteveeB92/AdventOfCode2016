using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day6
{
    public class Program
    {

        private const string PATH = @"..\..\Day6.txt";
        public static void Main(string[] args)
        {
            string correctMessage = correctedMessage(PATH, true);
            Console.Out.WriteLine($"Part 1. Corrected Message: {correctMessage}");
            correctMessage = correctedMessage(PATH, false);
            Console.Out.WriteLine($"Part 2. Corrected Message: {correctMessage}");
            Console.ReadKey();
        }

        public static string correctedMessage(string path, bool isPart1)
        {
            List<string> lines = new List<string>();
            using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
            using (BufferedStream bufferedStream = new BufferedStream(fileStream))
            using (StreamReader streamReader = new StreamReader(bufferedStream))
            {
                while(!streamReader.EndOfStream)
                {
                    lines.Add(streamReader.ReadLine());
                }
            }
            return findCorrectedMessageFromList(lines, isPart1);
        }

        public static string findCorrectedMessageFromList(List<string> lines, bool isPartOne)
        {
            StringBuilder messageBuilder = new StringBuilder();
            for (int i = 0; i < lines.First<string>().Length; i++)
            {
                char mostCommonCharInColumn = findMostOrLeastCommonCharInListForColumn(lines, i, isPartOne);
                messageBuilder.Append(mostCommonCharInColumn);
            }
            return messageBuilder.ToString();
        }

        /// <summary>
        /// Finds the most or least common char in a given column.
        /// </summary>
        /// <param name="lines">List to do the search for most/least common char on</param>
        /// <param name="column">char index to find common char at</param>
        /// <param name="isMostCommon">True if searching for most common. False if searching for least column</param>
        /// <returns>Most or least common char in column</returns>
        public static char findMostOrLeastCommonCharInListForColumn(List<string> lines, int column, bool isMostCommon)
        {
            string commonString;
            if (isMostCommon)
            {
                commonString = lines.GroupBy(s => s.Substring(column, 1))
                                            .OrderByDescending(s => s.Count())
                                            .First()
                                            .Key;
            }
            else
            {
                commonString = lines.GroupBy(s => s.Substring(column, 1))
                                            .OrderBy(s => s.Count())
                                            .First()
                                            .Key;
            }
            return commonString.ToCharArray()[0];
        }
    }
}
