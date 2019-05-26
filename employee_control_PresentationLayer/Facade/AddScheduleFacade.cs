using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using employee_control_BusinessLogicLayer.DTO;
using employee_control_BusinessLogicLayer.Infrastructure;
using employee_control_BusinessLogicLayer.Services;

namespace employee_control_PresentationLayer.Facade
{
    class AddScheduleFacade
    {
        string selected_worker;
        bool monday_check;
        bool tuesday_check;
        bool wednesday_check;
        bool thursday_check;
        bool friday_check;
        bool saturday_check;
        bool sunday_check;
        string[] days_array = new string[14];


        public AddScheduleFacade(string selected_worker, bool monday_check, bool tuesday_check,
            bool wednesday_check, bool thursday_check, bool friday_check, bool saturday_check, bool sunday_check, string MondayFrom,
            string MondayTo, string TuesdayFrom, string TuesdayTo, string WednesdayFrom, string WednesdayTo, string ThursdayFrom,
            string ThursdayTo, string FridayFrom, string FridayTo, string SaturdayFrom, string SaturdayTo, string SundayFrom,
            string SundayTo)
        {
            this.selected_worker = selected_worker;
            this.monday_check = monday_check;
            this.tuesday_check = tuesday_check;
            this.wednesday_check = wednesday_check;
            this.thursday_check = thursday_check;
            this.friday_check = friday_check;
            this.saturday_check = saturday_check;
            this.sunday_check = sunday_check;

            days_array[0] = MondayFrom;
            days_array[1] = MondayTo;
            days_array[2] = TuesdayFrom;
            days_array[3] = TuesdayTo;
            days_array[4] = WednesdayFrom;
            days_array[5] = WednesdayTo;
            days_array[6] = ThursdayFrom;
            days_array[7] = ThursdayTo;
            days_array[8] = FridayFrom;
            days_array[9] = FridayTo;
            days_array[10] = SaturdayFrom;
            days_array[11] = SaturdayTo;
            days_array[12] = SundayFrom;
            days_array[13] = SundayTo;

        }

        public void Start(List<WorkerDTO> list_of_workers,
            ScheduleService schedule_service, ListBox.SelectedObjectCollection first_listbox, Button cancel_butt)
        {

            ScheduleDTO new_schedule = new ScheduleDTO();
            try
            {
                int get_id = list_of_workers.Find(x => x.worker_name == selected_worker).worker_id;
                new_schedule.worker_id = get_id;
                if (monday_check == true) new_schedule.Monday = "holiday";
                else new_schedule.Monday = days_array[0] + "-" + days_array[1];

                if (thursday_check == true) new_schedule.Tuesday = "holiday";
                else new_schedule.Tuesday = days_array[2] + "-" + days_array[3];

                if (wednesday_check == true) new_schedule.Wednesday = "holiday";
                else new_schedule.Wednesday = days_array[4] + "-" + days_array[5];

                if (thursday_check == true) new_schedule.Thursday = "holiday";
                else new_schedule.Thursday = days_array[6] + "-" + days_array[7];

                if (friday_check== true) new_schedule.Friday = "holiday";
                else new_schedule.Friday = days_array[8] + "-" + days_array[9];

                if (saturday_check == true) new_schedule.Saturday = "holiday";
                else new_schedule.Saturday = days_array[10] + "-" + days_array[11];

                if (sunday_check == true) new_schedule.Sunday = "holiday";
                else new_schedule.Sunday = days_array[12] + "-" + days_array[13];


            }
            catch { }

            try
            {
                schedule_service.AddSchedule(new_schedule);

                //
                if (first_listbox.Count > 0)
                {
                    ScheduleDTO cloned = new_schedule.Clone();

                    for (int i = 0; i < first_listbox.Count; i++)
                    {
                        cloned.worker_id = list_of_workers.Find(x => x.worker_name == first_listbox[i].ToString()).worker_id;
                        schedule_service.AddSchedule(cloned);
                   
                    }

                }
                //

                string message = "Schedule was added successfully!";
                string caption = "Adding";
                MessageBox.Show(message, caption);

                cancel_butt.Enabled = true;

            }
            catch (ValidationException ex)
            {
                string message = ex.Message;
                string caption = "Adding";
                MessageBox.Show(message, caption);
                return;
            }

        }
        public void Stop()
        {
            
        }

    }

}

