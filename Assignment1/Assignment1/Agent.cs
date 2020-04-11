using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Agent
    {
        State _currentState;
        List<State> _goalStates;
        LinkedList<State> _enteredStates; // Save entered states to ensure they're not repeated


        /// <summary>
        /// Initialise agent and pass through it's starting location
        /// </summary>
        /// <param name="coordinate">The location the agent will start at</param>
        /// <param name="goalStates">List of coordinates that the agent needs to reach to achieve it's goal</param>
        public Agent(Coordinate coordinate, List<State> goalStates)
        {
            _currentState = new State(coordinate);
            _goalStates = goalStates;
        }


        // TODO: FIGURE OUT THE RETURN TYPE FROM ASSIGNMENT DOCUMENT
        // ---------------------------------------------------------
        /// <summary>
        /// Do a breadth-first search to create a path to any of the goal states
        /// </summary>
        public void BreadthFirstSearch()
        {
            Console.WriteLine("Doing breadth-first search");

            // Create the frontier and add current state as the initial state/node of the queue
            Frontier frontier = new Frontier();

            frontier.Push(_currentState); // Push the initial state. This will be the root node of the tree
            
            while (!frontier.IsEmpty()) // As long as there are nodes to traverse
            {
                State currentState = frontier.Pop();

                _enteredStates.AddFirst(currentState);

                if (currentState.IsGoalState(_goalStates))
                {
                    // TODO: RETURN THE STATE AND THE PATH IT TOOK TO REACH THIS STATE
                } else
                {
                    // TODO: ITERATE THROUGH THE OTHER NODES
                }
            }
        }
    }
}
