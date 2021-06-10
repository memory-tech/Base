using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ScheduleManagement.clawer;

namespace ScheduleManagement
{
    public partial class UserControl4 : UserControl
    {
        BindingSource resultBindingSource = new BindingSource();
        EuropeanCup claw0 = new EuropeanCup();
        zhongchao claw = new zhongchao();
        WorldCup claw2 = new WorldCup();
        Movie claw3 = new Movie();
        AFC claw4 = new AFC();
        public UserControl4()
        {
            InitializeComponent();
            Result.DataSource = resultBindingSource;
            claw0.ENewsDownloaded += Clawer_ENewsDownloaded;
            claw.NewsDownloaded += Clawer_NewsDownloaded;
            claw2.WNewsDownloaded += Clawer_WNewsDownloaded;
            claw3.MoviesDownloaded += Clawer_MoviesDownloaded;
            claw4.ANewsDownloaded += Clawer_ANewsDownloaded;
            
        }
        private Graphics graphics;

        private void Clawer_ENewsDownloaded(EuropeanCup crawler, string zt, string day, string time, string player1, string player2, string link)
        {
            var newpage = new { 序号 = resultBindingSource.Count + 1, 状态 = zt,日期 = day, 开始时间 = time, 对阵双方左 = player1, 对阵双方右 = player2,  直播链接 = link };
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

        private void Clawer_NewsDownloaded(zhongchao crawler, string day, string weekday,string time ,string player1,string player2,string turn,string link)
        {
            var newpage = new { 序号 = resultBindingSource.Count + 1, 日期 = day, 周几 = weekday, 开始时间 = time,对阵双方左 = player1, 对阵双方右 = player2,轮次=turn,直播链接 = link };
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
            var newpage = new { Index = resultBindingSource.Count + 1,Name = name,Time = time,Type = type,Actors = actors,Scores = scores,Url = url };
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
                default:
                    break;
            }
           // Task task = Task.Run(() => claw.Excute());
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
