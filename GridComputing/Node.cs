using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridComputing
{
    class Node
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public int totalSpace { get; private set; }
        public int spaceUsed { get; private set; }
        public int availSpace { get; private set; }
        public bool isTargetData { get; set; }

        public Node(string diskUsage)
        {
            ParseDiskUsage(diskUsage);
        }

        public void ParseDiskUsage(string diskUsage)
        {
            //Format
            // Filesystem              Size  Used  Avail  Use%
            // /dev/grid/node-x0-y0     91T   71T    20T   78 %
            diskUsage = diskUsage.Replace("  ", " ").Replace("  ", " ").Replace("  ", " ");

            string[] splitUsage = diskUsage.Split(' ');
            x = int.Parse(splitUsage[0].Substring(splitUsage[0].IndexOf('x') + 1, splitUsage[0].Substring(splitUsage[0].IndexOf('x')).IndexOf('-') - 1));
            x = int.Parse(splitUsage[0].Substring(splitUsage[0].IndexOf('y') + 1));

            totalSpace = int.Parse(splitUsage[1].Substring(0, splitUsage[1].IndexOf('T')));
            spaceUsed = int.Parse(splitUsage[2].Substring(0, splitUsage[2].IndexOf('T')));
            availSpace = int.Parse(splitUsage[3].Substring(0, splitUsage[3].IndexOf('T')));
        }
    }
}
