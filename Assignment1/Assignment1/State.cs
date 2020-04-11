using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /**
     * This class will be used to store all relevant information about the current 
     * state of the agent
     */
    class State
    {
        State _parentState; // Store the parent state
        Coordinate _location; // Store the location the agent is in in this state
        int _totalCost = 0; // Store the total number of nodes travelled to reach here. Initially 0 for root node

        public State ParentState { get => _parentState; set => _parentState = value; }
        public Coordinate Location { get => _location; set => _location = value; }
        public int TotalCost { get => _totalCost; set => _totalCost = value; }

        /// <summary>
        /// Constructor used for the initial state/root node
        /// </summary>
        /// <param name="initialLocation">Starting location of the agent</param>
        public State(Coordinate initialLocation)
        {
            _location = initialLocation;
        }

        /// <summary>
        /// Constructor used for all child nodes
        /// </summary>
        /// <param name="parent">The parent node</param>
        /// <param name="location">The location of the agent in this particular state</param>
        public State(State parent, Coordinate location)
        {
            _parentState = parent;
            _location = location;
            _totalCost = parent.TotalCost + 1; // Just add 1 to the parent's cost to get the current cost
        }


        // TODO: CHECK IF THERE'S A MORE ELEGANT WAY TO DO THE ISGOALSTATE() METHOD BELOW
        // ------------------------------------------------------------------------------

        /// <summary>
        /// Check if this state's location/coordinate matches any of the goal states, by iterating through
        /// every goal state in the given list
        /// </summary>
        /// <param name="goalStates">The list of states to check through</param>
        /// <returns></returns>
        public Boolean IsGoalState(List<State> goalStates)
        {
            foreach(State goalState in goalStates)
            {
                if (_location.Equals(goalState.Location)) { // If ths location matches the currently checked goal state's
                    return true;
                }
            }

            return false;
        }


    }
}
