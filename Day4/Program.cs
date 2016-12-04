using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class Program
    {
        private const string PATH = @"..\..\Day4.txt";
        public static void Main(string[] args)
        {
            int sumOfSectorIDs = sumOfRealRoomSectorIDsPart1(PATH);
            Console.Out.WriteLine(sumOfSectorIDs);
            Console.ReadKey();
        }

        public static int sumOfRealRoomSectorIDsPart1(string path)
        {
            int sumOfSectorIDs = 0;
            using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
            using (BufferedStream bufferedStream = new BufferedStream(fileStream))
            using (StreamReader streamReader = new StreamReader(bufferedStream))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    sumOfSectorIDs += sectionIDIfReal(line);
                }
            }
            return sumOfSectorIDs;
        }

        public static int sectionIDIfReal(string line)
        {
            string[] lineSections = line.Split('-');
            int[] charAmounts = new int[(int)'z' - 'a' + 1];
            char[] checksum;
            int sectionID = 0;
            foreach (string section in lineSections)
            {
                if (tryParseSectorIDChecksum(section, out sectionID, out checksum))
                {
                    if (!checksum.SequenceEqual(findCorrectChecksum(charAmounts)))
                        return 0;
                }
                else
                {
                    charAmounts = amountOfCharactersInSection(section, charAmounts);
                }
            }
            return sectionID;
        }

        public static bool tryParseSectorIDChecksum(string section, out int sectionID, out char[] checksum)
        {
            //Does the section contain numbers up to the "["?
            int indexOfSquareBracket = section.IndexOf('[');
            if (indexOfSquareBracket > 0)
            {
                sectionID = int.Parse(section.Substring(0, indexOfSquareBracket));
                checksum = section.Substring(indexOfSquareBracket + 1, section.IndexOf(']') - indexOfSquareBracket - 1).ToCharArray();
                return true;
            }
            checksum = null;
            sectionID = 0;
            return false;
        }

        public static int[] amountOfCharactersInSection(string section, int[] amountOfCharacters)
        {
            // Count the letters into our array
            foreach (char character in section.ToCharArray())
            {
                amountOfCharacters[(int)character - 'a'] += 1;
            }
            return amountOfCharacters;
        }

        public static char[] findCorrectChecksum(int[] charactersAmounts)
        {
            char[] checksum = new char[5];
            //1st character is the highest amount...
            //2nd character is the second highest amount...
            //3rd, 4th, 5th etc
            for (int i = (int) 'a'; i <= (int)'z'; i++)
            {
                for (int j = 0; j < checksum.Length; j++)
                {
                    if (i == (int)checksum[j])
                        break;
                    if (checksum[j] - 'a' < 0 || charactersAmounts[i - 'a'] > charactersAmounts[checksum[j] - 'a'])
                    {
                        checksum = shuffleDownChars(checksum, j, (char) i);
                        break;
                    }
                }
            }
            return checksum;
        }

        public static char[] shuffleDownChars(char[] checksum, int position, char character)
        {
            for(int i = checksum.Length - 1; i > position; i--)
            {
                checksum[i] = checksum[i - 1];
            }

            checksum[position] = character;
            return checksum;
        }
    }
}
