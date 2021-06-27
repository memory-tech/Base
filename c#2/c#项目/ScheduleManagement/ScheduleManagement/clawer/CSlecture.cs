using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ScheduleManagement.clawer
{
    class CSlecture
    {
        public event Action<CSlecture, string, string, string, string, string, string, string> LNewsDownloaded;
        //要爬取的网址
        public string requestUrl = "http://cs.whu.edu.cn/news_list.aspx?category_id=53";

        /// 加载URL

        public string LoadUrl(string url, Encoding encoding)
        {
            //使用 WebRequest 类
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            //避免403被ban
            webRequest.KeepAlive = true;
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*;q=0.8";
            webRequest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.2; zh-CN; rv:1.9.2.8) Gecko/20100722 Firefox/3.6.8";
            webRequest.UserAgent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64; rv: 74.0) Gecko / 20100101 Firefox / 74.0";
            webRequest.CookieContainer = new CookieContainer();


            //模仿向浏览器输入了一个网页，再用WebResponse类获得响应
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            //响应有了,定义一个流来保存获得的内容
            Stream responseStream = webResponse.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, encoding);

            string html = streamReader.ReadToEnd();

            return html;
        }

        public HtmlAgilityPack.HtmlDocument CreateHtmlDocument(string html)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            return doc;
        }
        public bool JieXiHtml(string html)
        {

            var doc = this.CreateHtmlDocument(html);

            HtmlNodeCollection htmlNodes1 = doc.DocumentNode.SelectNodes("//div[@class='right_list']/ul/li");


            if (htmlNodes1.Count == 0)
                return false;
            var htmlNodeList1 = htmlNodes1.ToList();

            for (var i = 0; i < 4; i++)
            {
                var htmlNode = htmlNodeList1[i];
                var temp = HtmlNode.CreateNode(htmlNode.OuterHtml);
                var news = new lecture();

                //取详情页面url   
                var UrlHtmlNode = temp.SelectSingleNode("//p[@class='p1']");
                string str = UrlHtmlNode == null ? "" : Convert.ToString(UrlHtmlNode.InnerHtml);

                Regex reg = new Regex(@"(?is)<a[^>]*?href=(['""\s]?)(?<href>[^'""\s]*)\1[^>]*?>");
                MatchCollection match = reg.Matches(str);
                int p = 0;
                foreach (Match m in match)
                {
                    if (p == 1)
                    {
                        news.link = "http://cs.whu.edu.cn"+m.Groups["href"].Value;
                    }
                    p = p + 1;
                }

         //       string reg = @"<a[^>]*href=([""'])?(?<href>[^'""]+)\1[^>]*>";
         //       Match item = Regex.Match(str, reg, RegexOptions.IgnoreCase);
         //       news.link = item.Groups["href"].Value;

                //取简介，然后处理
                var AllHtmlNode = temp.SelectSingleNode("//p[@class='p2']");
                string t = AllHtmlNode == null ? "" : AllHtmlNode.InnerText;
                /*
                报告题目：小样本时序数据预测在华为供应链和智能存储领域的应用报告时间：6月10日（周四）上午10: 00报告地点：腾讯会议 （会议号：193 159 617）报告人：史启权 报告人单位： 华为诺亚方舟实验室（香港）报告人简介： 史启权博士，华为诺亚方舟实验室（香港）研究员。20…
                            */
                if (!t.Contains("报告题目1："))
                {
                    int numtitle = t.IndexOf("报告题目：");
                    int numday = t.IndexOf("报告时间：");
                    int numtime = t.IndexOf("午");
                    int numaddress = t.IndexOf("报告地点：");
                    int numperson = t.IndexOf("报告人：");
                    int numdanwei = t.IndexOf("报告人单位：");
                    int numjianjie = t.IndexOf("报告人简介：");

                    news.title = t.Substring(numtitle + 5, numday - numtitle - 5);
                    news.Day = t.Substring(numday + 5, numtime - numday - 10);
                    news.Time = t.Substring(numtime + 1, numaddress - numtime - 1);
                    if (!news.Day.Contains("年"))
                    {
                        news.Day = "2021年" + news.Day;
                    }
                    news.address = t.Substring(numaddress + 5, numperson - numaddress - 5);
                    news.person = t.Substring(numperson + 4, numdanwei - numperson - 4);
                    news.danwei = t.Substring(numdanwei + 6, numjianjie - numdanwei - 6);
                    while(news.danwei.Contains(" "))
                    {
                        news.danwei = news.danwei.Substring(1, numjianjie - numdanwei - 7);
                    }
                    LNewsDownloaded(this, news.title, news.Day, news.Time, news.address, news.person, news.danwei, news.link);
                }
                else
                {
                    int numtitle = t.IndexOf("报告题目1：");
                    int numday = t.IndexOf("报告时间：");
                    int numtime = t.IndexOf("午");
                    int numaddress = t.IndexOf("报告地点：");
                    int numperson = t.IndexOf("报告人：");
                    int numdanwei = t.IndexOf("报告人单位：");
                    int numjianjie = t.IndexOf("报告人简介：");

                    news.title = "Num1："+t.Substring(numtitle + 6, numday - numtitle - 6);
                    news.Day = t.Substring(numday + 5, numtime - numday - 10);
                    news.Time = t.Substring(numtime + 1, numaddress - numtime - 1);
                    news.address = t.Substring(numaddress + 5, numperson - numaddress - 5);
                    news.person = t.Substring(numperson + 4, numdanwei - numperson - 4);
                    news.danwei = t.Substring(numdanwei + 6, numjianjie - numdanwei - 6);

                    LNewsDownloaded(this, news.title, news.Day, news.Time, news.address, news.person, news.danwei, news.link);
                }
            }
            return true;
        }



        public void Excute()
        {
            this.Start(requestUrl);
        }

        public bool Start(string url)
        {
            var html = this.LoadUrl(url, Encoding.UTF8);
            return this.JieXiHtml(html);
        }

    }
}
