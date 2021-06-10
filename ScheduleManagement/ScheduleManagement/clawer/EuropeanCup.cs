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
    class EuropeanCup
    {

        public event Action<EuropeanCup, string, string, string, string, string, string> ENewsDownloaded;
        public string loveplayer;
        //要爬取的网址
        public string requestUrl = "https://www.24zbw.com/live/zuqiu/ouzhoubei/";

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

            HtmlNodeCollection htmlNodes1 = doc.DocumentNode.SelectNodes("//div[@class='schedule_details group_list']/ul[1]/li");


            if (htmlNodes1.Count == 0)
                return false;
            var htmlNodeList1 = htmlNodes1.ToList();

            for (var i = 0; i < htmlNodeList1.Count; i++)
            {
                var htmlNode = htmlNodeList1[i];
                var temp = HtmlNode.CreateNode(htmlNode.OuterHtml);
                var news = new EC();
                //取状态，是否开始了
                var ZtHtmlNode = temp.SelectSingleNode("//span[@class='wks']");
                news.zt = ZtHtmlNode == null ? "" : ZtHtmlNode.InnerText;
                //取时间，几号，几点
                var DayHtmlNode = temp.SelectSingleNode("//time[@class='time']");
                string t = DayHtmlNode == null ? "" : DayHtmlNode.InnerText;
                news.Day = t.Substring(0, 5);
                news.Time = t.Substring(6, 5);               

                //球队1
                var Player1HtmlNode = temp.SelectSingleNode("//div[@class='score left_text']/span/a");
                news.Player1 = Player1HtmlNode == null ? "" : Player1HtmlNode.InnerText;
                //球队2
                var Player2HtmlNode = temp.SelectSingleNode("//div[@class='score right_text']/span/a");
                news.Player2 = Player2HtmlNode == null ? "" : Player2HtmlNode.InnerText;
                //取详情页面url   
                var UrlHtmlNode = temp.SelectSingleNode("//div[@class='want-left']");
                string str = UrlHtmlNode == null ? "" : Convert.ToString(UrlHtmlNode.InnerHtml);
                string reg = @"<a[^>]*href=([""'])?(?<href>[^'""]+)\1[^>]*>";
                Match item = Regex.Match(str, reg, RegexOptions.IgnoreCase);
                news.Link = item.Groups["href"].Value;
                if (loveplayer == "" || news.Player1.Contains(loveplayer) || news.Player2.Contains(loveplayer))
                {
                    ENewsDownloaded(this, news.zt, news.Day, news.Time, news.Player1, news.Player2, news.Link);
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
