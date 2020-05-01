using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class GreedyBestFirst : SearchStrategy
    {
        /// <summary>
        /// Use Greedy Best First search to find the path from agent's initial position
        /// to the goal state
        /// </summary>
        /// <param name="agent"></param>
        /// <returns>The path if it exists. Otherwise return false</returns>
        public override LinkedList<State> Solve(Agent agent)
        {
            this.agent = agent;
            frontier.Push(agent.InitialState);

            // As long as there are nodes in the frontier, continue
            while (!frontier.IsEmpty())
            {
                State currentState = frontier.Dequeue(); // Get the node currently at the front of the queue
                agent.EnteredStates.AddFirst(currentState);

                if (currentState.IsGoalState(agent.GoalStates))
                {
                    LinkedList<State> path = new LinkedList<State>();
                    return currentState.GetPath(path);
                }
                else
                {
                    List<State> childNodes = currentState.Explore();

                    for (int i = 0; i < childNodes.Count; i++)
                    {
                        // If node is able to be added to the frontier, calculate its heuristic value
                        if (AddNodeToFrontier(childNodes[i]))
                        {
                            /**
                             * If there is more than 1 goal state, compare manhattan distances between the current state 
                             * and various goal states, to see which is the closest (ignoring walls)
                             */
                            State examinedNode = childNodes[i];
                            State closestGoalNode = agent.GoalStates[0]; // Initially assume only 1 goal state

                            if (agent.GoalStates.Count > 0)
                            {
                                // Find the closest goal node by comparing their manhattan distance values
                                foreach (State currentGoalNode in agent.GoalStates)
                                {
                                    if (ManhattanDistance(examinedNode, currentGoalNode) < ManhattanDistance(examinedNode, closestGoalNode))
                                    {
                                        closestGoalNode = currentGoalNode;
                                    }
                                }
                            }

                            /**
                             * Calculate heuristic value by using manhattan distance AND cost of moving
                             * a specific direction. Do this by assigning the values 0.0, 0.1, 0.2, 0.3 to
                             * directions UP, LEFT, DOWN and RIGHT respectively.
                             * 
                             * This means that in the case of the agent being able to move to multiple locations
                             * which have the same manhattan values, it will try to move Up, then Left, then
                             * Down, then Right.
                             */
                            float moveCost = (float)examinedNode.Direction / 10; // UP = 0.0, LEFT = 0.1, DOWN = 0.2, RIGHT = 0.3
                            examinedNode.HeuristicValue = (ManhattanDistance(examinedNode, closestGoalNode) + moveCost);
                        }
                    }
                }

                frontier.Sort();
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
                frontier.Enqueue(state);
                return true;
            }
        }
    }
}
