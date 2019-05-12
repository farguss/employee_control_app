using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using employee_control_BusinessLogicLayer.DTO;

namespace employee_control_BusinessLogicLayer.Interfaces
{

    public interface IScheduleService
    {
        void AddSchedule(ScheduleDTO scheduleDto);
        WorkerDTO GetWorker(int id);
        List<WorkerDTO> GetWorkers();
    }

}
