using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using employee_control_DataAccessLayer.Entities;
using employee_control_DataAccessLayer.Repositories;

namespace employee_control_DataAccessLayer.Interfaces
{

    public interface IUnitOfWork : IDisposable
    {
        WorkerRepository Workers { get; }
        ScheduleRepository Schedules { get; }
    }

}
