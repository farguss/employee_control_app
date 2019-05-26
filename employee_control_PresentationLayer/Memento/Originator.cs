using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using employee_control_BusinessLogicLayer.DTO;
using employee_control_BusinessLogicLayer.Infrastructure;
using employee_control_BusinessLogicLayer.Services;

namespace employee_control_PresentationLayer.Memento
{
    class Originator
    {

        private int last_of_schedules { get; set; }

        public void GetSchedulesList(ScheduleService schedule_service)
        {
            List<ScheduleDTO> new_list_of_schedules = new List<ScheduleDTO>();

            new_list_of_schedules = schedule_service.GetSchedules();

            if (new_list_of_schedules.Count == 0) last_of_schedules = 0;
            else
            {
                foreach (var item in new_list_of_schedules)
                {
                    last_of_schedules = item.schedule_id;
                }
            }

        }
        // сохранение состояния
        public Memento SaveState()
        {
            return new Memento(last_of_schedules);
        }

        // восстановление состояния
        public void RestoreState(Memento memento, ScheduleService schedule_service)
        {
            last_of_schedules = memento.last_of_schedules;

            schedule_service.DeleteSchedules(last_of_schedules);

            string message = "Last action was canceled!";
            string caption = "Cancel";
            MessageBox.Show(message, caption);

        }

    }
}
