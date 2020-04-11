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
        State _parentState;
        int _costFromParent; // Store the total number of nodes travelled to reach here

        public int CostFromParent { get => _costFromParent; set => _costFromParent = value; }
        public State ParentState { get => _parentState; set => _parentState = value; }


        public State(State parent, int totalCost)
        {
            _parentState = parent;
            _costFromParent = totalCost;
        }
    }
}
