﻿using System;
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
                // NOTE: THE REMOVEFIRST METHOD DOES NOT RETURN THE NODE ITSELF. KEEP THAT IN MIND --------
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

        /**
         * 
         * Methods for using frontier as a stack. Used for depth-first search.
         * 
         */

    }
}
