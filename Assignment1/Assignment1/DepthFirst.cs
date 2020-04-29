using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class DepthFirst : SearchStrategy
    {


        public override LinkedList<State> Solve(Agent agent)
        {
            this.agent = agent;
            frontier.Push(agent.InitialState); // Add initial state to frontier

            while (!frontier.IsEmpty())
            {
                State currentState = frontier.Pop();
                agent.EnteredStates.AddFirst(currentState);

                Console.WriteLine($"{currentState.Location.X}, {currentState.Location.Y}");

                if (currentState.IsGoalState(agent.GoalStates))
                {
                    LinkedList<State> path = new LinkedList<State>();
                    return currentState.GetPath(path);
                }
                else
                {
                    List<State> childNodes;

                    childNodes = currentState.Explore();

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
                frontier.Push(state); // DFS uses stack operations
                return true;
            }
        }
    }
}
