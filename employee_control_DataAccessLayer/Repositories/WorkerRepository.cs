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

    public class WorkerRepository : IRepository<Worker>
    {
        DatabaseContext db;
        public WorkerRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public void Create(Worker item)
        {
            string comm = "INSERT INTO workers VALUES (" + "'" + item.worker_id + "','" + item.worker_name + "','" + item.worker_date + "','" +
                item.worker_phone + "','" + item.worker_position + "');";
            db.Create(comm);
        }

        public Worker Get(int id)
        {
            Worker result = new Worker();

            try
            {
                result.worker_id = id;
                //string comm = "SELECT worker_id FROM workers WHERE worker_id = " + id.ToString();
                //result.worker_id = Int32.Parse(db.Get(comm));
                string comm = "SELECT worker_name FROM workers WHERE worker_id =" + id.ToString();
                result.worker_name = db.Get(comm);
                comm = "SELECT worker_date FROM workers WHERE worker_id =" + id.ToString();
                result.worker_date = DateTime.Parse(db.Get(comm));
                comm = "SELECT worker_phone FROM workers WHERE worker_id =" + id.ToString();
                result.worker_phone = db.Get(comm);
                comm = "SELECT worker_position FROM workers WHERE worker_id =" + id.ToString();
                result.worker_position = db.Get(comm);

                return result;
            }
            catch
            {
                return null;
            }


        }

        public List<Worker> GetAll()
        {
            List<Worker> result = new List<Worker>();

            MySqlDataReader dr = db.GetAll();
            if (dr.HasRows)
            {
                int count = dr.FieldCount;

                while (dr.Read())
                {
                    for (var i = 4; i < count; i += 2)
                    {
                        Worker tmp = new Worker();
                        tmp.worker_id = Int32.Parse(dr.GetValue(i - 4).ToString());
                        tmp.worker_name = dr.GetValue(i - 3).ToString();
                        tmp.worker_date = DateTime.Parse(dr.GetValue(i - 2).ToString());
                        tmp.worker_phone = dr.GetValue(i - 1).ToString();
                        tmp.worker_position = dr.GetValue(i).ToString();

                        result.Add(tmp);
                    }

                }
            }
            dr.Close();
            return result;

        }
    }

}
