using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee_control_PresentationLayer.Memento
{
    class Memento
    {

        public int last_of_schedules { get; private set; }
        public Memento(int last_of_schedule)
        {
            last_of_schedules = last_of_schedule;
        }

    }
}
