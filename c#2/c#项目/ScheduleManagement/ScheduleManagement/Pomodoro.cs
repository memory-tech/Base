using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScheduleManagement
{
    public partial class Pomodoro:Form
    {
        //番茄时长
        public int TomatoTime { get; set; }
        //番茄间隔
        public int Interval { get; set; }
        Timer WorkTimer = new Timer();//番茄时间定时器
        Timer BreakTimer = new Timer();//休息间隔倒计时
        public Schedule Schedule { get; set; }
        public Affair Affair { get; set; }
        public Pomodoro(Schedule s)
        {
            Schedule = s;
            InitializeComponent();
        }
        public Pomodoro(Affair a)
        {
            Affair = a;
            InitializeComponent();
        }
        //加载界面，初始化番茄时长和番茄间隔
        private void Form_Load(object sender, EventArgs e)
        {
            TomatoTime = 25 * 60;
            Interval = 5 * 60;
            Schedule = null;
            Affair = null;
            label.Text = "番茄钟";
            this.btnEnd.Enabled = false;
            SetTimeInterval();
        }
        //设置定时器的时间间隔
        public void SetTimeInterval()
        {
            WorkTimer.Interval = 1000;
            WorkTimer.Tick += new EventHandler(TimerProcessor);
            BreakTimer.Interval = 1000;
            BreakTimer.Tick += new EventHandler(TimerProcessor2);
        }
        //番茄钟倒计时函数
        void TimerProcessor(Object myObject, EventArgs myEventArgs)
        {
            --TomatoTime;
            int left = TomatoTime / 60;
            int right = TomatoTime % 60;
            string minute;
            string second;
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
            //到达一个番茄时段
            if (TomatoTime == 0)
            {
                TomatoTime = 25 * 60;
                WorkTimer.Stop();
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
                BreakTimer.Start();
                label.Text = "休息中";
                TimeSet.Text = "05:00";
            }
        }
        //倒计时处理
        void TimerProcessor2(Object myObject, EventArgs myEventArgs)
        {
            --Interval;
            int left = Interval / 60;
            int right = Interval % 60;
            string minute;
            string second;
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
            if (Interval == 0)
            {
                Interval = 5 * 60;
                BreakTimer.Stop();
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
                WorkTimer.Start();
                label.Text = "工作中";
                TimeSet.Text = "25:00";
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
        //开始
        private void btnBegin_Click(object sender, EventArgs e)
        {
            if (cmbRemindStyle.SelectedItem == null)
            {
                MessageBox.Show("请选择提醒方式！");
                return;
            }
            WorkTimer.Start();
            btnBegin.Enabled = false;
            cmbRemindStyle.Enabled = false;
            this.btnEnd.Enabled = true;
            label.Text = "工作中";
        }
        //结束
        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.Close();
            if (Schedule!=null){
                Schedule.Main.Show();
            }
            if (Affair!= null)
            {
                Affair.Main.Show();
            }
            
        }
    }
}
