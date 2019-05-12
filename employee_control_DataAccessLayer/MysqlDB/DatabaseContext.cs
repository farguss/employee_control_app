using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace employee_control_DataAccessLayer.MysqlDB
{
    public class DatabaseContext
    {

        private MySqlConnection conn;

        public DatabaseContext(string connectionString)
        {
            try
            {
                this.conn = new MySqlConnection(connectionString);
                this.conn.Open();
            }
            catch
            {

            }
        }

        public void closeConnection()
        {
            this.conn.Close();
        }

        public void Create(string comm)
        {
            MySqlCommand cmd = new MySqlCommand(comm, conn);
            cmd.ExecuteScalar();
        }

        public string Get(string comm)
        {
            MySqlCommand cmd = new MySqlCommand(comm, conn);
            string res = cmd.ExecuteScalar().ToString();
            return res;
        }

        public MySqlDataReader GetAll()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * from workers", conn);
            MySqlDataReader res = cmd.ExecuteReader();
            return res;
        }

    }
}
