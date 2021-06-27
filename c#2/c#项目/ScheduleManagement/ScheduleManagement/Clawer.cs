using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ScheduleManagement.clawer;
using ScheduleManagement.Entity;
using ScheduleManagement.Service;

namespace ScheduleManagement
{
    public partial class Clawer : UserControl
    {
        SQLiteConnection m_dbConnection;
        AffairService aff = new AffairService();
        BindingSource resultBindingSource = new BindingSource();
        EuropeanCup claw0 = new EuropeanCup();
        zhongchao claw = new zhongchao();
        WorldCup claw2 = new WorldCup();
        Movie claw3 = new Movie();
        AFC claw4 = new AFC();
        CSlecture claw5 = new CSlecture();
        public Clawer()
        {
            InitializeComponent();
            Result.DataSource = resultBindingSource;
            claw0.ENewsDownloaded += Clawer_ENewsDownloaded;
            claw.NewsDownloaded += Clawer_NewsDownloaded;
            claw2.WNewsDownloaded += Clawer_WNewsDownloaded;
            claw3.MoviesDownloaded += Clawer_MoviesDownloaded;
            claw4.ANewsDownloaded += Clawer_ANewsDownloaded;
            claw5.LNewsDownloaded += Clawer_LNewsDownloaded;

        }
        private Graphics graphics;


        private void Clawer_ENewsDownloaded(EuropeanCup crawler, string zt, string day, string time, string player1, string player2, string link)
        {
            var newpage = new { 序号 = resultBindingSource.Count + 1, 状态 = zt, 日期 = day, 开始时间 = time, 对阵双方左 = player1, 对阵双方右 = player2, 直播链接 = link };
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

        private void Clawer_NewsDownloaded(zhongchao crawler, string day, string weekday, string time, string player1, string player2, string turn, string link)
        {
            var newpage = new { 序号 = resultBindingSource.Count + 1, 日期 = day, 周几 = weekday, 开始时间 = time, 对阵双方左 = player1, 对阵双方右 = player2, 轮次 = turn, 直播链接 = link };
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

        private void Clawer_WNewsDownloaded(WorldCup crawler, string zt, string day, string time, string player1, string player2, string link)
        {
            var newpage = new { 序号 = resultBindingSource.Count + 1, 状态 = zt, 日期 = day, 开始时间 = time, 对阵双方左 = player1, 对阵双方右 = player2, 直播链接 = link };
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

        private void Clawer_MoviesDownloaded(Movie crawler, string name, string time, string type, string actors, string scores, string url)
        {
            var newpage = new { Index = resultBindingSource.Count + 1, Name = name, Time = time, Type = type, Actors = actors, Scores = scores, Url = url };
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

        private void Clawer_ANewsDownloaded(AFC crawler, string zt, string day, string time, string player1, string player2, string link)
        {
            var newpage = new { 序号 = resultBindingSource.Count + 1, 状态 = zt, 日期 = day, 开始时间 = time, 对阵双方左 = player1, 对阵双方右 = player2, 直播链接 = link };
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

        private void Clawer_LNewsDownloaded(CSlecture crawler, string title, string Day, string Time, string address, string person, string danwei, string link)
        {
            var newpage = new { 序号 = resultBindingSource.Count + 1, 报告题目 = title, 报告日期 = Day, 开始时间 = Time, 报告地点 = address, 报告人 = person, 报告单位 = danwei, 详情链接 = link };
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
            claw.loveplayer = textBox2.Text;
            claw0.loveplayer = textBox2.Text;
            claw2.loveplayer = textBox2.Text;
            claw4.loveplayer = textBox2.Text;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    claw0.Excute();
                    break;
                case 1:
                    claw.Excute();
                    break;
                case 2:
                    claw2.Excute();
                    break;
                case 3:
                    claw3.Excute();
                    break;
                case 4:
                    claw4.Excute();
                    break;
                case 5:
                    claw5.Excute();
                    break;
                default:
                    break;
            }
            // Task task = Task.Run(() => claw.Excute());
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Result_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {/*
            DataGridViewRow row = this.Result.CurrentRow;
            this.label1.Text = row.Cells[0].Value.ToString();
            this.textBox1.Text = row.Cells[1].Value.ToString();
            this.textBox2.Text = row.Cells[2].Value.ToString();
            this.textBox3.Text = row.Cells[3].Value.ToString();
            this.textBox4.Text = row.Cells[4].Value.ToString();
            this.textBox5.Text = row.Cells[5].Value.ToString();
            */
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.Result.CurrentRow;
            string detail = row.Cells[7].Value.ToString();
            System.Diagnostics.Process.Start(detail);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*      var newpage = new { 
             *    0  序号 = resultBindingSource.Count + 1, 
             *    1  报告题目 = title, 
             *    2  报告日期 = Day, 
             *    3  开始时间 = Time, 
             *    4  报告地点 = address, 
             *    5  报告人 = person, 
             *    6  报告单位 = danwei, 
             *    7  详情链接 = link };
             */
            DataGridViewRow row = this.Result.CurrentRow;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AffairInfo(");
            strSql.Append("Title,Place,DateTime,Urgency,Content)");
            strSql.Append(" values (");
            strSql.Append("@Title,@Place,@DateTime,@Urgency,@Content)");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Title", DbType.String,25),
                    new SQLiteParameter("@Place", DbType.String,25),
                    new SQLiteParameter("@DateTime", DbType.DateTime),
                    new SQLiteParameter("@Urgency", DbType.String,25),
                    new SQLiteParameter("@Content", DbType.String,100)};
            parameters[0].Value = row.Cells[1].Value.ToString();
            parameters[1].Value = row.Cells[4].Value.ToString();
            parameters[2].Value = Convert.ToDateTime(row.Cells[2].Value.ToString() + "  "+row.Cells[3].Value.ToString());
            parameters[3].Value = "111";
            parameters[4].Value = "详情页： "+row.Cells[7].Value.ToString();


            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
     
        }
    }
}
