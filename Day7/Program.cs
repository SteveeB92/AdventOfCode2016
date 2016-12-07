using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    class Program
    {
        private const string PATH = @"..\..\Day7.txt";

        static void Main(string[] args)
        {
            int noOfSupportedIPS = amountOfIPsSupportingTLS(PATH);
            Console.Out.WriteLine($"Part 1. Amount of TLS supported IPS: {noOfSupportedIPS}");
            Console.ReadKey();
        }

        public static int amountOfIPsSupportingTLS(string path)
        {
            int noOfSupportedIPs = 0;
            using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
            using (BufferedStream bufferedStream = new BufferedStream(fileStream))
            using (StreamReader streamReader = new StreamReader(bufferedStream))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    LineSections lineSection = new LineSections(line);

                    noOfSupportedIPs += lineSection.isIPSupportsTLS() ? 1 : 0;
                }
            }
            return noOfSupportedIPs;
        }
    }
}
