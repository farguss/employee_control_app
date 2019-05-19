using System;
using System.Collections.Generic;
using employee_control_BusinessLogicLayer.DTO;
using employee_control_BusinessLogicLayer.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace employee_UnitTestProject
{
    [TestClass]
    public class TestSheduleService
    {

        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=enterprise;";
        ScheduleService schedule_service = new ScheduleService(connectionString);

        [TestMethod]
        public void TestGetWorker()
        {
            //Arrange

            WorkerDTO new_worker = new WorkerDTO();

            //Act

            new_worker = schedule_service.GetWorker(100001);

            //Assert

            Assert.IsNotNull(new_worker);
        }

        [TestMethod]
        public void TestGetWorkers()
        {
            //Arrange

            List<WorkerDTO> list_of_workers = new List<WorkerDTO>();

            //Act

            list_of_workers = schedule_service.GetWorkers();

            //Assert

            Assert.IsNotNull(list_of_workers);
        }

        [TestMethod]
        public void TestAddShedule()
        {
            //Arrange
            ScheduleDTO new_schedule = new ScheduleDTO()
            {
                worker_id = 100001,

                Monday = "10:00-15:00",

                Tuesday = "10:00-18:00",

                Wednesday = "10:00-20:00",

                Thursday = "10:00-20:00",

                Friday = "12:00-16:00",

                Saturday = "holiday",

                Sunday = "holiday",

            };

            Exception exception = null;


            try
            {
                //Act
                schedule_service.AddSchedule(new_schedule);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            //Assert
            Assert.IsNull(exception);


        }

    }
}
