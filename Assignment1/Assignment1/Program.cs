#define DEBUGCOMMENTS // Use when wanting to print out comments to console for debugging

using System;
using System.Collections.Generic;
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
            // Retrieve the Environment.txt filepath thats passed in as a command line argument
            string path = args[0];

            // Create a new environment object which will store all environment data
            Environment environment = new Environment(path);

            Agent agent = new Agent(environment.AgentCoordinate, environment.GoalStates);

            switch(args[1])
            {
                case "BFS":
                    agent.BreadthFirstSearch();
                    break;
                case "DFS":

                    break;
                case "GBFS":

                    break;
                case "AS":

                    break;
                case "CUS1":

                    break;
                case "CUS2":

                    break;
            }
        }
    }
}