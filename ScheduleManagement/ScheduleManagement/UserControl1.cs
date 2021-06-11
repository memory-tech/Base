using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScheduleManagement.Entity;
using ScheduleManagement.Service;

namespace ScheduleManagement
{
    public partial class UserControl1 : UserControl
    {
        public ScheduleEntity CurrentScheduleEntity { get; set; }
        public UserControl1()
        {
            InitializeComponent();
            //scheduleentity = ScheduleService.GetAllScheduleEntity();
            //this.scheduleservice = scheduleservice;

            //this.CurrentScheduleEntity = scheduleentity;
            //bdsScheduleEntity.DataSource = CurrentSchedule;
        }
        
        public UserControl1(ScheduleEntity scheduleentity) : this()
        {
            InitializeComponent();
            CurrentScheduleEntity = scheduleentity;
            //orderItemBindingSource.DataSource = CurrentOrder.Items;
            //orderBindingSource.DataSource = CurrentOrder;
            //CurrentOrder.Client = (Client)clientBindingSource.Current;

        }
        
        private void btnFinish_Click(object sender, EventArgs e)
        {
            
            CurrentScheduleEntity.ScheduleId = txt_id.Text;
            CurrentScheduleEntity.Title = txt_title.Text;
            CurrentScheduleEntity.Datetime = DateTime.Parse(txt_starttime.Text);  //DateTime.Parse("2021-01-01 12:00:00")
            CurrentScheduleEntity.Place = txt_place.Text;
            CurrentScheduleEntity.Category = cmbBox_category.SelectedItem.ToString();
            CurrentScheduleEntity.Content = txt_content.Text;
            
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}