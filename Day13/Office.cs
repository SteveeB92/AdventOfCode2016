using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13
{

    class Office
    {

        bool[,] officeGrid;
        int puzzleInput;
        List<Location> locationsVisited;

        public Office(int width, int height, int puzzleInput)
        {
            officeGrid = new bool[width, height];
            this.puzzleInput = puzzleInput;
            locationsVisited = new List<Location>();
            FillOfficeGrid();
        }

        public void FillOfficeGrid()
        {
            for (int x = 0; x < officeGrid.GetLength(0); x++)
            {
                for (int y = 0; y < officeGrid.GetLength(1); y++)
                {
                    int sum = ((x * x) + (3 * x) + (2 * x * y) + y + (y * y)) + puzzleInput;
                    string binaryRep = Convert.ToString(sum, 2);
                    officeGrid[x, y] = binaryRep.Replace("0", string.Empty).Length % 2 == 0;
                }
            }
        }

        public int FindShortestPathToLocation(int x, int y)
        {
            //Dictionary that holds all current locations and how many steps it takes to reach that location
            List<Location> currentLocations = new List<Location>();
            Location startingLocation = new Location(1,1, 0);
            currentLocations.Add(startingLocation);
            return VisitAdjacentLocations(x, y, currentLocations);
        }

        /// <summary>
        /// Looks at the adjacent locations to the locations currently stored.
        /// If any of these locations are the target then return the number assocaited with it
        /// </summary>
        /// <param name="x">X Location to reach</param>
        /// <param name="y">Y Location to reach</param>
        /// <param name="currentLocations">List of locations that we are currently visiting</param>
        /// <returns></returns>
        public int VisitAdjacentLocations(int x, int y, List<Location> currentLocations)
        {
            if (currentLocations.Count == 0)
                throw new Exception("Unable to move...");

            List<Location> newLocations = new List<Location>();
            foreach (Location location in currentLocations)
            {
                //Move in 4 directions... Up, Down, Left and Right
                if (location.x + 1 < officeGrid.GetLength(0) && officeGrid[location.x + 1, location.y])
                {
                    //Have we reached the target destination?
                    if (location.x + 1 == x && location.y == y)
                        return location.movesTakenToReach + 1;
                    AddCurrentLocationIfNotAlreadyVisited(location.x + 1, location.y, location.movesTakenToReach + 1, newLocations);
                }
                if (location.x > 0 && officeGrid[location.x - 1, location.y])
                {
                    if (location.x -1 == x && location.y == y)
                        return location.movesTakenToReach + 1;
                    AddCurrentLocationIfNotAlreadyVisited(location.x - 1, location.y, location.movesTakenToReach + 1, newLocations);
                }
                if (location.y + 1 < officeGrid.GetLength(1) && officeGrid[location.x, location.y + 1])
                {
                    if (location.x == x && location.y == y + 1)
                        return location.movesTakenToReach + 1;
                    AddCurrentLocationIfNotAlreadyVisited(location.x, location.y + 1, location.movesTakenToReach + 1, newLocations);
                }
                if (location.y > 0 && officeGrid[location.x, location.y - 1])
                {
                    if (location.x == x && location.y - 1 == y)
                        return location.movesTakenToReach + 1;
                    AddCurrentLocationIfNotAlreadyVisited(location.x, location.y - 1, location.movesTakenToReach + 1, newLocations);
                }
            }
            return VisitAdjacentLocations(x, y, newLocations);
        }

        public void AddCurrentLocationIfNotAlreadyVisited(int x, int y, int movesTakenToReach, List<Location> currentLocations)
        {
            Location newLocation = new Location(x, y, movesTakenToReach);
            //Ensure we have not already visited this location
            if (locationsVisited.Where(location => location.x == x && location.y == y).ToList().Count == 0)
            {
                currentLocations.Add(newLocation);
                locationsVisited.Add(newLocation);
            }
        }
    }

}
