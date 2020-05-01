using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class AStar : SearchStrategy
    {
        public override LinkedList<State> Solve(Agent agent)
        {
            this.agent = agent;
            frontier.Push(agent.InitialState);

            /** 
             * As long as there are nodes in the frontier, continue. Note that, the node at the front
             * of the frontier is always the node with the lowest heuristic value
             */
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
                            State examinedNode = childNodes[i];

                            /**
                             * Initially assume there is only 1 goal state. If there are multiple goal states, this 
                             * will store the goal state that is closest/cheapest to reach according heuristic value
                             */
                            State closestGoalNode = agent.GoalStates[0]; 

                            // If there is more than 1 goal state, find the goal state that is cheapest to reach
                            if (agent.GoalStates.Count > 1)
                            {
                                // Find the cheapest to reach node by calculating the manhattan distance + total current cost
                                foreach (State currentGoalNode in agent.GoalStates)
                                {
                                    if (ManhattanDistance(examinedNode, currentGoalNode) + examinedNode.TotalCost 
                                        < ManhattanDistance(examinedNode, closestGoalNode) + examinedNode.TotalCost)
                                    {
                                        closestGoalNode = currentGoalNode;
                                    }
                                }
                            }
                            

                            /**
                             * Similar to greedy best first search, which calculates the heuristic value by
                             * using manhattan distance and the cost of moving a specific direction. 
                             * 
                             * However, this algorithm also takes into account the total cost required to reach
                             * the current node, by using the formula: 
                             * 
                             *      heuristic value = cost so far to reach current node + estimated cost to reach the closest goal node 
                             *
                             *
                             * The cost of moving a to specific direction is also added, to ensure that the agent tries to move Up,
                             * then Left, then Down, then Right. Do this by assigning the values 0.0, 0.1, 0.2, 0.3 to
                             * directions Up, Left, Down and Right respectively.
                             * 
                             * This means that in the case of the agent being able to move to multiple locations which 
                             * have the same manhattan distance, it will try move up, then left, then down, then right.
                             */

                            // How much it will cost to move to the next node, based on which direction it's moving
                            float moveCost = (float)examinedNode.Direction / 10;
                            
                            examinedNode.HeuristicValue = (examinedNode.TotalCost + (ManhattanDistance(examinedNode, closestGoalNode) + moveCost));
                        }
                    }
                }

                frontier.Sort(); // Sort the nodes according to their heuristic values
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
