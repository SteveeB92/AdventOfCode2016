using System;
using System.Security.Cryptography;
using System.Text;

namespace Day5
{
    public class Program
    {
        static string DOOR_ID = "cxdnnyjw";

        public static void Main(string[] args)
        {
            //string password = findPasswordForDoorPart1(DOOR_ID);
            //Console.Out.WriteLine($"Password for door is: {password}");
            string passwordPart2 = findPasswordForDoorPart2(DOOR_ID);
            Console.Out.WriteLine($"Part2: Password for door is: {passwordPart2}");

            Console.ReadKey();
        }

        public static string findPasswordForDoorPart1(string doorID)
        {
            string password = string.Empty;
            int i = 0;
            StringBuilder passwordSB = new StringBuilder();

            while (passwordSB.Length < 8)
            {
                string hashedString = generateHash(doorID, i++);

                if (hashedString.Substring(0, 5).Equals("00000"))
                    passwordSB.Append(hashedString.ToCharArray()[5]);
            }

            return passwordSB.ToString();
        }

        public static string findPasswordForDoorPart2(string doorID)
        {
            string password = string.Empty;
            StringBuilder passwordSB = new StringBuilder();
            passwordSB.Append("        ");
            int i = 0;
            while (passwordSB.ToString().Contains(" "))
            {
                string hashedString = generateHash(doorID, i++);

                if (hashedString.Substring(0, 5).Equals("00000"))
                {
                    int position = (int) hashedString.ToCharArray()[5] - '0';
                    //Check position is valid and we have not already filled this spot
                    if (isPositionValid(position) && passwordSB.ToString().ToCharArray()[position] == ' ')
                    {
                        //Remove placeholder char at position
                        passwordSB.Remove(position, 1);
                        //Add correct char
                        passwordSB.Insert(position, hashedString.ToCharArray()[6]);
                    }
                }
            }

            return passwordSB.ToString();
        }

        public static string generateHash(string doorID, int index)
        {
            MD5 md5Hash = MD5.Create();
            string newHash = doorID + index;
            byte[] hashedBytes = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(newHash));

            StringBuilder hashedSB = new StringBuilder();
            foreach (byte hashedByte in hashedBytes)
            {
                //Convert to hexadecimal and add to SB
                hashedSB.Append(hashedByte.ToString("x2"));
            }
            md5Hash.Dispose();
            return hashedSB.ToString();
        }

        public static bool isPositionValid(int position)
        {
            //Is the char between 0 and 7 inclusively?
            return position >= 0 && position <= 7;
        }
    }
}
