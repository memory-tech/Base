﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ScheduleManagement.Service;

namespace ScheduleManagement
{
    public partial class Main : Form
    {
        public UserControl1 f1; //创建用户控件一变量
        public UserControl2 f2; //创建用户控件二变量
        public UserControl3 f3; //创建用户控件三变量
        public UserControl4 f4; //创建用户控件四变量
        public UserControl5 f5; //创建用户控件五变量


        ScheduleService scheduleservice;
        public String Keyword1 { get; set; }

        To_Do_AffairsService to_do_affairservice;
        public String Keyword2 { get; set; }
        public Main()
        { 
        InitializeComponent();
        scheduleservice = new ScheduleService();
        bdsScheduleEntity.DataSource = scheduleservice.Schedules;
        //cbxCategory.SelectedIndex = 0;
        //txtKeyword1.DataBindings.Add("Text", this, "Keyword1");
        to_do_affairservice = new To_Do_AffairsService();
        bdsTo_Do_AffairEntity.DataSource = to_do_affairservice.To_Do_Affairs;
        //cbxUrgency.SelectedIndex = 0;
        //txtKeyword2.DataBindings.Add("Text", this, "Keyword2");
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            f1 = new UserControl1();    //实例化f1
            f2 = new UserControl2();    //实例化f2
            f3 = new UserControl3();    //实例化f3
            f4 = new UserControl4();    //实例化f4
            f5 = new UserControl5();    //实例化f5

        }
        string strConn = @"server=WIN-6V09QAL2MOV;database=dbsytx;integrated security=true";
        private void timer1_Tick(object sender, EventArgs e)
        {
             try
            {
                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from dbsytx";
                SqlDataReader dr = cmd.ExecuteReader();
              
                if (dr.Read())
                    {
                        if (dr["时间"].ToString() == System.DateTime.Now.ToString("yyyy/MM/dd hh:mm"))
                        {
                            
                          

                        }
                    }
             }
             catch (SqlException ee)
             {
                 MessageBox.Show(ee.Message);
             }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            f1.Show();   //将窗体一进行显示
            panel1.Controls.Clear();    //清空原容器上的控件
            panel1.Controls.Add(f1);    //将窗体一加入容器panel1
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f2.Show();   //将窗体二进行显示
            panel1.Controls.Clear();    //清空原容器上的控件
            panel1.Controls.Add(f2);    //将窗体二加入容器panel1
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("欢迎使用个性化日程管理系统");
        }

       

       

        private void button3_Click(object sender, EventArgs e)
        {
            f3.Show();   //将窗体三进行显示
            panel1.Controls.Clear();    //清空原容器上的控件
            panel1.Controls.Add(f3);    //将窗体三加入容器panel1
        }

        
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label2.Text = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 关于ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("欢迎使用个性化日程管理系统");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            f4.Show();   //将窗体四进行显示
            panel1.Controls.Clear();    //清空原容器上的控件
            panel1.Controls.Add(f4);    //将窗体四加入容器panel1
        }

        private void button5_Click(object sender, EventArgs e)
        {
            f5.Show();   //将窗体五进行显示
            panel1.Controls.Clear();    //清空原容器上的控件
            panel1.Controls.Add(f5);    //将窗体五加入容器panel1
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Show();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}