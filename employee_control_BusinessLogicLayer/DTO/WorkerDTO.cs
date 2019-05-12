using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee_control_BusinessLogicLayer.DTO
{

    public class WorkerDTO
    {
        public int worker_id { get; set; }
        public string worker_name { get; set; }
        public DateTime worker_date { get; set; }
        public string worker_phone { get; set; }
        public string worker_position { get; set; }

    }

}
