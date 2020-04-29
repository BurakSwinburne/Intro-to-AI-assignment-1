using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class BreadthFirst : SearchStrategy
    {

        /// <summary>
        /// Do a breadth-first search to create a path from the agent's initial position to 
        /// any of the goal states. If a goal state is reached, return it.
        /// </summary>
        /// <returns>List of nodes/states it took to reach the goal state</returns>
        public override LinkedList<State> Solve(Agent agent)
        {
            this.agent = agent;
            frontier.Push(agent.InitialState);

            Console.WriteLine("Doing breadth-first search");

            while (!frontier.IsEmpty()) // As long as there are nodes to traverse
            {
                State currentState = frontier.Dequeue(); // Return the dequeued state/node
                agent.EnteredStates.AddFirst(currentState); // Store it in memory as part of the path traversed

                Console.WriteLine($"{currentState.Location.X}, {currentState.Location.Y}");

                /**
                 * If the current node is one of the goal states, then return this node and the path
                 * taken to reach here
                 */
                if (currentState.IsGoalState(agent.GoalStates))
                {
                    // Call the node to retrieve it's path, which will call the recursive GetPath method 
                    // until it reaches the root node
                    LinkedList<State> path = new LinkedList<State>();
                    return currentState.GetPath(path);
                }
                /**
                 * Explore all the child nodes and add them to the queue
                 */
                else
                {
                    // This will store all the child nodes of the node that is being explored
                    List<State> childNodes;

                    childNodes = currentState.Explore();

                    // Expand the current node by exploring all possible child nodes/states
                    for (int i = 0; i < childNodes.Count; i++)
                    {
                        AddNodeToFrontier(childNodes[i]);
                    }

                }
            }

            return null;
        }


        /// <summary>
        /// Add a node to the frontier, if it hasn't already been visited before
        /// </summary>
        /// <param name="state">The state/node to add to the frontier</param>
        /// <returns>True if node was able to be added</returns>
        public override Boolean AddNodeToFrontier(State state)
        {
            // First check if the state has been entered before
            if (StateAlreadyVisited(state) || frontier.Contains(state))
            {
                return false;
            }
            else
            {
                frontier.Enqueue(state); // Queue operations are used for BFS
                return true;
            }
        }
    }
}
