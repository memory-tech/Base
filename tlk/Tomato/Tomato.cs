using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Tomato
{
   
    public partial class Tomato : Form
    {
        static int tomatoes = 0;
        static int sum = 0;
        static int sumWork = 0;
        static int sumLearn = 0;
        static int sumRead = 0;
        static int sumWrite = 0;
        static int sumRest = 0;
        //任务总时长
        public int TotalTime { get; set; }
        //番茄时钟时长
        public int Interval { get; set; }
        //休息间隔
        public int BreakInterval { get; set; }
        //番茄时长对应秒数
        public int Seconds { get; set; }
        //时间间隔对应秒数
        public int Seconds2 { get; set; }
        //定义定时器
        Timer MyTimer = new Timer();
        Timer BreakTimer = new Timer();
        public Tomato()
        {
            InitializeComponent();
        }

        private void TimeSet_Click(object sender, EventArgs e)
        {
            TimeEdit timeEdit = new TimeEdit(this, TotalTime, Interval, BreakInterval);
            timeEdit.ShowDialog();
            TotalTime *= 60;
            Seconds = 60 * Interval;
            Seconds2 = 60 * BreakInterval;
            TimeSet.Text = Interval + ":00";
            label6.Text = Interval + "分钟工作法";
        }
        //打开番茄钟
        private void btnBegin_Click(object sender, EventArgs e)
        {
            if (cmbTaskType.SelectedItem == null)
            {
                MessageBox.Show("请选择任务类型！");
                return;
            }
            if (cmbRemindStyle.SelectedItem == null)
            {
                MessageBox.Show("请选择提醒方式！");
                return;
            }
            MyTimer.Start();//打开定时器
            //使一些控件不能响应事件
            TimeSet.Enabled = false;
            btnBegin.Enabled = false;
            cmbTaskType.Enabled = false;
            cmbRemindStyle.Enabled = false;
            this.btnEnd.Enabled = true;
        }
        //关掉番茄钟
        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (MyTimer.Enabled)
            {
                MyTimer.Stop();
                int temp = (60 * Interval - Seconds) / 60;
                switch (cmbTaskType.SelectedIndex)
                {
                    case 0:
                        sumWork += temp; break;
                    case 1:
                        sumLearn += temp; break;
                    case 2:
                        sumRead += temp; break;
                    case 3:
                        sumWrite += temp; break;
                    case 4:
                        sumRest += temp; break;
                }
                sum += temp;
                label3.Text = sum + "分钟";
                Seconds = 60 * Interval;
                TimeSet.Text = Interval + ":00";
                TimeSet.Enabled = true;
                btnBegin.Enabled = true;
                cmbTaskType.Enabled = true;
                cmbRemindStyle.Enabled = true;
            }
        }
        //设置定时器的时间间隔
        public void SetTimeInterval()
        {
            MyTimer.Interval = 1000;
            MyTimer.Tick += new EventHandler(TimerProcessor);
            BreakTimer.Interval = 1000;
            BreakTimer.Tick += new EventHandler(TimerProcessor2);
        }
        void TimerProcessor2(Object myObject, EventArgs myEventArgs)
        {
            --Seconds2;
            int left = Seconds2 / 60;
            int right = Seconds2 % 60;
            string minute = "";
            string second = "";
            if (left < 10)
            {
                minute = "0" + left;
            }
            else
            {
                minute = "" + left;
            }
            if (right < 10)
            {
                second = "0" + right;
            }
            else
            {
                second = "" + right;
            }
            TimeSet.Text = minute + ":" + second;
            if (Seconds2 == 0)
            {
                BreakTimer.Stop();
                this.Seconds2 = BreakInterval * 60;
            }
        }
        //定时器到达时间间隔时的处理
        void TimerProcessor(Object myObject, EventArgs myEventArgs)
        {
            --TotalTime;
            --Seconds;
            int left = Seconds / 60;
            int right = Seconds % 60;
            string minute = "";
            string second = "";
            if (left < 10)
            {
                minute = "0" + left;
            }
            else
            {
                minute = ""+left;
            }
            if (right < 10)
            {
                second = "0" + right;
            }
            else
            {
                second = "" + right;
            }
            TimeSet.Text = minute + ":" + second;
            //任务结束
            if (TotalTime == 0)
            {
                MyTimer.Stop();
                switch (cmbRemindStyle.SelectedIndex)
                {
                    case 0:
                        Ring(); break;
                    case 1:
                        Shake(); break;
                    case 2:
                        Ring();
                        Shake();
                        break;
                }
                int temp = Interval * 60 - Seconds;
                int tmp = temp / 60;
                switch (cmbTaskType.SelectedIndex)
                {
                    case 0:
                        MessageBox.Show("工作完成，生活愉快！"); sumWork+=tmp; break;
                    case 1:
                        MessageBox.Show("学习完成，生活愉快！"); sumLearn+= tmp; break;
                    case 2:
                        MessageBox.Show("读书完成，生活愉快！"); sumRead+=tmp; break;
                    case 3:
                        MessageBox.Show("写作完成，生活愉快！"); sumWrite+=tmp; break;
                    case 4:
                        MessageBox.Show("休息好就该工作啦！"); sumRest += tmp; ; break;
                }
                sum += tmp;
                label3.Text = sum + "分钟";
                this.Seconds = Interval * 60;
                this.TotalTime = 15*60;//恢复默认15分钟
                TimeSet.Enabled = true;
                btnBegin.Enabled = true;
                cmbTaskType.Enabled = true;
                cmbRemindStyle.Enabled = true;
            }
            //到达一个番茄时段但是任务未结束
            if (Seconds == 0)
            {
                MyTimer.Stop();
                switch (cmbRemindStyle.SelectedIndex) {
                    case 0:
                        Ring();break;
                    case 1:
                        Shake();break;
                    case 2:
                        Ring();
                        Shake();
                        break;
                }
                switch (cmbTaskType.SelectedIndex) {
                    case 0:
                        sumWork += Interval; break;
                    case 1:
                        sumLearn += Interval; break;
                    case 2: 
                        sumRead += Interval; break;
                    case 3:
                        sumWrite += Interval; break;
                    case 4:
                        sumRest += Interval; break;
                }
                sum += Interval;
                label3.Text = sum + "分钟";
                tomatoes++;
                tomatoAmount.Text = tomatoes + "";
                BreakTimer.Start();
                if (BreakInterval == 5)
                {
                    TimeSet.Text = "05:00";
                }
                else
                {
                    TimeSet.Text = "10:00";
                }
                
            }
        }
        //窗体震动
        private void Shake()
        {
            int leftWidth = this.Left; //指定窗体左边值
            int topWidth = this.Top; //指定窗体上边值 
            for (int i = 0; i < 40; i++)
            {
                if (i % 2 == 0)
                {
                    this.Left = this.Left + 10;
                }
                else 
                {
                    this.Left = this.Left - 10;
                }
                if (i % 2 == 0)
                {
                    this.Top = this.Top + 10;
                }
                else
                {
                    this.Top = this.Top - 10;
                }
                System.Threading.Thread.Sleep(50);//震动频率 
            }
            this.Left = leftWidth;//重设窗体初此左边值 
            this.Top = topWidth; //重设窗体初此上边值 
        }
        //响铃
        private void Ring()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Application.StartupPath + @"/alarm.wav");
            player.Play();
        }
        //窗体加载
        private void Tomato_Load(object sender, EventArgs e)
        {
            this.Interval = 15;
            this.TotalTime = 15;
            this.BreakInterval = 5;
            this.Seconds = 60 * Interval;
            this.btnEnd.Enabled = false;
            label3.Text = sum + "分钟";
            SetTimeInterval();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("我专心做事" + sum + "分钟\n" +
                "专注工作" + sumWork + "分钟\n" +
                "好好学习了" + sumLearn + "分钟\n" +
                "认真阅读了" + sumRead + "分钟书籍\n" +
                "努力完成了" + sumWrite + "分钟写作\n" +
                "而且休息了" + sumRest + "分钟\n" +

                "继续加油哦!\n"
                );
        }
    }
}
