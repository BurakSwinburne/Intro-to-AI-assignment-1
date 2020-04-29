using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{

    class Frontier
    {
        LinkedList<State> _states = new LinkedList<State>();
        public LinkedList<State> States { get => _states; set => _states = value; }


        public int Size
        {
            get => _states.Count;
        }

        public Frontier()
        {
        }

        /*
         * Methods for using the frontier as a queue - used for breadth-first search
         *
         */
        
        
        // Add a state to the back of the queue
        public void Enqueue(State state)
        {
            _states.AddLast(state);
        }

        // Remove the first state in the queue
        public State Dequeue()
        {
            State stateAtFront = GetFront(); // First store the state at the front of the queue, to return later
            _states.RemoveFirst();
            return stateAtFront;
        }

        // Get the state at the front of the queue
        public State GetFront()
        {
            return _states.First();
        }


        /**
         * 
         * Methods for using the frontier as a stack - used for Depth-first search
         * 
         */
        
        /// <summary>
        /// Push a state to the top of the stack
        /// </summary>
        /// <param name="state">The state to add</param>
        public void Push(State state)
        {
            _states.AddLast(state);
        }
        
        /// <summary>
        /// Pop a state from the top of the stack
        /// </summary>
        /// <returns>The stack that was popped</returns>
        public State Pop()
        {
            State poppedState = GetTop();
            _states.RemoveLast();
            return poppedState;
        }


        // Get the state at the top of the stack
        public State GetTop()
        {
            return _states.Last();
        }


        public Boolean IsEmpty()
        {
            return Size == 0;
        }


        /// <summary>
        /// Check if the given state already exists as a stored state
        /// </summary>
        /// <param name="state">The state to check</param>
        /// <returns>True if it exists, otherwise false</returns>
        public Boolean Contains(State state)
        {
            foreach(State storedState in _states)
            {
                if (state.Equals(storedState))
                {
                    return true;
                }
            }
            
            return false;
        }

        /// <summary>
        /// Sort the states in the frontier by heuristic value
        /// </summary>
        public void Sort()
        {
            // Use a simple insertion sort to sort all the elements
            for (int i = 0; i < _states.Count - 1; i++)
            {
                int j = i + 1;

                while (j > 0)
                {
                    // The states with smallest heuristic values are placed at the front, since the 
                    // smaller the value, the closer to the goal state it is
                    if (_states.ElementAt(j - 1).HeuristicValue > _states.ElementAt(j).HeuristicValue)
                    {
                        // Ugly code below is due to the design of C#'s LinkedList class
                        State temp = States.ElementAt(j);
                        State temp2 = States.ElementAt(j - 1);
                        LinkedListNode<State> nodeToMoveRight = _states.Find(temp2);

                        _states.Remove(States.ElementAt(j));
                        _states.AddBefore(nodeToMoveRight, temp);
                    }
                    /**
                     * If both state's heuristic values are equal, it needs to be sorted by direction,
                     * going in order of: UP, LEFT, DOWN, RIGHT. Therefore, an UP action will be performed
                     * before trying to perform a LEFT action, etc.
                     */
                    else if (_states.ElementAt(j - 1).HeuristicValue == _states.ElementAt(j).HeuristicValue) 
                    {

                    }

                    j--;
                }
            }
        }
    }
}
