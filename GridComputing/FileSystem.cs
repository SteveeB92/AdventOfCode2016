using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridComputing
{
    class FileSystem
    {
        List<Node> nodes = new List<Node>();
        List<Node> nodePairs;
        public int amountOfPairs { get; private set; }

        public FileSystem(string path)
        {
            using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
            using (BufferedStream bufferedStream = new BufferedStream(fileStream))
            using (StreamReader streamReader = new StreamReader(bufferedStream))
            {
                //Skip first two lines
                if (!streamReader.EndOfStream)
                {
                    streamReader.ReadLine();
                    if (!streamReader.EndOfStream)
                    {
                        streamReader.ReadLine();

                        while (!streamReader.EndOfStream)
                        {
                            string diskUsage = streamReader.ReadLine();
                            nodes.Add(new Node(diskUsage));
                        }
                    }
                }
            }

            FindNodePairs();
        }

        /// <summary>
        /// Finds pairs of nodes. Two nodes are a pair if:
        ///     Node A is not empty (its Used is not zero).
        ///     Nodes A and B are not the same node.
        ///     The data on node A(its Used) would fit on node B(its Avail).
        /// 
        /// Sets the amount of pairs property
        /// </summary>
        public void FindNodePairs()
        {
            var nodePairs = from sourceNodes in nodes.Where(sourceNode => sourceNode.spaceUsed > 0)
                            from destinationNodes in nodes
                            where sourceNodes.spaceUsed <= destinationNodes.availSpace
                            where sourceNodes != destinationNodes
                            select sourceNodes;

            amountOfPairs = nodePairs.Count();
            /*var amountOfPairs = nodes.Where(sourceNode => sourceNode.spaceUsed > 0)
                                 .Join(nodes.Where(destinationNode => destinationNode.availSpace > ), sourceNode => sourceNode, destinationNode => destinationNode,
                                           (sourceNode, destinationNode) => new { sourceNode, destinationNode })
                                 .Where(nodesCrossJoined => nodesCrossJoined.sourceNode != nodesCrossJoined.destinationNode
                                        && nodesCrossJoined.sourceNode.spaceUsed >= nodesCrossJoined.destinationNode.availSpace).Count();*/
        }

        public void SetTargetData()
        {
            //find node with highest x value and lowest y
            Node targetNode = nodes.OrderByDescending(node => node.x).OrderBy(node => node.y).SingleOrDefault();
            targetNode.isTargetData = true;
        }
    }
}
