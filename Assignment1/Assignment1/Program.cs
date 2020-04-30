using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        /**
         * args[0] The filepath
         * args[1] The search method to use (BFS, DFS, GBFS, AS, CUS1, CUS2)
         */
        static void Main(string[] args)
        {
            // Coudldn't implement Custom algorithms
            // string[] allowableMethodInputs = { "BFS", "DFS", "GBFS", "AS", "CUS1", "CUS2" };
            string[] allowableMethodInputs = { "BFS", "DFS", "GBFS", "AS" };
            string method = args[1].ToUpper();

            if (!allowableMethodInputs.Contains(method)) {
                Console.WriteLine("Please enter one of the following valid methods: BFS, DFS, GBFS, AS");
                return;
            }

            // Retrieve the Environment.txt filepath thats passed in as a command line argument
            string filepath = args[0];
            
            // Create a new environment object which will store all environment data
            Environment.CreateEnvironment(filepath);

            Agent agent = new Agent(Environment.AgentCoordinate, Environment.GoalStates);
            
            // Environment.DrawSelf(); // Debugging purposes only 
            
            LinkedList<State> resultPath = new LinkedList<State>();

            resultPath = agent.Solve(method);

            if (resultPath != null)
            {
                PrintOutput(agent.EnteredStates, resultPath, filepath, args[1]);
            } else
            {
                Console.WriteLine("No solution found");
            }

        }


        /// <summary>
        /// Print the solution to console, in the format requested
        /// </summary>
        /// <param name="nodes">All the states the agent has entered</param>
        /// <param name="path">The path to the solution</param>
        /// <param name="filepath">The filepath</param>
        /// <param name="strategy">Search method used</param>
        static public void PrintOutput(LinkedList<State> nodes, LinkedList<State> path, string filepath, string strategy)
        {
            // Get the file name by splitting the filepath string using the char '\' and getting the last element, which
            // is the file name
            string filename = filepath.Split('\\')[filepath.Split('\\').Length - 1];

            Console.WriteLine($"{filename} {strategy} {nodes.Count}");

            foreach (State pathNode in path)
            {
                // Ignore parent node's direction
                if (pathNode.ParentState == null)
                    continue;
                Console.Write($"{pathNode.Direction}; ");
            }

            Console.WriteLine("\n");
        }
    }
}