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
            //Environment environment = new Environment(path);
            Environment.CreateEnvironment(path);

            Agent agent = new Agent(Environment.AgentCoordinate, Environment.GoalStates);
            
            Environment.DrawSelf();
            
            LinkedList<State> resultPath = new LinkedList<State>();
            resultPath = agent.Solve(args[1]);

            if (resultPath != null)
            {
                PrintPath(resultPath);
            } else
            {
                Console.WriteLine("No solution found");
            }

        }

        static public void PrintPath(LinkedList<State> path)
        {
            foreach (State pathNode in path)
            {
                // Ignore parent node's direction
                if (pathNode.ParentState == null)
                    continue;
                Console.Write($"{pathNode.Direction}; ");
                //Console.WriteLine($"Move {pathNode.Direction} to {pathNode.Location.X}, {pathNode.Location.Y}; ");
            }

            Console.WriteLine("\n");
        }
    }
}