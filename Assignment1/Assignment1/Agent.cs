using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Agent
    {
        Coordinate _currentState;
        List<Coordinate> _goalStates;
        LinkedList<Coordinate> _enteredStates; // Save entered states to ensure they're not repeated


        /// <summary>
        /// Initialise agent and pass through it's starting location
        /// </summary>
        /// <param name="coordinate">The location the agent will start at</param>
        /// <param name="goalStates">List of coordinates that the agent needs to reach to achieve it's goal</param>
        public Agent(Coordinate coordinate, List<Coordinate> goalStates)
        {
            _currentState = coordinate;
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

            Frontier frontier = new Frontier();
        }
    }
}
