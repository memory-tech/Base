using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Media;
using ScheduleManagement.Service;

namespace ScheduleManagement
{
    public partial class AddAffair : UserControl
    {
        private SoundPlayer AlarmBell;
        public AddAffair()
        {
            InitializeComponent(); 
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {
            timer2.Interval = 900;
            timer2.Enabled = true;
            ToolTip testTip = new ToolTip();
            testTip.IsBalloon = true;
            testTip.SetToolTip(TestButton, "测试选择的音乐是否可用");           
            OthersServiceDetails osd = new OthersServiceDetails();
            DataSet ds = osd.GetMusic_pathList();
            string music_path = ds.Tables[0].Rows[0]["Music_path"].ToString();
            if(music_path == "")  
            {
                string filename = "alarm.wav";
                this.PathBox.Text = Path.GetFullPath(filename);
            }
            else { this.PathBox.Text = music_path; }
        }
        OthersServiceDetails osd = new OthersServiceDetails();
        private void SetButton_Click(object sender, EventArgs e)
        {
            Entity.Others others = new Entity.Others();
            others.Music_path = this.PathBox.Text;
            osd.UpdateMusic(others);
        }
        private void TestAlarmBell()
        {
            if (TestButton.Text == "测试")
            {
                AlarmBell = new SoundPlayer();
                AlarmBell.SoundLocation = PathBox.Text.Trim();
                try
                {
                    AlarmBell.PlayLooping();
                    TestButton.Text = "停止";
                    SelectButton.Enabled = false;
                }
                catch (Exception)
                {
                    SystemSounds.Hand.Play();
                    MessageBox.Show("无效闹钟铃声！", "警告");
                    AlarmBell.Dispose();
                    TestButton.Text = "测试";
                    SelectButton.Enabled = true;
                }
            }
            else
            {
                try
                {
                    AlarmBell.Stop();
                    AlarmBell.Dispose();
                }
                catch (Exception)
                {
                    SystemSounds.Hand.Play();
                    MessageBox.Show("未知错误！", "提示");
                }
                finally
                {
                    TestButton.Text = "测试";
                    SelectButton.Enabled = true;
                }
            }
        }
        private void SelectButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = PathBox.Text;//默认打开目录
            ofd.Filter = "铃声文件|*.wav";  //显示的文件类型
            ofd.RestoreDirectory = true;  //对话框记忆之前打开的目录
            ofd.FilterIndex = 1;  //文件类型的显示顺序
            if (ofd.ShowDialog() == DialogResult.OK)  //选中文件
            {
                string BellPath = ofd.FileName;
                PathBox.Text = BellPath;
            }
        }
        private void PlayAlarmBell()
        {
            AlarmBell = new SoundPlayer();
            AlarmBell.SoundLocation = PathBox.Text.Trim();
                AlarmBell.PlayLooping();
                DialogResult res = MessageBox.Show("时间到了",
                "提示");
                if (res == DialogResult.OK)
                {
                    AlarmBell.Stop();
                    AlarmBell.Dispose();
                }
        }
        private void TestButton_Click(object sender, EventArgs e)
        {
            TestAlarmBell();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            ReminderService rs = new ReminderService();
            DataSet ds2 = rs.GetOrderedList("State1 like '未完成' ");
            DateTime AlarmTime = DateTime.Parse(ds2.Tables[0].Rows[0]["ClockTime1"].ToString());
            this.textBox_test.Text = ds2.Tables[0].Rows[0]["ClockTime1"].ToString();
            int Year1 = AlarmTime.Year;
            int Month1 = AlarmTime.Month;
            int Day1 = AlarmTime.Day;
            int Hour1 = AlarmTime.Hour;
            int Minute1 = AlarmTime.Minute;
            int Second1 = AlarmTime.Second;
            if (DateTime.Now.Year == Year1 && DateTime.Now.Month == Month1  && DateTime.Now.Day == Day1&&DateTime.Now.Hour == Hour1  && DateTime.Now.Minute == Minute1 && DateTime.Now.Second == Second1 )
            {
                PlayAlarmBell();
            }
        }
    }
    }
