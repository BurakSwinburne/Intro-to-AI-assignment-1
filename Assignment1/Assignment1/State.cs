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
                // If this location matches the currently checked goal state's location
                if (_location.Equals(goalState.Location)) { 
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Explore the current state by looking at all the possible actions the agent can take, 
        /// represented as child nodes
        /// </summary>
        /// <returns>A list of child nodes</returns>
        public List<State> Explore()
        {
            List<State> children = new List<State>();
            
            // Get possible actions (i.e ensure that there is no wall in the possible direction it can move)
            // TODO: DO HERE


            // TODO: CHANGE THE 4 VALUE TO THE NUMBER OF POSSIBLE NUMBER OF ACTIONS
            // MAYBE DON'T USE FOR LOOPS FOR THIS PART
            for (int i = 0; i < 4; i++)
            {
                // NOTE: USING RANDOM TEMPORARILY TO TEST OTHER PARTS OF THE ALGORITHM
                // TODO: FIX HERE ONCE ALGORITHM IS WORKING
                
                Random rng = new Random();
                int val = rng.Next(10, 12);
                int valtwo = rng.Next(10, 10);

                Coordinate newLocTest = new Coordinate(val, valtwo);
                State childNodeTest = new State(this, newLocTest);

                //Coordinate newLocTest = new Coordinate(_location.X + 1, _location.Y + 1);
                //State childNodeTest = new State(this, newLocTest);

                children.Add(childNodeTest);
                
            }

            return children;
        }


        /// <summary>
        /// Create a new state rrepresenting the location the agent is moving to
        /// </summary>
        /// <param name="direction">Which direction to move</param>
        /// <returns>The new state</returns>
        public State Move(Direction direction)
        {
            State newLocation = new State(this, Location);

            switch(direction)
            {
                case Direction.Up:
                    newLocation.Location.Y = newLocation.Location.Y - 1;
                    break;
                case Direction.Left:
                    newLocation.Location.X = newLocation.Location.X - 1;
                    break;
                case Direction.Down:
                    newLocation.Location.Y = newLocation.Location.Y + 1;
                    break;
                case Direction.Right:
                    newLocation.Location.X = newLocation.Location.X + 1;
                    break;
            }
            return newLocation;
        }


        /// <summary>
        /// Compare if given state is identical to this one, by comparing locations
        /// </summary>
        /// <param name="otherState">The other state to compare against</param>
        /// <returns>True if both are equale, otherwise false</returns>
        public Boolean Equals(State otherState)
        {
            return (_location.X == otherState._location.X)
                && (_location.Y == otherState.Location.Y);
        }
    }

    public enum Direction
    {
        Up,
        Left,
        Down,
        Right
    }
}
