using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dailyrecord
{
    public partial class FormAchievementList : Form
    {
        public FormAchievementList()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //重新设置日期时间控件的文本
            dateTimePicker1.ResetText();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        //事件统计结果柱状图
        public void createImage1(int AccNum, int UnaccNum)
        {
        }

        //番茄钟统计饼状图
        public void createImage(int AccNum, int UnaccNum)
        {
        }
    }
}
