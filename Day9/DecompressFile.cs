using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    public class DecompressFile
    {
        public List<DecompressedLine> decompressedLines { get; private set; }

        public DecompressFile(string path, bool isPart1)
        {
            decompressedLines = new List<DecompressedLine>();
            using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
            using (BufferedStream bufferedStream = new BufferedStream(fileStream))
            using (StreamReader streamReader = new StreamReader(bufferedStream))
            {
                while (!streamReader.EndOfStream)
                {
                    DecompressedLine decompressedLine = new DecompressedLine(streamReader.ReadLine(), isPart1);
                    decompressedLines.Add(decompressedLine);
                }
            }
        }

        public int DecompressedLengthOfFilePart1()
        {
            int length = 0;
            foreach(DecompressedLine decompressedLine in decompressedLines)
            {
                length += decompressedLine.decompressedLine.Length;
            }
            return length;
        }

        public long DecompressedLengthOfFilePart2()
        {
            long length = 0;
            foreach (DecompressedLine decompressedLine in decompressedLines)
            {
                length += decompressedLine.part2Length;
            }
            return length;
        }
    }
}
