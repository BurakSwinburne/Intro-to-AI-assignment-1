
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Agent
    {
        State _initialState;
        List<State> _goalStates;
        LinkedList<State> _enteredStates = new LinkedList<State>(); // Save entered states to ensure they're not repeated

        public LinkedList<State> EnteredStates { get => _enteredStates; set => _enteredStates = value; }
        public List<State> GoalStates { get => _goalStates; set => _goalStates = value; }
        public State InitialState { get => _initialState; set => _initialState = value; }


        /// <summary>
        /// Initialise agent and pass through it's starting location
        /// </summary>
        /// <param name="coordinate">The location the agent will start at</param>
        /// <param name="goalStates">List of coordinates that the agent needs to reach to achieve it's goal</param>
        public Agent(Coordinate coordinate, List<State> goalStates)
        {
            _initialState = new State(coordinate);
            _goalStates = goalStates;
        }


        /// <summary>
        /// Search for the path to a goal state using a given method
        /// </summary>
        /// <param name="strategy">The strategy to use (i.e: DFS, BFS, GBFS, AS, CUS1, CUS2)</param>
        /// <returns>The path if found. Otherwise null</returns>
        public LinkedList<State> Solve(String strategy)
        {
            switch (strategy)
            {
                case "BFS":
                    return new BreadthFirst().Solve(this);

                case "DFS":
                    return new DepthFirst().Solve(this);

                case "GBFS":
                    return new GreedyBestFirst().Solve(this);

                case "AS":
                    return new AStar().Solve(this);
                case "CUS1":
                    break;

                case "CUS2":
                    break;
            }

            return null;
        }
    }
}
