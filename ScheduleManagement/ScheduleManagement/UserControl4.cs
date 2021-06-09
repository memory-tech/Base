﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ScheduleManagement.clawer;

namespace ScheduleManagement
{
    public partial class UserControl4 : UserControl
    {
        BindingSource resultBindingSource = new BindingSource();
        clawerbasketball claw = new clawerbasketball();
        public UserControl4()
        {
            InitializeComponent();
            Result.DataSource = resultBindingSource;
            claw.NewsDownloaded += Clawer_NewsDownloaded;
            
        }
        private Graphics graphics;


        private void Clawer_NewsDownloaded(clawerbasketball crawler, string day, string time ,string player1,string player2,string turn,string link)
        {
            var newpage = new { Index = resultBindingSource.Count + 1, Day = day, Time = time,P1 = player1,P2=player2,T=turn,detail = link };
            Action action = () => { resultBindingSource.Add(newpage); };
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            resultBindingSource.Clear();
            claw.Excute();
           // Task task = Task.Run(() => claw.Excute());
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
