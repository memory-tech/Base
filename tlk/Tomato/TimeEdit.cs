using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tomato
{
    public partial class TimeEdit : Form
    {
        public Tomato Tomato { get; set; }
        public int Interval { get; set; }
        public int TotalTime { get; set; }
        public int BreakInterval { get; set; }
        public TimeEdit(Tomato Tomato,int TotalTime, int Interval, int BreakInterval)
        {
            InitializeComponent();
            this.Tomato = Tomato;
            this.TotalTime = TotalTime;
            this.Interval = Interval;
            this.BreakInterval = BreakInterval;
        }
        //设置番茄时长
        private void btnOk_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("请设置任务总时长！");
                return;
            }
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
            switch (comboBox1.SelectedIndex) {
                case 0:
                    Interval = 15; break;
                case 1:
                    Interval = 30; break;
                case 2:
                    Interval = 45; break;
                case 3:
                    Interval = 60; break;
            }
            switch (comboBox2.SelectedIndex) {
                case 0:
                    BreakInterval = 5;break;
                case 1:
                    BreakInterval = 10;break;
            }
            Tomato.TotalTime = Convert.ToInt32(textBox1.Text);
            Tomato.Interval = Interval;
            Tomato.BreakInterval = BreakInterval;
            this.Close();
        }
    }
}
