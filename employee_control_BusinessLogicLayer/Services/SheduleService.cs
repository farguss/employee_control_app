using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using employee_control_DataAccessLayer.Entities;
using employee_control_DataAccessLayer.Interfaces;
using employee_control_DataAccessLayer.Repositories;
using employee_control_BusinessLogicLayer.DTO;
using employee_control_BusinessLogicLayer.Infrastructure;
using employee_control_BusinessLogicLayer.Interfaces;
using AutoMapper;

namespace employee_control_BusinessLogicLayer.Services
{

    public class ScheduleService : IScheduleService
    {
        IUnitOfWork DataBase { get; set; }

        public ScheduleService(string connectionStr)
        {
            DataBase = new EFUnitOfWork(connectionStr);
        }

        public WorkerDTO GetWorker(int id)
        {

            WorkerDTO tmp = new WorkerDTO();
          
            tmp.worker_id = DataBase.Workers.Get(id).worker_id;
            tmp.worker_name = DataBase.Workers.Get(id).worker_name;
            tmp.worker_date = DataBase.Workers.Get(id).worker_date;
            tmp.worker_phone = DataBase.Workers.Get(id).worker_phone;
            tmp.worker_position = DataBase.Workers.Get(id).worker_position;

            return tmp;
        }

        public List<WorkerDTO> GetWorkers()
        {

            List<WorkerDTO> all_workers_result = new List<WorkerDTO>();

            for (var i = 0; i < DataBase.Workers.GetAll().Count; i++)
            {

                WorkerDTO tmp = new WorkerDTO();

                tmp.worker_id = DataBase.Workers.GetAll()[i].worker_id;
                tmp.worker_name = DataBase.Workers.GetAll()[i].worker_name;
                tmp.worker_date = DataBase.Workers.GetAll()[i].worker_date;
                tmp.worker_phone = DataBase.Workers.GetAll()[i].worker_phone;
                tmp.worker_position = DataBase.Workers.GetAll()[i].worker_position;

                all_workers_result.Add(tmp);
            }

            return all_workers_result;



        }

        public void AddSchedule(ScheduleDTO scheduleDto)
        {


            if (DataBase.Workers.Get(scheduleDto.worker_id) == null)
            {
                throw new ValidationException("Error worker_id!", "");
            }

            Schedule new_schedule = new Schedule();

            new_schedule.schedule_id = 0;

            new_schedule.worker_id = scheduleDto.worker_id;

            if (scheduleDto.Monday == "-")
            {
                throw new ValidationException("Error schedule on Monday!", "");
            }
            if (scheduleDto.Tuesday == "-")
            {
                throw new ValidationException("Error schedule on Tuesday!", "");
            }
            if (scheduleDto.Wednesday == "-")
            {
                throw new ValidationException("Error schedule on Wednesday!", "");
            }
            if (scheduleDto.Thursday == "-")
            {
                throw new ValidationException("Error schedule on Thursday!", "");
            }
            if (scheduleDto.Friday == "-")
            {
                throw new ValidationException("Error schedule on Friday!", "");
            }
            if (scheduleDto.Saturday == "-")
            {
                throw new ValidationException("Error schedule on Saturday!", "");
            }
            if (scheduleDto.Sunday == "-")
            {
                throw new ValidationException("Error schedule on Sunday!", "");
            }

            new_schedule.Monday = scheduleDto.Monday;
            new_schedule.Tuesday = scheduleDto.Tuesday;
            new_schedule.Wednesday = scheduleDto.Wednesday;
            new_schedule.Thursday = scheduleDto.Thursday;
            new_schedule.Friday = scheduleDto.Friday;
            new_schedule.Saturday = scheduleDto.Saturday;
            new_schedule.Sunday = scheduleDto.Sunday;

            DataBase.Schedules.Create(new_schedule);

        }

        //
        public void DeleteSchedules(int schedule_id)
        {

            DataBase.Schedules.DeleteAllAfter(schedule_id);
            

        }

        public List<ScheduleDTO> GetSchedules()
        {

            List<ScheduleDTO> all_schedules_result = new List<ScheduleDTO>();

            for (var i = 0; i < DataBase.Schedules.GetAll().Count; i++)
            {

                ScheduleDTO tmp = new ScheduleDTO();

                tmp.schedule_id = DataBase.Schedules.GetAll()[i].schedule_id;
                tmp.worker_id = DataBase.Schedules.GetAll()[i].worker_id;
                tmp.Monday = DataBase.Schedules.GetAll()[i].Monday;
                tmp.Tuesday = DataBase.Schedules.GetAll()[i].Tuesday;
                tmp.Wednesday = DataBase.Schedules.GetAll()[i].Wednesday;
                tmp.Thursday = DataBase.Schedules.GetAll()[i].Thursday;
                tmp.Friday = DataBase.Schedules.GetAll()[i].Friday;
                tmp.Saturday = DataBase.Schedules.GetAll()[i].Saturday;
                tmp.Sunday = DataBase.Schedules.GetAll()[i].Sunday;

                all_schedules_result.Add(tmp);
            }

            return all_schedules_result;

        }
        //

    }

}
