using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScheduleManagement.Entity;
using ScheduleManagement.Service;

namespace ScheduleManagement
{
    public partial class Affair : UserControl
    {
        public Affair()
        {
            InitializeComponent();
        }

        //数据库连接
        SQLiteConnection m_dbConnection;

        AffairService aff = new AffairService();
        private void UserControl2_Load(object sender, EventArgs e)
        {

        }

        //查询
        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = aff.GetAllList();

            this.DataGridView1.DataSource = ds.Tables[0];
        }
        //增
        int count = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            count++;
            Entity.Affair userInfo = new Entity.Affair();
            userInfo.Title  = "Title" + count;
            userInfo.Place = "Place" + count;
            userInfo.DateTime = DateTime.Now;
            userInfo.EndTime = DateTime.UtcNow;
            userInfo.Urgency = "Urgency" + count;
            userInfo.Content = "Conent" + count;
            userInfo.State = "未完成";
            userInfo.TimeInterval = 1;
            userInfo.Unit = "分";
            userInfo.RemindTimes = 1;



            aff.Add(userInfo);

            DataSet ds = aff.GetAllList();
            this.DataGridView1.DataSource = ds.Tables[0];
        }
        //改
        private void button3_Click(object sender, EventArgs e)
        {
            Entity.Affair userInfo = new Entity.Affair();
            userInfo.AffairId = int.Parse(this.label1.Text);
            userInfo.Title = this.textBox1.Text;
            userInfo.Place = this.textBox2.Text;
            userInfo.DateTime = DateTime.Parse(this.textBox3.Text);
            userInfo.EndTime = DateTime.Parse(this.textBox_EndTime.Text);
            userInfo.Urgency = this.textBox4.Text;
            userInfo.Content = this.textBox5.Text;
            userInfo.State = this.textBox_state.Text;
            userInfo.TimeInterval = Int32.Parse(this.textBox_TimeInterval.Text);
            userInfo.Unit = this.textBox_Unit.Text;
            userInfo.RemindTimes = Int32.Parse(this.textBox_RemindTimes.Text);
            aff.Update(userInfo);


            DataSet ds = aff.GetAllList();
            this.DataGridView1.DataSource = ds.Tables[0];
        }
        //删
        private void button4_Click(object sender, EventArgs e)
        {
            aff.Delete(int.Parse(this.label1.Text));

            
            DataSet ds = aff.GetAllList();
            this.DataGridView1.DataSource = ds.Tables[0];
        }

 /*       private void DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridViewRow row = this.DataGridView1.CurrentRow;
            this.label1.Text = row.Cells[0].Value.ToString();
            this.textBox1.Text = row.Cells[1].Value.ToString();
            this.textBox2.Text = row.Cells[2].Value.ToString();
            this.textBox3.Text = row.Cells[3].Value.ToString();
            this.textBox4.Text = row.Cells[4].Value.ToString();
            this.textBox5.Text = row.Cells[5].Value.ToString();

        }*/

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.DataGridView1.CurrentRow;
            this.label1.Text = row.Cells[0].Value.ToString();
            this.textBox1.Text = row.Cells[1].Value.ToString();
            this.textBox2.Text = row.Cells[2].Value.ToString();
            this.textBox3.Text = row.Cells[3].Value.ToString();
            this.textBox_EndTime.Text = row.Cells[4].Value.ToString();
            this.textBox4.Text = row.Cells[5].Value.ToString();
            this.textBox5.Text = row.Cells[6].Value.ToString();
            this.textBox_state.Text = row.Cells[7].Value.ToString();
            this.textBox_TimeInterval.Text = row.Cells[8].Value.ToString();
            this.textBox_Unit.Text = row.Cells[9].Value.ToString();
            this.textBox_RemindTimes.Text = row.Cells[10].Value.ToString();
        }
    }
}
