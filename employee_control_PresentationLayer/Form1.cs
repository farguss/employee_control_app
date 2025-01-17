﻿using System;
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
using Ninject.Modules;

using employee_control_PresentationLayer.Facade;
using employee_control_PresentationLayer.Memento;

namespace employee_control_PresentationLayer
{
    public partial class Form1 : Form
    {


        private static Form1 instance;

        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=enterprise;";
        ScheduleService schedule_service = new ScheduleService(connectionString);
        List<WorkerDTO> list_of_workers = new List<WorkerDTO>();

        Originator origin = new Originator();
        Caretaker status = new Caretaker();

        public Form1()
        {

            InitializeComponent();

            list_of_workers = schedule_service.GetWorkers();

            foreach (var item in list_of_workers)
            {
                comboBoxWorkers.Items.Add(item.worker_name);
            }

            //
            listBox1.BeginUpdate();
            foreach (var item in list_of_workers)
            {
                listBox1.Items.Add(item.worker_name);
            }
            listBox1.EndUpdate();
            //

            //Получаем список всех schedules в БД
            origin.GetSchedulesList(schedule_service); 
            status.History.Push(origin.SaveState());
            //

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Получаем список всех schedules в БД
            origin.GetSchedulesList(schedule_service);
            status.History.Push(origin.SaveState());

            AddScheduleFacade new_facade = new AddScheduleFacade(comboBoxWorkers.SelectedItem.ToString(),
                checkBoxMonday.Checked, checkBoxTuesday.Checked, checkBoxWednesday.Checked, checkBoxThursday.Checked,
                checkBoxFriday.Checked, checkBoxSaturday.Checked, checkBoxSunday.Checked, 
                textBoxMondayFrom.Text, textBoxMondayTo.Text, textBoxTuesdayFrom.Text, textBoxTuesdayTo.Text, textBoxWednesdayFrom.Text,
                textBoxWednesdayTo.Text, textBoxThursdayFrom.Text, textBoxThursdayTo.Text, textBoxFridayFrom.Text, textBoxFridayTo.Text,
                textBoxSaturdayFrom.Text, textBoxSaturdayTo.Text, textBoxSundayFrom.Text, textBoxSundayTo.Text);

            AddService new_schedule_service = new AddService();
            new_schedule_service.AddNewSchedule(new_facade, list_of_workers, schedule_service, listBox1.SelectedItems, button2);

        }

        //
        public static Form1 getInstance()
        {
            if (instance == null)
                instance = new Form1();
            return instance;
        }
        //


        //Cancel Button
        private void button2_Click(object sender, EventArgs e)
        {
            //удаляем лишние записи
            origin.RestoreState(status.History.Pop(), schedule_service);

            //Получаем список всех schedule в БД
            origin.GetSchedulesList(schedule_service);
            status.History.Push(origin.SaveState());

            button2.Enabled = false;
        }
 

    }
}
