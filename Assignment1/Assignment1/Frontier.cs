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
        private void Enqueue(State state)
        {
            _states.AddLast(state);
        }

        // Remove the first state in the queue
        private void Dequeue()
        {
            if (_states.Count != 0)
            {
                _states.RemoveFirst();
            }
        }

        // Get the state at the top of the queue
        public State GetTop()
        {
            return _states.First();
        }

        // Get the state at the top of the queye
        public State Pop()
        {
            State poppedState = GetTop();
            
            Dequeue();

            return poppedState;
        }

        public void Push(State state)
        {
            Enqueue(state);
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



        /**
         * 
         * Methods for using frontier as a stack. Used for depth-first search.
         * 
         */

    }
}
