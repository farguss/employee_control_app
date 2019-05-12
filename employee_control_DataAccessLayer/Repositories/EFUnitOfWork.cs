using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using employee_control_DataAccessLayer.Entities;
using employee_control_DataAccessLayer.MysqlDB;
using employee_control_DataAccessLayer.Interfaces;

namespace employee_control_DataAccessLayer.Repositories
{

    public class EFUnitOfWork : IUnitOfWork
    {
        private DatabaseContext db;
        private WorkerRepository workerRepository;
        private ScheduleRepository scheduleRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new DatabaseContext(connectionString);
        }

        public WorkerRepository Workers
        {
            get
            {
                if (workerRepository == null)
                    workerRepository = new WorkerRepository(db);
                return workerRepository;
            }
        }

        public ScheduleRepository Schedules
        {
            get
            {
                if (scheduleRepository == null)
                    scheduleRepository = new ScheduleRepository(db);
                return scheduleRepository;
            }
        }

        public void Dispose()
        {
            db.closeConnection();
        }
    }

}
