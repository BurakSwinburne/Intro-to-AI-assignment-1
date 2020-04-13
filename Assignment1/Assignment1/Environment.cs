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
    static class Environment
    {
        static int _columns, _rows; // Dimensions of environment
        static List<State> _goalStates = new List<State>(); // Store a list of of possible goal states
        static List<Coordinate> _walls = new List<Coordinate>(); // Store all the walls in the environment

        static Coordinate _agentCoordinate; // Agent's location in the environment
        static public Coordinate AgentCoordinate { get => _agentCoordinate; set => _agentCoordinate = value; }
        static public List<State> GoalStates { get => _goalStates; set => _goalStates = value; }



        /// <summary>
        /// Read the file containing environment details and create the environment
        /// </summary>
        /// <param name="path">The file path</param>
        public static void CreateEnvironment(string path)
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
             * coordinate objects. Then create goal state objects, which will use the coordinates
             * to determine if the agent has reached their goal
             */
            foreach (string position in goalPositions)
            {
                string[] xyPairValues = position.Split(',');
                int x = int.Parse(xyPairValues[0]);
                int y = int.Parse(xyPairValues[1]);

                Coordinate coordinate = new Coordinate(x, y);
                State goalState = new State(coordinate);
                _goalStates.Add(goalState);
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

                /**
                 * Note that when it comes to creating the walls, you need to subtract 1 from the width and height,
                 * otherwise they're always 1 height taller/1 width longer. This is just a quirk in the way the
                 * environment is created via the file
                 */
                int w = int.Parse(wallDimensions[2]) - 1;
                int h = int.Parse(wallDimensions[3]) - 1;

                Coordinate wall = new Coordinate(x, y, w, h);
                _walls.Add(wall);
            }
        }

        
        /// <summary>
        /// Check if the given location is valid by checking if it is not inside the bounds of a wall,
        /// or outside the boundaries of the environment
        /// </summary>
        /// <param name="location">The coordinate to check</param>
        /// <returns>Return true if it is a valid location</returns>
        public static Boolean IsValidLocation(Coordinate location)
        {
            // First check if outside the boundaries of the environment
            if (location.X < 0 || location.Y < 0 || location.X > _columns || location.Y > _rows)
            {
                return false;
            }
            
            // Iterate through every wall and check if the location falls inside the wall's bounds
            foreach(Coordinate wall in _walls)
            {
                int leftX = wall.X;
                int rightX = wall.X + wall.Width;
                int topY = wall.Y;
                int bottomY = wall.Y + wall.Height;

                if (location.X >= leftX
                    && location.X <= rightX
                    && location.Y >= topY
                    && location.Y <= bottomY)
                {
                    return false; // Coordinate is a wall
                }
            }

            return true;
        }

        /// <summary>
        /// DEBUGGING PURPOSES ONLY. Draw the environment in console
        /// </summary>
        public static void DrawSelf()
        {
            for(int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    Boolean isGoalTile = false;

                    foreach (State state in GoalStates)
                    {
                        if (state.Location.X == j && state.Location.Y == i)
                        {
                            isGoalTile = true;
                            break;
                        }
                    }

                    Boolean isWall = false;

                    foreach(Coordinate wall in _walls)
                    {
                        if (j >= wall.X && j <= (wall.X + wall.Width)
                            && i >= wall.Y && i <= (wall.Y + wall.Height))
                        {
                            isWall = true;
                            break;
                        }
                    }

                    
                    if (isGoalTile)
                    {
                        Console.Write("g "); // Goal
                    } else if (isWall)
                    {
                        Console.Write("w "); // Wall
                    }
                    else {
                        Console.Write("- "); // Empty space
                    }
                }

                Console.Write("\n");
            }
        }
    }
}
