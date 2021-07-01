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
            
            AffairService aff = new AffairService();
            DataSet ds = aff.GetAllList();
            this.DataGridView1.DataSource = ds.Tables[0];

            //-------------------------
            ReminderService rs = new ReminderService();
            DataSet ds2 = rs.GetOrderedList("State1 like '未完成' ");
            this.textBox_test.Text = ds2.Tables[0].Rows[0]["ClockTime1"].ToString();

            //-------------------------

            //列的宽度自适应

            //隐藏列
            DataGridView1.Columns[0].Visible = false;     //affairid
            DataGridView1.Columns[2].Visible = false;     //place
            DataGridView1.Columns[3].Visible = false;     //datetime
            DataGridView1.Columns[4].Visible = false;     //endtime
            DataGridView1.Columns[5].Visible = false;     //urgency
            DataGridView1.Columns[6].Visible = false;     //content
            DataGridView1.Columns[7].Visible = false;     //state
            DataGridView1.Columns[8].Visible = false;     //timeinterval
            DataGridView1.Columns[9].Visible = false;     //unit
            DataGridView1.Columns[10].Visible = false;    //remindtimes
            DataGridView1.Columns[11].Visible = false;    //stander
            
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            
        }

        AffairService aff = new AffairService();
        ReminderService rs = new ReminderService();
        ClockTimeCalculation ctc = new ClockTimeCalculation();
        

