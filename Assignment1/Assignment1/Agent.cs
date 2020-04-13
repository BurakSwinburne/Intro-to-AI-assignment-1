 #define DEBUGCOMMENTS

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
        LinkedList<State> _enteredStates = new LinkedList<State>(); // Save entered states to ensure they're not repeated
        Frontier frontier;

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
        /// Do a breadth-first search to create a path to any of the goal states. If a goal state
        /// is reached, return it
        /// </summary>
        /// <returns>List of nodes/states it took to reach the goal state</returns>
        public LinkedList<State> BreadthFirstSearch()
        {
            Console.WriteLine("Doing breadth-first search");

            // Create the frontier and add current state as the initial state/node of the queue
            frontier = new Frontier();
            frontier.Push(_currentState); // Push the initial state. This will be the root node of the tree
            
            while (!frontier.IsEmpty()) // As long as there are nodes to traverse
            {
                State currentState = frontier.Pop(); // Return the popped state/node
                _enteredStates.AddFirst(currentState); // Store it in memory as part of the path traversed

                /**
                 * If the current node is one of the goal states, then return this node and the path
                 * taken to reach here
                 */
                if (currentState.IsGoalState(_goalStates))
                {
                    // Call the node to retrieve it's path, which will call the recursive GetPath method 
                    // until it reaches the root node
                    LinkedList<State> path = new LinkedList<State>();

                    return currentState.GetPath(path);

                    //return _enteredStates; // TODO: DEBUG AND CHECK IF THIS IS CORRECT
                } 
                /**
                 * Explore all the child nodes and add them to the queue
                 */
                else
                {
                    // This will store all the child nodes of the node that is being explored
                    List<State> childNodes;

                    childNodes = currentState.Explore();


                    // NOTE: TRY MOVE UP, THEN LEFT, THEN DOWN, THEN RIGHT. 0 IN THIS CASE REPRESENTS UP
                    // Expand the current node by exploring all possible child nodes/states
                    for (int i = 0; i < childNodes.Count; i++)
                    {
                        if (AttachChildNode(childNodes[i])) {
#if (DEBUGCOMMENTS)
                            Console.WriteLine($"Successfully attached node at position { childNodes[i].Location.X }, { childNodes[i].Location.Y }");
                        }
#endif

                    }
                    
                }
            }

            return null;
        }


        /// <summary>
        /// Attach the child node to the parent
        /// </summary>
        /// <param name="state">The parent state/node</param>
        /// <returns>True if child node was able to be attached. Otherwise false</returns>
        public Boolean AttachChildNode(State state)
        {
            // NOTE: THIS IS NOT CORRECTLY IDENTIFYING ENTERED STATES - MUST FIX OR ELSE THE SEARCH DOESN'T STOP
            // First check if the state has been entered before
            //if (_enteredStates.Contains(state) || frontier.Contains(state))
            if (StateAlreadyVisited(state) || frontier.Contains(state))
            {
                Console.WriteLine("DOES CONTAIN THE STATE: " + state.Location.X + " " + state.Location.Y);
                return false;
            } else
            {
                Console.WriteLine("DOESNT CONTAIN: " + state.Location.X + " " + state.Location.Y);
                frontier.Push(state);
                return true;
            }
        }


        /// <summary>
        /// Check if an agent has already visited a state by comparing their location values
        /// </summary>
        /// <param name="otherState">The state that the agent will check has been visited already</param>
        /// <returns>True if state visited, otherwise false</returns>
        public Boolean StateAlreadyVisited(State otherState)
        {
            foreach(State state in _enteredStates)
            {
                if (state.Location.X == otherState.Location.X
                    && state.Location.Y == otherState.Location.Y)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
