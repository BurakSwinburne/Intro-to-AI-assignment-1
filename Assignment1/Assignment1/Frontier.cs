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
        
        public void Enqueue()
        {

        }

        public void Dequeue()
        {

        }

        public void GetTop()
        {

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
