using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee_control_PresentationLayer.Memento
{
    class Caretaker
    {

        public Stack<Memento> History { get; private set; }
        public Caretaker()
        {
            History = new Stack<Memento>();
        }

    }
}
