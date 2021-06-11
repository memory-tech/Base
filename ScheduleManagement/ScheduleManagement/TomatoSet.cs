using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScheduleManagement
{
    public partial class TomatoSet : Form
    {
        public Tomato Tomato { get; set; }
        public int Interval { get; set; }
        public int BreakInterval { get; set; }
        //
        public TomatoSet(Tomato Tomato, int Interval, int BreakInterval)
        {
            InitializeComponent();
            this.Tomato = Tomato;
            this.Interval = Interval;
            this.BreakInterval = BreakInterval;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("请选择一种番茄时长！");
                return;
            }
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("请设置休息间隔时长！");
                return;
            }
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Interval = 15; break;
                case 1:
                    Interval = 30; break;
                case 2:
                    Interval = 45; break;
                case 3:
                    Interval = 60; break;
            }
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    BreakInterval = 5; break;
                case 1:
                    BreakInterval = 10; break;
            }
            Tomato.Interval = Interval;
            Tomato.BreakInterval = BreakInterval;
            this.Close();
        }
    }
}
