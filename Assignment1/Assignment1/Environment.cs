#define DEBUGCOMMENTS

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// A class that stores information about the agent's environment
    /// </summary>
    class Environment
    {
        int _columns, _rows; // Dimensions of environment
        List<Coordinate> _goalStates = new List<Coordinate>(); // Store a list of of possible goal states
        List<Coordinate> _walls = new List<Coordinate>(); // Store all the walls in the environment

        Coordinate _agentCoordinate; // Agent's location in the environment
        public Coordinate AgentCoordinate { get => _agentCoordinate; set => _agentCoordinate = value; }
        public List<Coordinate> GoalStates { get => _goalStates; set => _goalStates = value; }



        /// <summary>
        /// Read the file containing environment details and create the environment
        /// </summary>
        /// <param name="path">The file path</param>
        public Environment(string path)
        {
            /**
             * Read the file. The method returns an array of strings, so convert
             * the array to a list just to make it easier to read the file
             */
            string[] fileContent = System.IO.File.ReadAllLines(path);
            List<string> fileLines = fileContent.ToList();

            /*
             * Read each line and remove from list until it reaches the part where there are 
             * dimensions for walls
             */
            string dimensions = fileLines[0]; // Get environment dimensions [x, y]
            fileLines.RemoveAt(0);

            string agentStartingPos = fileLines[0]; // Agent's initial position. Assume it is valid
            fileLines.RemoveAt(0);

            string agentGoalPos = fileLines[0]; // Get the agent's goal states
            fileLines.RemoveAt(0);

            List<string> walls = new List<string>(); // Used to store all the walls from the file
            // Read all the walls
            foreach (string line in fileLines)
            {
                walls.Add(line);
            }

#if (DEBUGCOMMENTS)
            Console.WriteLine("DIMENSIONS: " + dimensions);
            Console.WriteLine("STARTING POSITION: " + agentStartingPos);
            Console.WriteLine("GOAL STATES: " + agentGoalPos + "\n\n\n");

            foreach (string line in fileLines)
            {
                Console.WriteLine(line);
            }
#endif

            /**
             * Convert all those string values into appropriate data types
             */

            // Map dimensions in file is formatted as: [x,y]
            dimensions = Regex.Replace(dimensions, @"\[|\]", ""); // Remove square brackets
            string[] dimensionsSplit = dimensions.Split(',');
            _columns = int.Parse(dimensionsSplit[0]);
            _rows = int.Parse(dimensionsSplit[1]);

            // Agent starting position is formatted as: (x,y)
            agentStartingPos = Regex.Replace(agentStartingPos, @"\(|\)", ""); // Remove parantheses
            string[] agentStartingPosSplit = agentStartingPos.Split(',');
            int _agentStartingX = int.Parse(agentStartingPosSplit[0]);
            int _agentStartingY = int.Parse(agentStartingPosSplit[1]);

            _agentCoordinate = new Coordinate(_agentStartingX, _agentStartingY);

            // Goal states in file are formatted as: (7,0)|(10,3)|(6,1)...
            agentGoalPos = Regex.Replace(agentGoalPos, @"\(|\)", ""); // Remove parantheses
            string[] goalPositions = agentGoalPos.Split('|'); // Seperate each goal

            /**
             * Now iterate through every goal coordinate, and convert the strings into
             * coordinate objects, which will be stored into the list of goal coordinates
             */
            foreach (string position in goalPositions)
            {
                string[] xyPairValues = position.Split(',');
                int x = int.Parse(xyPairValues[0]);
                int y = int.Parse(xyPairValues[1]);

                Coordinate coordinate = new Coordinate(x, y);
                _goalStates.Add(coordinate);
            }

            /**
             * Now convert the list of walls, stored as strings, into coordinate objects
             */
            foreach (string wallString in walls)
            {
                // Walls in the file are formatted as: (x,y,w,h)
                string temp = Regex.Replace(wallString, @"\(|\)", ""); // Remove parantheses
                string[] wallDimensions = temp.Split(',');
                int x = int.Parse(wallDimensions[0]);
                int y = int.Parse(wallDimensions[1]);
                int w = int.Parse(wallDimensions[2]);
                int h = int.Parse(wallDimensions[3]);

                Coordinate wall = new Coordinate(x, y, w, h);
                _walls.Add(wall);

#if (DEBUGCOMMENTS)
                Console.WriteLine($"Wall x = {wall.X}, y = {wall.Y}, width = {wall.Width}, height = {wall.Height}");
#endif
            }
        }
    }
}
