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
        public Main Main = new Main();
        public Affair(Main m)
        {
            Main = m;
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
            userInfo.Urgency = "Urgency" + count;
            userInfo.Content = "Conent" + count;

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
            userInfo.Urgency = this.textBox4.Text;
            userInfo.Content = this.textBox5.Text;
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
            this.textBox4.Text = row.Cells[4].Value.ToString();
            this.textBox5.Text = row.Cells[5].Value.ToString();
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var s=this.DataGridView1.CurrentRow.Cells[1].Value.ToString();
            Pomodoro p = new Pomodoro(Main, s);
            Main.Hide();
            p.ShowDialog();
        }
    }
}
