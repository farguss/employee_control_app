using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using employee_control_BusinessLogicLayer.DTO;
using employee_control_BusinessLogicLayer.Infrastructure;
using employee_control_BusinessLogicLayer.Services;

namespace employee_control_PresentationLayer.Facade
{
    class AddService
    {
        public void AddNewSchedule(AddScheduleFacade facade, List<WorkerDTO> list_of_workers,
            ScheduleService schedule_service, ListBox.SelectedObjectCollection first_listbox)
        {
            facade.Start(list_of_workers, schedule_service, first_listbox);
            facade.Stop();
        }
    }
}
