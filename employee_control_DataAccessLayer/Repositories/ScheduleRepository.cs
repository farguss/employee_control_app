using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using employee_control_DataAccessLayer.Entities;
using employee_control_DataAccessLayer.MysqlDB;
using employee_control_DataAccessLayer.Interfaces;
using MySql.Data.MySqlClient;

namespace employee_control_DataAccessLayer.Repositories
{

    public class ScheduleRepository : IRepository<Schedule>
    {
        DatabaseContext db;
        public ScheduleRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public void Create(Schedule item)
        {
            string comm = "INSERT INTO work_schedule (`worker_id`, `Monday`, `Tuesday`, `Wednesday`, `Thursday`, `Friday`, `Saturday`, `Sunday`)" +
                "VALUES (" + "'" + item.worker_id + "','" + item.Monday + "','" + item.Tuesday + "','" +
                item.Wednesday + "','" + item.Thursday + "','" + item.Friday + "','" + item.Saturday + "','" + item.Sunday + "');";
            db.Create(comm);
        }

        public Schedule Get(int id)
        {
            Schedule result = new Schedule();

            try
            {
                result.worker_id = id;
                string comm = "SELECT Monday FROM work_schedule WHERE worker_id =" + id.ToString();
                result.Monday = db.Get(comm);
                comm = "SELECT Tuesday FROM work_schedule WHERE worker_id =" + id.ToString();
                result.Tuesday = db.Get(comm);
                comm = "SELECT Wednesday FROM work_schedule WHERE worker_id =" + id.ToString();
                result.Wednesday = db.Get(comm);
                comm = "SELECT Thursday FROM work_schedule WHERE worker_id =" + id.ToString();
                result.Thursday = db.Get(comm);
                comm = "SELECT Friday FROM work_schedule WHERE worker_id =" + id.ToString();
                result.Friday = db.Get(comm);
                comm = "SELECT Saturday FROM work_schedule WHERE worker_id =" + id.ToString();
                result.Saturday = db.Get(comm);
                comm = "SELECT Sunday FROM work_schedule WHERE worker_id =" + id.ToString();
                result.Sunday = db.Get(comm);

                return result;
            }
            catch
            {
                return null;
            }


        }

        public List<Schedule> GetAll()
        {
            List<Schedule> result = new List<Schedule>();

            MySqlDataReader dr = db.GetAll();
            if (dr.HasRows)
            {
                int count = dr.FieldCount;

                while (dr.Read())
                {
                    for (var i = 7; i < count; i += 2)
                    {
                        Schedule tmp = new Schedule();
                        tmp.worker_id = Int32.Parse(dr.GetValue(i - 7).ToString());
                        tmp.Monday = dr.GetValue(i - 6).ToString();
                        tmp.Tuesday = dr.GetValue(i - 5).ToString();
                        tmp.Wednesday = dr.GetValue(i - 4).ToString();
                        tmp.Thursday = dr.GetValue(i - 3).ToString();
                        tmp.Friday = dr.GetValue(i - 2).ToString();
                        tmp.Saturday = dr.GetValue(i - 1).ToString();
                        tmp.Sunday = dr.GetValue(i).ToString();

                        result.Add(tmp);
                    }

                }
            }
            dr.Close();
            return result;

        }
    }

}
