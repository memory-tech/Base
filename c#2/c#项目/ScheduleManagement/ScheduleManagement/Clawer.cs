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
        //链接数据库
        SQLiteConnection m_dbConnection;
        //实例一个待办事项，为将某条爬取到的事务添加进去做准备
        AffairService aff = new AffairService();
        //绑定数据
        BindingSource resultBindingSource = new BindingSource();
        //实例爬虫——欧冠杯
        EuropeanCup clawEuropeanCup = new EuropeanCup();
        //实例爬虫——中超
        zhongchao clawzhongchao = new zhongchao();
        //实例爬虫——最新电影
        Movie clawMovie = new Movie();
        //实例爬虫——亚冠
        AFC clawAFC = new AFC();
        //实例爬虫——计算机学院讲座
        CSlecture clawCSlecture = new CSlecture();
        //实例爬虫——音乐会
        Concert clawConcert = new Concert();
        //实例爬虫——Livehouse
        Livehouse clawLivehouse = new Livehouse();
        //实例爬虫——舞蹈表演
        Dance clawDance = new Dance();
        //实例爬虫——话剧
        ModernDrama clawModernDrama = new ModernDrama();

        public Clawer()
        {
            InitializeComponent();
            //绑定数据
            Result.DataSource = resultBindingSource;
            //下面都是绑定委托
            clawEuropeanCup.ENewsDownloaded += Clawer_ENewsDownloaded;
            clawzhongchao.NewsDownloaded += Clawer_NewsDownloaded;
            clawMovie.MoviesDownloaded += Clawer_MoviesDownloaded;
            clawAFC.ANewsDownloaded += Clawer_ANewsDownloaded;
            clawCSlecture.LNewsDownloaded += Clawer_LNewsDownloaded;
            clawConcert.ConcertDownloaded += Clawer_ConcertDownloaded;
            clawLivehouse.LivehouseDownloaded += Clawer_LivehouseDownloaded;
            clawDance.DanceDownloaded += Clawer_DanceDownloaded;
            clawModernDrama.ModernDramaDownloaded += Clawer_ModernDramaDownloaded;

        }
        //   private Graphics graphics;

        private void button1_Click(object sender, EventArgs e)
        {
            resultBindingSource.Clear();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    clawEuropeanCup.Excute();
                    break;
                case 1:
                    clawzhongchao.Excute();
                    break;
                case 2:
                    clawMovie.Excute();
                    break;
                case 3:
                    clawAFC.Excute();
                    break;
                case 4:
                    clawCSlecture.Excute();
                    break;
                case 5:
                    clawConcert.Excute();
                    break;
                case 6:
                    clawLivehouse.Excute();
                    break;
                case 7:
                    clawDance.Excute();
                    break;
                case 8:
                    clawModernDrama.Excute();
                    break;
                default:
                    break;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //点击查看——使用默认浏览器跳转到详情页面，快速查看详情，直接获取对应的url调用默认浏览器进行跳转
        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.Result.CurrentRow;
            string detail = row.Cells[7].Value.ToString();
            System.Diagnostics.Process.Start(detail);
        }


        //将选定的事件添加进入待办事项
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
            parameters[2].Value = Convert.ToDateTime(row.Cells[2].Value.ToString() + "  " + row.Cells[3].Value.ToString());
            parameters[3].Value = "111";
            parameters[4].Value = "详情页： " + row.Cells[7].Value.ToString();
            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
        }

        //下面是对datagridview的一些设置
        //欧冠杯——定义DataGridview里列表项，以及对于绑定的数据
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
        //中超——定义DataGridview里列表项，以及对于绑定的数据
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
        //音乐会——定义DataGridview里列表项，以及对于绑定的数据
        private void Clawer_ConcertDownloaded(Concert crawler, string state, string name, string time, string place,string money, string link)
        {
            var newpage = new { 序号 = resultBindingSource.Count + 1, 状态 = state, 主题 = name, 时间 = time, 地点 = place, 价格 = money, 直播链接 = link };
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
        //Livehouse——定义DataGridview里列表项，以及对于绑定的数据
        private void Clawer_LivehouseDownloaded(Livehouse crawler, string state, string name, string time, string place, string money, string link)
        {
            var newpage = new { 序号 = resultBindingSource.Count + 1, 状态 = state, 主题 = name, 时间 = time, 地点 = place, 价格 = money, 直播链接 = link };
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
        //舞蹈表演——定义DataGridview里列表项，以及对于绑定的数据
        private void Clawer_DanceDownloaded(Dance crawler, string state, string name, string time, string place, string money, string link)
        {
            var newpage = new { 序号 = resultBindingSource.Count + 1, 状态 = state, 主题 = name, 时间 = time, 地点 = place, 价格 = money, 直播链接 = link };
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
        //话剧表演——定义DataGridview里列表项，以及对于绑定的数据
        private void Clawer_ModernDramaDownloaded(ModernDrama crawler, string state, string name, string time, string place, string money, string link)
        {
            var newpage = new { 序号 = resultBindingSource.Count + 1, 状态 = state, 主题 = name, 时间 = time, 地点 = place, 价格 = money, 直播链接 = link };
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
        //最新电影——定义DataGridview里列表项，以及对于绑定的数据
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
        //亚冠——定义DataGridview里列表项，以及对于绑定的数据
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
        //计算机学院讲座——定义DataGridview里列表项，以及对于绑定的数据
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

    }
}
