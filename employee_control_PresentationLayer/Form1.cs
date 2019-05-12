using System;
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
using Ninject.Modules;

namespace employee_control_PresentationLayer
{
    public partial class Form1 : Form
    {
        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=enterprise;";
        ScheduleService schedule_service = new ScheduleService(connectionString);
        List<WorkerDTO> list_of_workers = new List<WorkerDTO>();

        public Form1()
        {

            InitializeComponent();

            list_of_workers = schedule_service.GetWorkers();

            foreach (var item in list_of_workers)
            {
                comboBoxWorkers.Items.Add(item.worker_name);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            ScheduleDTO new_schedule = new ScheduleDTO();
            try
            {
                int get_id = list_of_workers.Find(x => x.worker_name == comboBoxWorkers.SelectedItem.ToString()).worker_id;
                new_schedule.worker_id = get_id;
                if (checkBoxMonday.Checked == true) new_schedule.Monday = "holiday";
                else new_schedule.Monday = textBoxMondayFrom.Text + "-" + textBoxMondayTo.Text;

                if (checkBoxTuesday.Checked == true) new_schedule.Tuesday = "holiday";
                else new_schedule.Tuesday = textBoxTuesdayFrom.Text + "-" + textBoxTuesdayTo.Text;

                if (checkBoxWednesday.Checked == true) new_schedule.Wednesday = "holiday";
                else new_schedule.Wednesday = textBoxWednesdayFrom.Text + "-" + textBoxWednesdayTo.Text;

                if (checkBoxThursday.Checked == true) new_schedule.Thursday = "holiday";
                else new_schedule.Thursday = textBoxThursdayFrom.Text + "-" + textBoxThursdayTo.Text;

                if (checkBoxFriday.Checked == true) new_schedule.Friday = "holiday";
                else new_schedule.Friday = textBoxFridayFrom.Text + "-" + textBoxFridayTo.Text;

                if (checkBoxSaturday.Checked == true) new_schedule.Saturday = "holiday";
                else new_schedule.Saturday = textBoxSaturdayFrom.Text + "-" + textBoxSaturdayTo.Text;

                if (checkBoxSunday.Checked == true) new_schedule.Sunday = "holiday";
                else new_schedule.Sunday = textBoxSundayFrom.Text + "-" + textBoxSundayTo.Text;
                

            }
            catch { }

            try
            {
                schedule_service.AddSchedule(new_schedule);

                string message = "Schedule was added successfully!";
                string caption = "Adding";
                MessageBox.Show(message, caption);

            }
            catch (ValidationException ex)
            {
                string message = ex.Message;
                string caption = "Adding";
                MessageBox.Show(message, caption);
                return;
            }

        }
    }
}
