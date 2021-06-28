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
    public partial class Schedule : UserControl
    {
        //public Schedule Schedule { get; set; }
        public Main Main = new Main();
        public Schedule(Main m)
        {
            Main = m;
            InitializeComponent();
        }

        private void UserControl5_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Pomodoro p = new Pomodoro(Main,"a");
            Main.Hide();
            p.ShowDialog();
        }
    }
}
