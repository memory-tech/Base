using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScheduleManagement.Service;

namespace ScheduleManagement
{
    public partial class Achievement : UserControl
    {
        public Achievement()
        {
            InitializeComponent();
        }

        private void Achievement_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*List<int> mylist = new List<int>();
            mylist.Add(200);
            mylist.Add(100);
            mylist.Add(300);
            mylist.Add(350);

            int sum = 0;
            for (int i = 0; i < mylist.Count; i++)
            {
                sum += mylist[i];

            }
            float pangle = 360.0F / sum;
            Bitmap bmp = new Bitmap(500, 450);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawRectangle(Pens.Blue, 0, 0, 449, 449);
            Font f16 = new Font("黑体", 16);
            g.DrawString("番茄时长统计表", f16, Brushes.Black, 225 - g.MeasureString("番茄时长统计表", f16).Width / 2, 2);

            Brush[] mybrush = new Brush[] { Brushes.Aqua, Brushes.AntiqueWhite, Brushes.AliceBlue, Brushes.Chocolate };
            Rectangle r = new Rectangle(25, 25, 400, 400);
            float angle = 0;
            float sangle = 0;
            for (int i = 0; i < mylist.Count; i++)
            {
                angle = pangle * mylist[i];
                g.DrawPie(Pens.Brown, r, sangle, angle);
                g.FillPie(mybrush[i], r, sangle, angle);
                sangle = sangle + angle;

            }
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            this.Width = 500;
            this.Height = 500;
            pictureBox1.Width = 455;
            pictureBox1.Height = 455;
            pictureBox1.Image = Image.FromStream(ms);
            ms.Close();*/
            /*TomatoService service = new TomatoService();
            DataSet ds = service.GetAllList();

            float Total = 0;
            Total = Convert.ToSingle(ds.Tables[0].Rows[][1]);
            //设置字体，fonttitle为主标题的字体
            Font fontlegend = new Font("verdana", 9);
            Font fonttitle = new Font("verdana", 10, FontStyle.Bold);
            //背景宽
            int width = 350;
            int bufferspace = 15;
            int legendheight = fontlegend.Height * 10 + bufferspace; //高度
            int titleheight = fonttitle.Height + bufferspace;
            int height = width + legendheight + titleheight + bufferspace;//白色背景高
            int pieheight = width;
            Rectangle pierect = new Rectangle(0, titleheight, width, pieheight);

            //加上各种随机色
            ArrayList colors = new ArrayList();
            Random rnd = new Random();
            for (int i = 0; i < 2; i++)
                colors.Add(new SolidBrush(Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255))));

            //创建一个bitmap实例
            Bitmap objbitmap = new Bitmap(width, height);
            Graphics objgraphics = Graphics.FromImage(objbitmap);
            //画一个白色背景
            objgraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, width, height);

            //画一个亮黄色背景
            objgraphics.FillRectangle(new SolidBrush(Color.Beige), pierect);

            //以下为画饼图(有几行row画几个)
            float currentdegree = 0.0f;
            //画通过人数
            objgraphics.FillPie((SolidBrush)colors[1], pierect, currentdegree,
            Convert.ToSingle(ds.Tables[0].Rows[0][this.count[1]]) / Total * 360);
            currentdegree += Convert.ToSingle(ds.Tables[0].Rows[0][this.count[1]]) / Total * 360;

            //未通过人数饼状图
            objgraphics.FillPie((SolidBrush)colors[0], pierect, currentdegree,
            (Convert.ToSingle(ds.Tables[0].Rows[0][this.count[0]]) - (Convert.ToSingle(ds.Tables[0].Rows[0][this.count[1]]))) / Total * 360);
            currentdegree += ((Convert.ToSingle(ds.Tables[0].Rows[0][this.count[0]])) -
            (Convert.ToSingle(ds.Tables[0].Rows[0][this.count[1]]))) / Total * 360;*/
        }
    }
}
