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

            switch(args[1])
            {
                case "BFS":
                    LinkedList<State> resultPath = agent.BreadthFirstSearch();

                    if (resultPath != null)
                    {
                        PrintPath(resultPath);
                    }
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

        static public void PrintPath(LinkedList<State> path)
        {
            // Reverse the linkedlist states, since it is in reverse order
            LinkedList<State> newList = new LinkedList<State>();

            while (path.Count != 0)
            {
                // Reverse by Popping and pushing like how a stack works
                LinkedListNode<State> node = path.First;
                path.RemoveFirst();
                newList.AddFirst(node);
            }

            foreach (State pathNode in newList)
            {
                Console.Write($"[{pathNode.Location.X}, {pathNode.Location.Y}] ");
            }

            Console.WriteLine("\n");
        }
    }
}