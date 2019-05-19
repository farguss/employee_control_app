using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee_control_BusinessLogicLayer.DTO
{

    public class ScheduleDTO
    {
        public int worker_id { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }

        /*public ScheduleDTO() { }

        public ScheduleDTO(int new_id, string new_monday, string new_tuesday, string new_wednesday, string new_thursday, 
            string new_friday, string new_saturday, string new_sunday)
        {

            worker_id = new_id;
            Monday = new_monday;
            Tuesday = new_tuesday;
            Wednesday = new_wednesday;
            Thursday = new_thursday;
            Friday = new_friday;
            Saturday = new_saturday;
            Sunday = new_sunday;

        }*/

        public ScheduleDTO Clone()
        {
            //return new ScheduleDTO(this.worker_id, this.Monday, this.Tuesday, this.Wednesday, this.Thursday, 
            //this.Friday, this.Saturday, this.Sunday);
            return (ScheduleDTO)this.MemberwiseClone();
        }

    }

}
