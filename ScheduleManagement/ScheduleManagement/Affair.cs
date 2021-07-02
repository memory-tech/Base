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
            DataSet ds = aff.GetListOrderbyUrgency("");
            this.DataGridView1.DataSource = ds.Tables[0];

            //列的宽度
            DataGridView1.Columns["Urgency"].Width = 70;
            DataGridView1.Columns["Title"].Width = 100;

            //修改数据列的标题名
            DataGridView1.Columns[1].HeaderCell.Value = "紧急程度";
            DataGridView1.Columns[5].HeaderCell.Value = "事项";

            //隐藏列
            DataGridView1.Columns[0].Visible = false;     //affairid
            DataGridView1.Columns[2].Visible = false;     //place
            DataGridView1.Columns[3].Visible = false;     //datetime
            DataGridView1.Columns[4].Visible = false;     //endtime
            DataGridView1.Columns[6].Visible = false;     //content
            DataGridView1.Columns[7].Visible = false;     //state
            DataGridView1.Columns[8].Visible = false;     //timeinterval
            DataGridView1.Columns[9].Visible = false;     //unit
            DataGridView1.Columns[10].Visible = false;    //remindtimes
            DataGridView1.Columns[11].Visible = false;    //stander   
        }

        AffairService aff = new AffairService();
        ReminderService rs = new ReminderService();
        ClockTimeCalculation ctc = new ClockTimeCalculation();

        //增
        int count = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            count++;
            Entity.Affair affair = new Entity.Affair();
            affair.Title  = "新建事件" + count;
            affair.Place = "";
            affair.DateTime = Convert.ToDateTime("2021-01-01 09:00:00");
            affair.EndTime = Convert.ToDateTime("2021-01-01 09:00:00");
            affair.Urgency = "未知";
            affair.Content = "";
            affair.State = "未完成";
            affair.TimeInterval = 1;
            affair.Unit = "分";
            affair.RemindTimes = 1;
            affair.Stander = aff.GetStander(affair.DateTime);
            aff.Add(affair);
            DataSet ds = aff.GetListOrderbyUrgency("");
            this.DataGridView1.DataSource = ds.Tables[0];
            
            //自动添加到ReminderTime表
            Entity.ReminderTime rt = new Entity.ReminderTime();
            rt.Title1 = affair.Title;
            rt.DateTime1 = affair.DateTime;
            rt.EndTime1 = affair.EndTime;
            rt.State1 = affair.State;
            rt.TimeInterval1 = affair.TimeInterval;
            rt.Unit1 = affair.Unit;
            rt.RemindTimes1 = affair.RemindTimes;
            DateTime Time = (DateTime.Compare(affair.DateTime , DateTime.Now) >= 0) ? affair.DateTime : affair.EndTime;
            ctc.GetClockTime1to3(affair, rt, Time);
            rs.Add(rt);
            
            //点击添加事件后,右侧自动显示该事件默认属性值
            DataGridViewRow row = this.DataGridView1.Rows[aff.GetRecordCount("")-1];
            this.label1.Text = row.Cells[0].Value.ToString();
            this.label_test_AffId.Text = this.label1.Text;
            this.cmb_urgency.SelectedItem = row.Cells[1].Value;
            this.textBox_place.Text = row.Cells[2].Value.ToString();
            this.dateTimePicker_datetime.Value = DateTime.Parse(row.Cells[3].Value.ToString());
            this.dateTimePicker_endtime.Value = DateTime.Parse(row.Cells[4].Value.ToString());
            this.textBox_Title.Text = row.Cells[5].Value.ToString();
            this.textBox_content.Text = row.Cells[6].Value.ToString();
            this.cmb_state.SelectedItem = row.Cells[7].Value;
            this.textBox_TimeInterval.Text = row.Cells[8].Value.ToString();
            this.cmb_unit.SelectedItem= row.Cells[9].Value;            
            this.cmb_remindtimes.SelectedIndex = Int32.Parse(row.Cells[10].Value.ToString())-1;
        }

        //改
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Entity.Affair affair = new Entity.Affair();
                affair.AffairId = Int32.Parse(this.label1.Text);
                affair.Title = this.textBox_Title.Text;
                affair.Place = this.textBox_place.Text;
                affair.DateTime = this.dateTimePicker_datetime.Value;
                affair.EndTime = this.dateTimePicker_endtime.Value;
                affair.Urgency = this.cmb_urgency.SelectedItem.ToString();
                affair.Content = this.textBox_content.Text;
                affair.State = this.cmb_state.SelectedItem.ToString();
                affair.TimeInterval = Int32.Parse(this.textBox_TimeInterval.Text);
                affair.Unit = this.cmb_unit.SelectedItem.ToString();
                affair.RemindTimes = Int32.Parse(this.cmb_remindtimes.SelectedItem.ToString());
                affair.Stander = aff.GetStander(affair.DateTime);
                aff.Update(affair);
                DataSet ds = aff.GetListOrderbyUrgency("");
                this.DataGridView1.DataSource = ds.Tables[0];


                //自动更新ReminderTime表
                Entity.ReminderTime rt = new Entity.ReminderTime();
                rt.AffId = Int32.Parse(this.label_test_AffId.Text);
                rt.Title1 = affair.Title;
                rt.DateTime1 = affair.DateTime;
                rt.EndTime1 = affair.EndTime;
                rt.State1 = affair.State;
                rt.TimeInterval1 = affair.TimeInterval;
                rt.Unit1 = affair.Unit;
                rt.RemindTimes1 = affair.RemindTimes;
                DateTime Time = (DateTime.Compare(affair.DateTime, DateTime.Now) >= 0) ? affair.DateTime : affair.EndTime;
                ctc.GetClockTime1to3(affair, rt,Time);
                rs.Update(rt);
            }
            catch (Exception)
            {
                MessageBox.Show("未选中事项！", "提示");
            }
        }

        //删
        private void button4_Click(object sender, EventArgs e)
        {
            try { 
                aff.Delete(int.Parse(this.label1.Text));
                DataSet ds = aff.GetListOrderbyUrgency("");
                this.DataGridView1.DataSource = ds.Tables[0];
            
                //自动删除ReminderTime 表中相应的数据
                rs.Delete(int.Parse(this.label_test_AffId.Text));
                this.label_test_AffId.Text = "";
            
                //事件删除后，右侧详情栏清空
                this.label1.Text = "";
                this.textBox_Title.Text = "";
                this.textBox_place.Text = "";
                this.dateTimePicker_datetime.Value = Convert.ToDateTime("2021-01-01 09:00:00");
                this.dateTimePicker_endtime.Value = Convert.ToDateTime("2021-01-01 09:00:00");
                this.cmb_urgency.SelectedItem = "";
                this.textBox_content.Text = "";
                this.cmb_state.SelectedItem = "";
                this.textBox_TimeInterval.Text = "";
                this.cmb_unit.SelectedItem = "";
                this.cmb_remindtimes.SelectedIndex = 3;
            }
            catch (Exception)
            {
                MessageBox.Show("未选中事项！", "提示");
            }
        }

        //鼠标单击主题在右侧显示详细信息
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.DataGridView1.CurrentRow;
            this.label1.Text = row.Cells[0].Value.ToString();
            this.cmb_urgency.SelectedItem = row.Cells[1].Value;
            this.textBox_place.Text = row.Cells[2].Value.ToString();
            this.dateTimePicker_datetime.Value= Convert.ToDateTime(row.Cells[3].Value.ToString());
            this.dateTimePicker_endtime.Value = Convert.ToDateTime(row.Cells[4].Value.ToString());
            this.textBox_Title.Text = row.Cells[5].Value.ToString();
            this.textBox_content.Text = row.Cells[6].Value.ToString();
            this.cmb_state.SelectedItem = row.Cells[7].Value;
            this.textBox_TimeInterval.Text = row.Cells[8].Value.ToString();
            this.cmb_unit.SelectedItem = row.Cells[9].Value;
            this.cmb_remindtimes.SelectedIndex = Int32.Parse(row.Cells[10].Value.ToString())-1;

            //由AffairInfod的AffairId查询到ReminderTime的AffId的过程；
            this.label_test_AffId.Text = row.Cells[0].Value.ToString();
        }

        

        private void DataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Entity.Affair affair = new Entity.Affair();
            affair.AffairId = Int32.Parse(DataGridView1.CurrentRow.Cells[0].Value.ToString());
            affair.Urgency = DataGridView1.CurrentRow.Cells[1].Value.ToString();
            affair.Place = DataGridView1.CurrentRow.Cells[2].Value.ToString();
            affair.DateTime = DateTime.Parse(DataGridView1.CurrentRow.Cells[3].Value.ToString());
            affair.EndTime = DateTime.Parse(DataGridView1.CurrentRow.Cells[4].Value.ToString());
            affair.Title = DataGridView1.CurrentRow.Cells[5].Value.ToString();
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
