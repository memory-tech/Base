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
using System.Windows.Forms.DataVisualization.Charting;
using ScheduleManagement.Service;

namespace ScheduleManagement
{
    public partial class Achievement : UserControl
    {
        public Achievement()
        {
            InitializeComponent();
            OthersServiceDetails osd = new OthersServiceDetails();
            DataSet ds = osd.GetAchievement_unitList();
            this.comboBox1.SelectedIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["Achievement_unit"]);
            this.query();
        }

        private void Achievement_Load(object sender, EventArgs e)
        {
            
        }
        OthersServiceDetails osd = new OthersServiceDetails();
        private void queryBtn_Click(object sender, EventArgs e)
        {
            this.query();
            Entity.Others others = new Entity.Others();
            others.Achievement_unit = comboBox1.SelectedIndex;
            osd.UpdateAchievement_unit(others);
        }
        private void query()
        {
            //pie图
            AffairService service = new AffairService();
            List<string> xData = new List<string>() { "完成", "未完成" };
            List<int> yData = new List<int>() { 1, 2 };
            yData[0] = service.GetRecordCount("完成");
            yData[1] = service.GetRecordCount("未完成");
            chart1.Series[0].XValueType = ChartValueType.String;//设置字符串格式
            chart1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            chart1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线

            //柱状图
            TomatoService tomatoService = new TomatoService();
            List<string> xDatas = new List<string>();
            List<int> yDatas = new List<int>();
            chart2.Series[0].XValueType = ChartValueType.String;
            switch (comboBox1.SelectedIndex) {
                case 0:
                    //pie图
                    yData[0] = service.GetRecordCount("完成",0);
                    yData[1] = service.GetRecordCount("未完成",0);
                    //柱状图
                    xDatas.Add(DateTime.Now.Month.ToString());
                    yDatas.Add(tomatoService.GetRecordCount(DateTime.Now.Month.ToString()));
                    break;

                case 1:
                    //pie图
                    yData[0] = service.GetRecordCount("完成", 1);
                    yData[1] = service.GetRecordCount("未完成", 1);
                    //柱状图
                    int month = DateTime.Now.Month;
                    int jidu = (month - 1) / 3;
                    for(int k = 0; k < 3; k++)
                    {
                        int temp = jidu * 3 + k + 1;
                        xDatas.Add(temp.ToString());
                        yDatas.Add(tomatoService.GetRecordCount(temp.ToString()));
                    }
                    break;
                case 2:
                    //pie图
                    yData[0] = service.GetRecordCount("完成", 2);
                    yData[1] = service.GetRecordCount("未完成", 2);
                    //柱状图
                    for (int k = 0; k < 12; k++)
                    {
                        int temp = k + 1;
                        xDatas.Add(temp.ToString());
                        yDatas.Add(tomatoService.GetRecordCount(temp.ToString()));
                    }
                    break;
                default:
                    yData[0] = service.GetRecordCount("完成", 2);
                    yData[1] = service.GetRecordCount("未完成", 2);
                    break;
            }
            chart1.Series[0].Points.DataBindXY(xData, yData);
            chart2.Series[0].Points.DataBindXY(xDatas, yDatas);
            
        }
    }
}
