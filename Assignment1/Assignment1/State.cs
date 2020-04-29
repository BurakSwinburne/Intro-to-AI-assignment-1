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
        Direction _direction; // Store the direction taken to reach this state from the parent state

        public State ParentState { get => _parentState; set => _parentState = value; }
        public Coordinate Location { get => _location; set => _location = value; }
        public int TotalCost { get => _totalCost; set => _totalCost = value; }
        public Direction Direction { get => _direction; set => _direction = value; }

        public float HeuristicValue;

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
        /// <param name="direction">The direction taken from parent node to reach this node</param>
        public State(State parent, Coordinate location, Direction direction)
        {
            _parentState = parent;
            _location = location;
            _totalCost = parent.TotalCost + 1; // Just add 1 to the parent's cost to get the current cost
            _direction = direction;
        }


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

            if (AbleToMove(Direction.Up))
            {
                State newState = Move(Direction.Up);
                children.Add(newState);
            }

            if (AbleToMove(Direction.Left))
            {
                State newState = Move(Direction.Left);
                children.Add(newState);
            }

            if (AbleToMove(Direction.Down)) {
                State newState = Move(Direction.Down);
                children.Add(newState);
            }

            if (AbleToMove(Direction.Right))
            {
                State newState = Move(Direction.Right);
                children.Add(newState);
            }

            return children;
        }


        /// <summary>
        /// Check if the coordinate to the given direction of the agent is not a wall or out of bounds
        /// </summary>
        /// <param name="direction">Direction to check</param>
        /// <returns>True if agent can move there, otherwise false</returns>
        public Boolean AbleToMove(Direction direction)
        {
            Coordinate coordinateToCheck = new Coordinate(_location.X, _location.Y);

            switch (direction)
            {
                case Direction.Left:
                    coordinateToCheck.X--; // Move 1 left
                    return (Environment.IsValidLocation(coordinateToCheck));

                case Direction.Up:
                    coordinateToCheck.Y--; // Move 1 up
                    return (Environment.IsValidLocation(coordinateToCheck));

                case Direction.Right:
                    coordinateToCheck.X++; // Move 1 right
                    return (Environment.IsValidLocation(coordinateToCheck));

                case Direction.Down:
                    coordinateToCheck.Y++; // Move 1 down
                    return (Environment.IsValidLocation(coordinateToCheck));
            }

            return false;
        }

        /// <summary>
        /// Create a new state rrepresenting the location the agent is moving to
        /// </summary>
        /// <param name="direction">Which direction to move</param>
        /// <returns>The new state</returns>
        public State Move(Direction direction)
        {
            Coordinate newLoc = new Coordinate(_location.X, _location.Y);

            switch (direction)
            {
                case Direction.Up:
                    newLoc.Y = newLoc.Y - 1;
                    break;
                case Direction.Right:
                    newLoc.X = newLoc.X + 1;
                    break;
                case Direction.Down:
                    newLoc.Y = newLoc.Y + 1;
                    break;
                case Direction.Left:
                    newLoc.X = newLoc.X - 1;
                    break;
            }

            State newState = new State(this, newLoc, direction);
            return newState;
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


        /// <summary>
        /// Travel recursively through all the nodes in the path, then store each node into the list
        /// </summary>
        /// <param name="path">The current path. Initially empty.</param>
        /// <returns>A linkedlist of states the agent has entered to reach the goal state</returns>
        public LinkedList<State> GetPath(LinkedList<State> path)
        {
            // If this is the root node
            if (_parentState == null)
            {
                path.AddLast(this); // Add this node to the path
                return path;
            } else
            {
                if (path.Count == 0) // The root node hasn't been reached yet
                {
                    path = _parentState.GetPath(path); // Call parent node before attaching self to the path
                }

                path.AddLast(this); // Add self
                return path;
            }
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
