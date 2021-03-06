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
using System.Text.RegularExpressions;

namespace ScheduleManagement
{
    public partial class Schedule : UserControl
    {
        public Main Main = new Main();
        public DataTable ToDataTable(DataRow[] rows)
        {
            if (rows == null || rows.Length == 0) return null;
            DataTable tmp = rows[0].Table.Clone(); // 复制DataRow的表结构
            foreach (DataRow row in rows)
            {

                tmp.ImportRow(row); // 将DataRow添加到DataTable中
            }
            return tmp;
        }
        public Schedule(Main m)
        {
            Main = m;
            InitializeComponent();
            
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DateTime,AffairId,Title,Place,EndTime,Urgency,Content,State,TimeInterval,Unit,RemindTimes,Stander ");
            strSql.Append(" FROM AffairInfo Order by DateTime ASC");
            DataSet ds = DbHelperSQLite.Query(strSql.ToString());
            DataRow[] dd = ds.Tables[0].Select("Stander = '0'");
            DataTable today = this.ToDataTable(dd);
            this.dataGridView2.DataSource = today;
            dataGridView2.Columns["DateTime"].Width = 125;
            dataGridView2.Columns["Title"].Width = 107;
            if (this.dataGridView2.Rows.Count > 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[0];
                
                dataGridView2.Columns[0].HeaderCell.Value = "时间";
                dataGridView2.Columns[2].HeaderCell.Value = "事项";
                placeBox.Text = row.Cells[3].Value == null?"":row.Cells[3].Value.ToString();
                starttimeBox.Text = row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString();
                endtimeBox.Text = row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString();
                stateBox.Text = row.Cells[7].Value == null ? "" : row.Cells[7].Value.ToString();
                if (endtimeBox.Text == "0001-01-01 00:00:00" || row.Cells[4].Value != null) endtimeBox.Text = "";
            }
            
            //隐藏列            
            dataGridView2.Columns[1].Visible = false;     
            dataGridView2.Columns[3].Visible = false;     
            dataGridView2.Columns[4].Visible = false;     
            dataGridView2.Columns[5].Visible = false;     
            dataGridView2.Columns[6].Visible = false;     
            dataGridView2.Columns[7].Visible = false;    
            dataGridView2.Columns[8].Visible = false;     
            dataGridView2.Columns[9].Visible = false;
            dataGridView2.Columns[10].Visible = false;
            dataGridView2.Columns[11].Visible = false;
        }
        //用于委托，在main里每次进入该界面时被调用，来刷新datagridview
        private void UserControl5_Load(object sender, EventArgs e)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DateTime,AffairId,Title,Place,EndTime,Urgency,Content,State,TimeInterval,Unit,RemindTimes,Stander ");
            strSql.Append(" FROM AffairInfo Order by DateTime ASC");
            DataSet ds = DbHelperSQLite.Query(strSql.ToString());
            DataRow[] dd = ds.Tables[0].Select("stander = '0'");
            DataTable today = this.ToDataTable(dd);
            this.dataGridView2.DataSource = today;
            if (this.dataGridView2.Rows.Count > 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[0];
                dataGridView2.Columns[0].HeaderCell.Value = "时间";
                dataGridView2.Columns[2].HeaderCell.Value = "事项";
                placeBox.Text = row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString();
                starttimeBox.Text = row.Cells[0].Value == null ? "" : row.Cells[0].Value.ToString();
                endtimeBox.Text = row.Cells[4].Value == null ? "" : row.Cells[4].Value.ToString();
                stateBox.Text = row.Cells[7].Value == null ? "" : row.Cells[7].Value.ToString();
                if (endtimeBox.Text == "0001-01-01 00:00:00" || row.Cells[4].Value != null) endtimeBox.Text = "";
            }
        }
        //设置行的颜色
        string st;
        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1 && this.dataGridView2.Rows[e.RowIndex].Cells[7].Value != null)
            {
                st = this.dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                if (st == "完成")
                {
                    dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleTurquoise;
                }
                else if (st == "未完成")
                {
                    dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Orange;
                }
            }
        }
        //点击查看事项
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.CurrentRow;
            placeBox.Text = row.Cells[3].Value.ToString();
            starttimeBox.Text = row.Cells[0].Value.ToString();
            endtimeBox.Text = row.Cells[4].Value.ToString();
            stateBox.Text = row.Cells[7].Value.ToString();
            if (endtimeBox.Text == "0001/1/1 0:00:00" || row.Cells[4].Value == null) endtimeBox.Text = "";
        }
        //进入番茄钟
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.CurrentRow;
            if (row.Cells[7].Value.ToString() != "完成")
            {
                Entity.Affair affair = new Entity.Affair();
                affair.AffairId = Int32.Parse(dataGridView2.CurrentRow.Cells[1].Value.ToString());
                affair.Title = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                affair.Place = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                affair.DateTime = DateTime.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                affair.EndTime = DateTime.Parse(dataGridView2.CurrentRow.Cells[4].Value.ToString());
                affair.Urgency = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                affair.Content = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                affair.State = dataGridView2.CurrentRow.Cells[7].Value.ToString();
                affair.TimeInterval = Int32.Parse(dataGridView2.CurrentRow.Cells[8].Value.ToString());
                affair.Unit = dataGridView2.CurrentRow.Cells[9].Value.ToString();
                affair.RemindTimes = Int32.Parse(dataGridView2.CurrentRow.Cells[10].Value.ToString());
                Pomodoro p = new Pomodoro(Main, affair);
                Main.Hide();
                p.ShowDialog();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //更新日程里的选定项
            DataGridViewRow row = this.dataGridView2.CurrentRow;
            Entity.Affair affair = new Entity.Affair();
            AffairService aff = new AffairService();
            affair.AffairId = Convert.ToInt32(row.Cells[1].Value.ToString());
            affair.Title = row.Cells[2].Value.ToString();
            affair.Place = row.Cells[3].Value.ToString();
            affair.DateTime = DateTime.Parse(row.Cells[0].Value.ToString());
            affair.EndTime = DateTime.Parse(row.Cells[4].Value.ToString());
            affair.Urgency = row.Cells[5].Value.ToString();
            affair.Content = row.Cells[6].Value.ToString();
            affair.State = "完成";
            affair.TimeInterval = Convert.ToInt32(row.Cells[8].Value.ToString());
            affair.Unit = row.Cells[9].Value.ToString();
            affair.RemindTimes = Convert.ToInt32(row.Cells[10].Value.ToString());
            affair.Stander = aff.GetStander(affair.DateTime);
            aff.Update(affair);
            //改完状态刷新一下
            DataSet ds = aff.GetAllList();
            DataRow[] dd = ds.Tables[0].Select("stander = '0'");
            DataTable today = this.ToDataTable(dd);
            this.dataGridView2.DataSource = today;
            row = this.dataGridView2.Rows[1];
            placeBox.Text = row.Cells[2].Value.ToString();
            starttimeBox.Text = row.Cells[3].Value.ToString();
            endtimeBox.Text = row.Cells[4].Value.ToString();
            stateBox.Text = row.Cells[7].Value.ToString();
            if (endtimeBox.Text == "0001-01-01 00:00:00" || row.Cells[4].Value != null) endtimeBox.Text = "";
         row.DefaultCellStyle.BackColor = Color.LightGreen;
            //祝贺！
            DialogResult rst = MessageBox.Show("恭喜您! \r\n 又搞定一个ddl \r\n  耶！");
        }
    }
}
