using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ScheduleManagement.Service;
using System.Runtime.InteropServices;

namespace ScheduleManagement
{
    public partial class Main : Form
    {
        public AddAffair f1; //创建用户控件一变量
        public Affair f2; //创建用户控件二变量
        public Pomodoro f3; //创建用户控件三变量
        public Clawer f4; //创建用户控件四变量
        public Schedule f5; //创建用户控件五变量
        public Achievement f6;//创建用户控件六变量

        //   ScheduleService scheduleservice;
        public String Keyword1 { get; set; }

    //    To_Do_AffairsService to_do_affairservice;
        public String Keyword2 { get; set; }
        public Main()
        { 
        InitializeComponent();
        /*
        scheduleservice = new ScheduleService();
        bdsScheduleEntity.DataSource = scheduleservice.Schedules;
        //cbxCategory.SelectedIndex = 0;
        //txtKeyword1.DataBindings.Add("Text", this, "Keyword1");
        to_do_affairservice = new To_Do_AffairsService();
        bdsTo_Do_AffairEntity.DataSource = to_do_affairservice.To_Do_Affairs;
        //cbxUrgency.SelectedIndex = 0;
        //txtKeyword2.DataBindings.Add("Text", this, "Keyword2");
        */
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_TOPMOST = 8;
                base.CreateParams.Parent = GetDesktopWindow();
                base.CreateParams.ExStyle |= WS_EX_TOPMOST;
                return base.CreateParams;
            }
        }
        AnchorStyles anchors;
        const int OFFSET = 2;
        protected override void WndProc(ref Message m)
        {
            const int WM_MOVING = 534;
            switch (m.Msg)
            {
                case WM_MOVING: // 窗体移动的消息，控制窗体不会移出屏幕外
                    int left = Marshal.ReadInt32(m.LParam, 0);
                    int top = Marshal.ReadInt32(m.LParam, 4);
                    int right = Marshal.ReadInt32(m.LParam, 8);
                    int bottom = Marshal.ReadInt32(m.LParam, 12);
                    left = Math.Min(Math.Max(0, left),
                        Screen.PrimaryScreen.Bounds.Width - Width);
                    top = Math.Min(Math.Max(0, top),
                        Screen.PrimaryScreen.Bounds.Height - Height);
                    right = Math.Min(Math.Max(Width, right),
                        Screen.PrimaryScreen.Bounds.Width);
                    bottom = Math.Min(Math.Max(Height, bottom),
                        Screen.PrimaryScreen.Bounds.Height);
                    Marshal.WriteInt32(m.LParam, 0, left);
                    Marshal.WriteInt32(m.LParam, 4, top);
                    Marshal.WriteInt32(m.LParam, 8, right);
                    Marshal.WriteInt32(m.LParam, 12, bottom);
                    anchors = AnchorStyles.None;
                    if (left <= OFFSET) anchors |= AnchorStyles.Left;
                    if (top <= OFFSET) anchors |= AnchorStyles.Top;
                    if (bottom >= Screen.PrimaryScreen.Bounds.Height - OFFSET)
                        anchors |= AnchorStyles.Bottom;
                    if (right >= Screen.PrimaryScreen.Bounds.Width - OFFSET)
                        anchors |= AnchorStyles.Right;
                    timer1.Enabled = anchors != AnchorStyles.None;
                    break;
            }
            base.WndProc(ref m);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Interval = 200;
            TopMost = true;
            f1 = new AddAffair();    //实例化f1
            f2 = new Affair();    //实例化f2
            f3 = new Pomodoro();    //实例化f3
            f4 = new Clawer();    //实例化f4
            f5 = new Schedule();    //实例化f5
            f6 = new Achievement(); //实例化f6
        }
        
        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(Point Point);
        [DllImport("user32.dll")]
        public static extern IntPtr GetParent(IntPtr hWnd);
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            IntPtr vHandle = WindowFromPoint(Control.MousePosition);
            while (vHandle != IntPtr.Zero && vHandle != Handle)
                vHandle = GetParent(vHandle);
            if (vHandle == Handle) // 如果鼠标停留的窗体是本窗体，还原位置
            {
                if ((anchors & AnchorStyles.Left) == AnchorStyles.Left) Left = 0;
                if ((anchors & AnchorStyles.Top) == AnchorStyles.Top) Top = 0;
                if ((anchors & AnchorStyles.Right) == AnchorStyles.Right)
                    Left = Screen.PrimaryScreen.Bounds.Width - Width;
                if ((anchors & AnchorStyles.Bottom) == AnchorStyles.Bottom)
                    Top = Screen.PrimaryScreen.Bounds.Height - Height;
            }
            else // 隐藏起来
            {
                if ((anchors & AnchorStyles.Left) == AnchorStyles.Left)
                    Left = -Width + OFFSET;
                if ((anchors & AnchorStyles.Top) == AnchorStyles.Top)
                    Top = -Height + OFFSET;
                if ((anchors & AnchorStyles.Right) == AnchorStyles.Right)
                    Left = Screen.PrimaryScreen.Bounds.Width - OFFSET;
                if ((anchors & AnchorStyles.Bottom) == AnchorStyles.Bottom)
                    Top = Screen.PrimaryScreen.Bounds.Height - OFFSET;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            f1.Show();   //将窗体一进行显示
            panel1.Controls.Clear();    //清空原容器上的控件
            panel1.Controls.Add(f1);    //将窗体一加入容器panel1
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f2.Show();   //将窗体二进行显示
            panel1.Controls.Clear();    //清空原容器上的控件
            panel1.Controls.Add(f2);    //将窗体二加入容器panel1
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("欢迎使用个性化日程管理系统");
        }
       

        private void button3_Click(object sender, EventArgs e)
        {
            f3.Show();   //将窗体三进行显示
            panel1.Controls.Clear();    //清空原容器上的控件
            panel1.Controls.Add(f3);    //将窗体三加入容器panel1
        }

        
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label2.Text = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 关于ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("欢迎使用个性化日程管理系统");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            f4.Show();   //将窗体四进行显示
            panel1.Controls.Clear();    //清空原容器上的控件
            panel1.Controls.Add(f4);    //将窗体四加入容器panel1
        }

        private void button5_Click(object sender, EventArgs e)
        {
            f5.Show();   //将窗体五进行显示
            panel1.Controls.Clear();    //清空原容器上的控件
            panel1.Controls.Add(f5);    //将窗体五加入容器panel1
        }

        private void button6_Click(object sender, EventArgs e)
        {
            f6.Show();   //将窗体六进行显示
            panel1.Controls.Clear();//清空原容器上的控件
            panel1.Controls.Add(f6);//将窗体六加入容器panel
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bdsTo_Do_AffairEntity_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void 返回ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}