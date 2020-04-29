using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    abstract class SearchStrategy
    {
        protected Agent agent;
        protected Frontier frontier = new Frontier();


        /// <summary>
        /// Use a search strategy to solve the current pathfinding problem
        /// </summary>
        /// <param name="agent">The agent</param>
        /// <returns>The resulting path, if found. Otherwise null</returns>
        public abstract LinkedList<State> Solve(Agent agent);


        /// <summary>
        /// Add a node to the frontier, if it hasn't already been visited before. Each strategy will
        /// have their own way of implementing this
        /// </summary>
        /// <param name="state">The state/node to add to the frontier</param>
        /// <returns>True if node was able to be added</returns>
        public abstract Boolean AddNodeToFrontier(State state);


        /// <summary>
        /// Check if an agent has already visited a state by comparing their location values
        /// </summary>
        /// <param name="otherState">The state that the agent will check has been visited already</param>
        /// <returns>True if state visited, otherwise false</returns>
        public virtual Boolean StateAlreadyVisited(State otherState)
        {
            foreach (State state in agent.EnteredStates)
            {
                if (state.Location.X == otherState.Location.X
                    && state.Location.Y == otherState.Location.Y)
                {
                    return true;
                }
            }

            return false;
        }


        /// <summary>
        /// Get the manhattan distance between the current state/location and given goal state
        /// </summary>
        /// <param name="state">The current state being examined</param>
        /// <param name="goalState">The goal state</param>
        /// <returns>The Manhattan distance</returns>
        public virtual int ManhattanDistance(State state, State goalState)
        {
            return Math.Abs(state.Location.X - goalState.Location.X) + Math.Abs(state.Location.Y - goalState.Location.Y);
        }
    }
}
