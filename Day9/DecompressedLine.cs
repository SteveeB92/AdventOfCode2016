using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    public class DecompressedLine
    {
        private const char MARKER_START = '(';
        private const char MARKER_END = ')';

        public string decompressedLine { get; private set;}
        public long part2Length { get; private set; }

        public DecompressedLine(string line, bool isPart1)
        {
            if (isPart1)
                ParseLine(line);
            else
                ParseLinePart2(line, 1);
        }

        public void ParseLine(string line)
        {
            //Remove white space
            line = line.Replace(" ", string.Empty);
            StringBuilder decompressedLineBuilder = new StringBuilder();
            Marker marker;
            while(TryParseNextMarker(line, out marker) && marker.validMarker)
            {
                //Append the string up until the start of the marker to the builder
                decompressedLineBuilder.Append(line.Substring(0, marker.indexOfMarker));
                //Remove marker from string
                line = line.Substring(marker.indexOfMarker + marker.length);

                if (marker.repeatAmount > 0)
                {
                    for (int i = 0; i < marker.repeatAmount; i++)
                    {
                        decompressedLineBuilder.Append(line.Substring(0, marker.amountOfCharsToRepeat));
                    }
                }

                line = line.Substring(marker.amountOfCharsToRepeat);
            }
            decompressedLineBuilder.Append(line);
            decompressedLine = decompressedLineBuilder.ToString();
        }

        public void ParseLinePart2(string line, int markerMultiplier)
        {
            //Remove white space
            line = line.Replace(" ", string.Empty);
            Marker marker;
            while (TryParseNextMarker(line, out marker))
            {
                int innerMarkerMultiplier = markerMultiplier;
                //Add the length of the string up until a marker location
                part2Length += marker.indexOfMarker;
                //Remove marker from string
                line = line.Substring(marker.indexOfMarker + marker.length);

                int amountOfMarkerProcessed = 0;
                innerMarkerMultiplier = markerMultiplier * marker.repeatAmount;
                ParseLinePart2(line.Substring(amountOfMarkerProcessed, marker.amountOfCharsToRepeat - amountOfMarkerProcessed), innerMarkerMultiplier);
                
                line = line.Substring(marker.amountOfCharsToRepeat);
            }
            part2Length += line.Length * markerMultiplier;
        }

        public bool TryParseNextMarker(string line, out Marker marker)
        {
            int indexOfNextMarker = line.IndexOf(MARKER_START);

            if (indexOfNextMarker >= 0)
            {
                line = line.Substring(indexOfNextMarker);
                marker = new Marker(line.Substring(0, line.IndexOf(MARKER_END)), indexOfNextMarker);
                return true;
            }
            marker = null;
            return false;
        }
    }
}
