using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    public class Marker
    {
        private const char MARKER_DIVIDER = 'x';
        
        public string marker { get; private set; }
        public int length { get; private set; }
        public int repeatAmount { get; private set; }
        public int amountOfCharsToRepeat { get; private set; }
        public bool validMarker { get; private set; }
        public int indexOfMarker { get; private set; }

        public Marker(string marker, int indexOfMarker)
        {
            int repeatAmount;
            int amountOfCharsToRepeat;
            if (!int.TryParse(marker.Substring(1, marker.IndexOf(MARKER_DIVIDER) - 1), out amountOfCharsToRepeat)
                & int.TryParse(marker.Substring(marker.IndexOf(MARKER_DIVIDER) + 1), out repeatAmount))
            {
                //Invalid Marker - we have set the location so this marker will be skipped for further processing
                validMarker = false;
                this.length = marker.Length;
                this.marker = marker;
                return;
            }

            this.marker = marker;
            this.repeatAmount = repeatAmount;
            this.amountOfCharsToRepeat = amountOfCharsToRepeat;
            validMarker = true;
            this.length = marker.Length + 1;
            this.indexOfMarker = indexOfMarker;
        }
    }
}
