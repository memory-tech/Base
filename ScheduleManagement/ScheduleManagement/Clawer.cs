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
        //实例爬虫——LPL
        LPL clawLPL = new LPL();
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
        //所选类型，默认在设置中读取
        int select = 0;
        public Clawer()
        {
            InitializeComponent();
            //绑定数据
            Result.DataSource = resultBindingSource;
            //下面都是绑定委托
            clawEuropeanCup.ENewsDownloaded += Clawer_ENewsDownloaded;
            clawzhongchao.NewsDownloaded += Clawer_NewsDownloaded;
            clawMovie.MoviesDownloaded += Clawer_MoviesDownloaded;
            clawLPL.ANewsDownloaded += Clawer_ANewsDownloaded;
            clawCSlecture.LNewsDownloaded += Clawer_LNewsDownloaded;
            clawConcert.ConcertDownloaded += Clawer_ConcertDownloaded;
            clawLivehouse.LivehouseDownloaded += Clawer_LivehouseDownloaded;
            clawDance.DanceDownloaded += Clawer_DanceDownloaded;
            clawModernDrama.ModernDramaDownloaded += Clawer_ModernDramaDownloaded;
            
            //在初始化的时候即从数据库取数据，实现一进入该界面就可以展示
            OthersServiceDetails osd = new OthersServiceDetails();
            DataSet ds = osd.GetPreferenceList();
            this.preference.SelectedIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["Preference"]);
            this.search();
         //设置为cell可自动换行  Result.Columns[1].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
        }
        OthersServiceDetails osd = new OthersServiceDetails();
        //设置每行颜色
        private void Result_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1)
            {                
              Result.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gold;              
            }
        }
        //开始搜索
        private void button1_Click(object sender, EventArgs e)
        {         
            this.search();
            Entity.Others others = new Entity.Others();
            others.Preference = preference.SelectedIndex;
            osd.UpdatePreference(others);
        }
        //根据选取的类型爬取相应的数据进行展示，select用于添加待办事项时不同的处理方式
        public void search()
        {
            resultBindingSource.Clear();
            switch (preference.SelectedIndex)
            {
                case 0:
                    clawCSlecture.Excute();
                    select = 0;
                    break;
                case 1:
                    clawMovie.Excute();
                    select = 1;
                    break;
                case 2:
                    clawConcert.Excute();
                    //   detailnum = 6;
                    select = 2;
                    break;
                case 3:
                    clawLivehouse.Excute();
                    //    detailnum = 6;
                    select = 2;
                    break;
                case 4:
                    clawDance.Excute();
                    //  detailnum = 6;
                    select = 2;
                    break;
                case 5:
                    clawModernDrama.Excute();
                    //    detailnum = 6;
                    select = 2;
                    break;
                case 6:
                    clawEuropeanCup.Excute();
                    //    detailnum = 6;
                    select = 3;
                    break;
                case 7:
                    clawzhongchao.Excute();
                    //    detailnum = 6;
                    select = 4;
                    break;
                case 8:
                    clawLPL.Excute();
                    //    detailnum = 6;
                    select = 8;
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
            string detail;
            if (select != 8)
            {
                detail = row.Cells[6].Value.ToString();
            }
            else
            {
                detail = row.Cells[5].Value.ToString();
            }
            //System.Diagnostics.Process.Start(detail);

            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = detail,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception)
            {//对特殊情况进行处理
                DialogResult rst = MessageBox.Show("        比赛已延期！\r\n    请等待后续消息!");
            }
        }
        //将选定的事件添加进入待办事项
        private void button2_Click(object sender, EventArgs e)
        {           
            DataGridViewRow row = this.Result.CurrentRow;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AffairInfo(");
            strSql.Append("Title,Place,DateTime,Urgency,Content,State,EndTime,Stander,timeinterval,unit,remindtimes)");
            strSql.Append(" values (");
            strSql.Append("@Title,@Place,@DateTime,@Urgency,@Content,@State,@EndTime,@Stander,@timeinterval,@unit,@remindtimes)");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Title", DbType.String,25),
                    new SQLiteParameter("@Place", DbType.String,25),
                    new SQLiteParameter("@DateTime", DbType.DateTime),
                    new SQLiteParameter("@Urgency", DbType.String,25),
                    new SQLiteParameter("@Content", DbType.String,100),
                    new SQLiteParameter("@State",DbType.String,10),
                    new SQLiteParameter("@EndTime",DbType.DateTime),
                    new SQLiteParameter("@Stander",DbType.Int32,10),
                    new SQLiteParameter("@timeinterval",DbType.Int32,10),
                    new SQLiteParameter("@unit",DbType.String,10),
                    new SQLiteParameter("@remindtimes",DbType.Int32,10)};
            //优先级
            parameters[3].Value = "未知";
            //计算是不是今天，0为今天
            DateTime d2 = DateTime.Now;
            //间隔时间以及提醒次数的设定
            parameters[8].Value = 1;
            parameters[9].Value = "分";
            parameters[10].Value = 1;
            switch (select)
            {
                case 0://计算机学院讲座
                       //标题
                    parameters[0].Value = row.Cells[1].Value.ToString();
                    //地点
                    parameters[1].Value = row.Cells[5].Value.ToString();
                    //时间
                    parameters[2].Value = Convert.ToDateTime(row.Cells[3].Value.ToString() + "  " + row.Cells[4].Value.ToString());
                    //截止时间
                    parameters[6].Value = Convert.ToDateTime(row.Cells[3].Value.ToString() + "  " + row.Cells[4].Value.ToString());
                    //内容
                    parameters[4].Value = "详情页： " + row.Cells[6].Value.ToString();
                    //若为0则为今天
                    parameters[7].Value = Convert.ToInt32(d2.Subtract(Convert.ToDateTime(row.Cells[3].Value.ToString() + "  " + row.Cells[4].Value.ToString())).Days);                   
                    break;
                    
                case 1://电影                 
                    //标题
                    parameters[0].Value = row.Cells[1].Value.ToString();
                    //地点
                    parameters[1].Value = "武汉";
                    //时间
                    parameters[2].Value = Convert.ToDateTime(row.Cells[2].Value.ToString());
                    //截止时间
                    parameters[6].Value = Convert.ToDateTime(row.Cells[2].Value.ToString());
                    //内容
                    parameters[4].Value = "类型： " + row.Cells[3].Value.ToString() + "  主演： " + row.Cells[4].Value.ToString() +"  评分： " + row.Cells[5].Value.ToString();
                    //若为0则为今天
                    parameters[7].Value = Convert.ToInt32(d2.Subtract(Convert.ToDateTime(row.Cells[2].Value.ToString())).Days);
                    break;

                case 2://音乐会、livehouse、话剧、舞蹈表演
                       //标题
                    string x = @"[\u4E00-\u9FFF]+";
                    MatchCollection Matchestype = Regex.Matches
                    (row.Cells[1].Value.ToString(), x, RegexOptions.IgnoreCase);
                    StringBuilder itstype = new StringBuilder();
                    foreach (Match NextMatch in Matchestype)
                    {
                        itstype.Append(NextMatch.Value);
                    }
                    parameters[0].Value = itstype.ToString();
                    //地点
                    parameters[1].Value = row.Cells[4].Value.ToString();
                    //处理特殊情况，时间段  2021.11.11-2021.11.12
                    string sss = row.Cells[3].Value.ToString();
                    if (sss.Contains("-"))
                    {
                        int t = sss.IndexOf("-");
                        //时间
                        parameters[2].Value = Convert.ToDateTime(sss.Substring(0, t));
                        //截止时间
                        parameters[6].Value = Convert.ToDateTime(sss.Substring(t + 1, t));
                        //若为0则为今天
                        parameters[7].Value = Convert.ToInt32(d2.Subtract(Convert.ToDateTime(sss.Substring(0, t))).Days);
                    }
                    else
                    {
                        //时间
                        parameters[2].Value = Convert.ToDateTime(row.Cells[3].Value.ToString());
                        //若为0则为今天
                        parameters[7].Value = Convert.ToInt32(d2.Subtract(Convert.ToDateTime(row.Cells[3].Value.ToString())).Days);
                    }
                    //内容
                    parameters[4].Value = row.Cells[2].Value.ToString();
                    
                    break;

                case 3://欧洲杯
                   //标题
                    parameters[0].Value = row.Cells[4].Value.ToString() + " VS " + row.Cells[5].Value.ToString();
                    //地点
                    parameters[1].Value = "线上观看";
                    //时间
                    parameters[2].Value = Convert.ToDateTime("2021-"+row.Cells[2].Value.ToString() + " " + row.Cells[3].Value.ToString());
                    //内容
                    parameters[4].Value = "状态： " + row.Cells[1].Value.ToString();
                    //若为0则为今天
                    parameters[7].Value = Convert.ToInt32(d2.Subtract(Convert.ToDateTime("2021-" + row.Cells[2].Value.ToString() + " " + row.Cells[3].Value.ToString())).Days);
                    break;

                case 4://中超
                   // DialogResult rstt = MessageBox.Show("        比赛已延期！\r\n    请等待后续消息!");
                
               //标题
                parameters[0].Value ="比赛已延期！ "+ row.Cells[3].Value.ToString() + " VS " + row.Cells[4].Value.ToString();
                //地点
                parameters[1].Value = "线上观看";
                //时间
                parameters[2].Value = Convert.ToDateTime(row.Cells[1].Value.ToString()+" 12:00:00");
                //内容
                parameters[4].Value = "轮次： " + row.Cells[5].Value.ToString();
                //若为0则为今天
                parameters[7].Value = Convert.ToInt32(d2.Subtract(Convert.ToDateTime(row.Cells[1].Value.ToString())).Days);
                
                    break;
                

                case 8://LPL
                   //标题
                    parameters[0].Value = "2021LPL夏季赛"+row.Cells[3].Value.ToString() + " VS " + row.Cells[4].Value.ToString();
                    //地点
                    parameters[1].Value = "线上观看";
                    //时间
                    parameters[2].Value = Convert.ToDateTime(row.Cells[1].Value.ToString() + " "+ row.Cells[2].Value.ToString());
                    //内容
                    parameters[4].Value = "详情见虎牙直播";
                    //若为0则为今天
                    parameters[7].Value = Convert.ToInt32(d2.Subtract(Convert.ToDateTime(row.Cells[1].Value.ToString() + " " + row.Cells[2].Value.ToString())).Days);
                    break;

                default:
                    break;
            }
            //状态：今天之前的为“已完成”，今天之后的为“未完成”d2.Subtract()得出的一天之后的为负数
            if (Convert.ToInt32(parameters[7].Value) <= 0)
            {
                parameters[5].Value = "未完成";
            }
            else
            {
                parameters[5].Value = "完成";
            }
            if (parameters[6].Value == null) parameters[6].Value = "2021-01-01 09:00:00";
            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            DialogResult rst = MessageBox.Show(" 添加成功 !");
        }

        //下面是对datagridview的一些设置
        //欧冠杯——定义DataGridview里列表项，以及对于绑定的数据
        private void Clawer_ENewsDownloaded(EuropeanCup crawler, string zt, string day, string time, string player1, string player2, string link)
        {
            var newpage = new { 
                序号 = resultBindingSource.Count + 1, 
                状态 = zt, 
                日期 = day, 
                开始时间 = time, 
                对阵双方左 = player1, 
                对阵双方右 = player2, 
                详情 = link };//6
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
            var newpage = new { 
                序号 = resultBindingSource.Count + 1, 
                日期 = day, 
                开始时间 = time, 
                对阵双方左 = player1, 
                对阵双方右 = player2,
                轮次 = turn,
                详情 = link
            };//6
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
        //LPL——定义DataGridview里列表项，以及对于绑定的数据
        private void Clawer_ANewsDownloaded(LPL crawler, string day, string time, string player1, string player2, string link)
        {
            var newpage = new
            {
                序号 = resultBindingSource.Count + 1,
                日期 = day,
                开始时间 = time,
                对阵双方左 = player1,
                对阵双方右 = player2,
                详情 = link
            };//6
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
            var newpage = new { 
                序号 = resultBindingSource.Count + 1,
                主题 = name,
                状态 = state,                
                时间 = time, 
                地点 = place, 
                价格 = money, 
                详情 = link };//6
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
            var newpage = new { 
                序号 = resultBindingSource.Count + 1,
                主题 = name,
                状态 = state, 
                时间 = time, 
                地点 = place, 
                价格 = money, 
                详情 = link };//6
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
            var newpage = new { 
                序号 = resultBindingSource.Count + 1,
                主题 = name,
                状态 = state, 
                时间 = time, 
                地点 = place, 
                价格 = money, 
                详情 = link };//6
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
            var newpage = new { 
                序号 = resultBindingSource.Count + 1,
                主题 = name,
                状态 = state, 
                时间 = time, 
                地点 = place, 
                价格 = money, 
                详情 = link };//6
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
            var newpage = new { 
                序号 = resultBindingSource.Count + 1, 
                片名 = name, 
                时间 = time, 
                类型 = type, 
                主演 = actors, 
                评分 = scores, 
                详情 = url };//6
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
            var newpage = new { 
                序号 = resultBindingSource.Count + 1, 
                报告题目 = title,
                报告人 = person,
                报告日期 = Day, 
                开始时间 = Time, 
                报告地点 = address,
                详情 = link,
                报告单位 = danwei
                 };
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
    }
}