/*        //查询--可删除
        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = aff.GetAllList();
            this.DataGridView1.DataSource = ds.Tables[0];
        }*/

        //增
        int count = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            count++;
            Entity.Affair affair = new Entity.Affair();
            affair.Title  = "Title" + count;
            affair.Place = "Place" + count;
            affair.DateTime = DateTime.Now;
            //affair.EndTime = ;
            affair.Urgency = "Urgency" + count;
            affair.Content = "Conent" + count;
            affair.State = "未完成";
            affair.TimeInterval = 1;
            affair.Unit = "分";
            affair.RemindTimes = 1;
            affair.Stander = aff.GetStander(affair.DateTime);
            aff.Add(affair);
            DataSet ds = aff.GetAllList();
            this.DataGridView1.DataSource = ds.Tables[0];
            
            //自动添加到ReminderTime表
            Entity.ReminderTime rt = new Entity.ReminderTime();
            rt.Title1 = affair.Title;
            rt.DateTime1 = affair.DateTime;
            rt.EndTime1 = affair.EndTime;
            rt.State1 = affair.State;
            rt.TimeInterval1 = affair.RemindTimes;
            rt.Unit1 = affair.Unit;
            rt.RemindTimes1 = affair.RemindTimes;
            //DateTime Time = (affair.DateTime == null) ? affair.EndTime : affair.DateTime;
            DateTime Time = affair.DateTime;
            ctc.GetClockTime1to3(affair, rt, Time);
            rs.Add(rt);
            DataSet ds1 = rs.GetList("");
            this.label_test_AffId.Text = ds1.Tables[0].Rows[rs.GetRecordCount("") - 1]["AffId"].ToString();

            //点击添加事件后,右侧自动显示该事件默认属性值
            DataGridViewRow row = this.DataGridView1.Rows[aff.GetRecordCount("")-1];
            this.label1.Text = row.Cells[0].Value.ToString();
            this.textBox_Title.Text = row.Cells[1].Value.ToString();
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

        //改
        private void button3_Click(object sender, EventArgs e)
        {
            Entity.Affair affair = new Entity.Affair();
            affair.AffairId = Int32.Parse(this.label1.Text);
            affair.Title = this.textBox_Title.Text;
            affair.Place = this.textBox2.Text;
            affair.DateTime = DateTime.Parse(this.textBox3.Text);
            affair.EndTime = DateTime.Parse(this.textBox_EndTime.Text);
            affair.Urgency = this.textBox4.Text;
            affair.Content = this.textBox5.Text;
            affair.State = this.textBox_state.Text;
            affair.TimeInterval = Int32.Parse(this.textBox_TimeInterval.Text);
            affair.Unit = this.textBox_Unit.Text;
            affair.RemindTimes = Int32.Parse(this.textBox_RemindTimes.Text);
            affair.Stander = aff.GetStander(affair.DateTime);
            aff.Update(affair);
            DataSet ds = aff.GetAllList();
            this.DataGridView1.DataSource = ds.Tables[0];


            //自动更新ReminderTime表
            Entity.ReminderTime rt = new Entity.ReminderTime();
            rt.AffId = Int32.Parse(this.label_test_AffId.Text);
            rt.Title1 = affair.Title;
            rt.DateTime1 = affair.DateTime;
            rt.EndTime1 = affair.EndTime;
            rt.State1 = affair.State;
            rt.TimeInterval1 = affair.RemindTimes;
            rt.Unit1 = affair.Unit;
            rt.RemindTimes1 = affair.RemindTimes;
            //DateTime Time =  (affair.DateTime == null) ? affair.EndTime: affair.DateTime; 
            DateTime Time = affair.DateTime;
            ctc.GetClockTime1to3(affair, rt,Time);
            rs.Update(rt);
        }

        //删
        private void button4_Click(object sender, EventArgs e)
        {
            aff.Delete(int.Parse(this.label1.Text));
            DataSet ds = aff.GetAllList();
            this.DataGridView1.DataSource = ds.Tables[0];
            
            //自动删除ReminderTime 表中相应的数据
            rs.Delete(int.Parse(this.label_test_AffId.Text));
            //this.label_test_AffId.Text = "";
            
            //事件删除后，右侧详情栏清空
            this.label1.Text = "";
            this.textBox_Title.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox_EndTime.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox_state.Text = "";
            this.textBox_TimeInterval.Text = "";
            this.textBox_Unit.Text = "";
            this.textBox_RemindTimes.Text = "";
        }

        //鼠标单击主题在右侧显示详细信息
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.DataGridView1.CurrentRow;
            this.label1.Text = row.Cells[0].Value.ToString();
            this.textBox_Title.Text = row.Cells[1].Value.ToString();
            this.textBox2.Text = row.Cells[2].Value.ToString();
            this.textBox3.Text = row.Cells[3].Value.ToString();
            this.textBox_EndTime.Text = row.Cells[4].Value.ToString();
            this.textBox4.Text = row.Cells[5].Value.ToString();
            this.textBox5.Text = row.Cells[6].Value.ToString();
            this.textBox_state.Text = row.Cells[7].Value.ToString();
            this.textBox_TimeInterval.Text = row.Cells[8].Value.ToString();
            this.textBox_Unit.Text = row.Cells[9].Value.ToString();
            this.textBox_RemindTimes.Text = row.Cells[10].Value.ToString();

            //需添加由label1查询到label_test_AffId的过程；
            DataSet ds1 = rs.GetList("");
            this.label_test_AffId.Text = row.Cells[0].Value.ToString();
            //this.label_test_AffId.Text = ds1.Tables[0].Rows[rs.GetRecordCount("") - 1]["AffId"].ToString();
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Entity.Affair affair = new Entity.Affair();
            affair.AffairId = Int32.Parse(DataGridView1.CurrentRow.Cells[0].Value.ToString());
            affair.Title = DataGridView1.CurrentRow.Cells[1].Value.ToString();
            affair.Place = DataGridView1.CurrentRow.Cells[2].Value.ToString();
            affair.DateTime = DateTime.Parse(DataGridView1.CurrentRow.Cells[3].Value.ToString());
            affair.EndTime = DateTime.Parse(DataGridView1.CurrentRow.Cells[4].Value.ToString());
            affair.Urgency = DataGridView1.CurrentRow.Cells[5].Value.ToString();
            affair.Content = DataGridView1.CurrentRow.Cells[6].Value.ToString();
            affair.State = DataGridView1.CurrentRow.Cells[7].Value.ToString();
            affair.TimeInterval = Int32.Parse(DataGridView1.CurrentRow.Cells[8].Value.ToString());
            affair.Unit = DataGridView1.CurrentRow.Cells[9].Value.ToString();
            affair.RemindTimes = Int32.Parse(DataGridView1.CurrentRow.Cells[10].Value.ToString());
            Pomodoro p = new Pomodoro(Main, affair);
            Main.Hide();
            p.ShowDialog();
        }
    }
}
