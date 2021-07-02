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
    class LPL//LPL
    {
        //定义委托，实时显示爬取到的数据
        public event Action<LPL, string, string, string, string, string> ANewsDownloaded;
        //要爬取的网址
        public string requestUrl = "https://tiyu.baidu.com/match/LPL/tab/%E8%B5%9B%E7%A8%8B/date_time/2021-06-30/from/baidu_aladdin";

        /// 加载URL
        public string LoadUrl(string url, Encoding encoding)
        {
            //使用 WebRequest 类
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            //设置代理，避免403被ban
            webRequest.KeepAlive = true;
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*;q=0.8";
            //  webRequest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.2; zh-CN; rv:1.9.2.8) Gecko/20100722 Firefox/3.6.8";
            //  webRequest.UserAgent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64; rv: 74.0) Gecko / 20100101 Firefox / 74.0";
            webRequest.CookieContainer = new CookieContainer();


            //模仿向浏览器输入了一个网页，再用WebResponse类获得响应
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            //响应有了,定义一个流来保存获得的内容
            Stream responseStream = webResponse.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, encoding);

            string html = streamReader.ReadToEnd();

            return html;
        }
        //获取document
        public HtmlAgilityPack.HtmlDocument CreateHtmlDocument(string html)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            return doc;
        }
        //对document解析，得到需要的各种信息
        public bool JieXiHtml(string html)
        {

            var doc = this.CreateHtmlDocument(html);
            //筛选出每一条
            HtmlNodeCollection htmlNodes1 = doc.DocumentNode.SelectNodes("//div[@class='wa-match-schedule-list-wrapper']");


            if (htmlNodes1.Count == 0)
                return false;
            var htmlNodeList1 = htmlNodes1.ToList();

            //对每一条进行遍历
            for (var i = 0; i < htmlNodeList1.Count; i++)
            {
                var htmlNode = htmlNodeList1[i];
                var temppp = HtmlNode.CreateNode(htmlNode.OuterHtml);
                var news = new news();//EC类定义每一条比赛所需要的属性

                //取时间，几号
                var DayHtmlNode = temppp.SelectSingleNode("//div[@class='date']");
                string timestr = Regex.Replace(DayHtmlNode.InnerText, @"[^\d-^\d]", "");
                string t = DayHtmlNode == null ? "" : "2021-" + timestr;

                //下面两队
                var temp = temppp.SelectSingleNode("//div[@class='wa-match-schedule-list-wrapper']/div[2]/div[1]");
                //取时间，几点
                var TimeHtmlNode = temp.SelectSingleNode("//div[@class='font-14 c-gap-bottom-small']");
                news.Time = TimeHtmlNode == null ? "" : TimeHtmlNode.InnerText;
                news.Day = t;

                //战队1
                var Player1HtmlNode = temp.SelectSingleNode("//span[@class='inline-block team-name team-name-360 team-name-320 c-line-clamp1']");
                news.Player1 = Player1HtmlNode == null ? "" : Player1HtmlNode.InnerText;

                //战队2
                var Player2HtmlNode = temp.SelectSingleNode("//span[@class='inline-block team-name team-name-360 team-name-320']");
                news.Player2 = Player2HtmlNode == null ? "" : Player2HtmlNode.InnerText;

                news.Link = "https://www.huya.com/lpl";

                ANewsDownloaded(this, news.Day, news.Time, news.Player1, news.Player2, news.Link);


                //取时间，几点
                TimeHtmlNode = temp.SelectSingleNode("//div[@class='sfc-contacts-list']/div[2]/a/div[@class='vs-info']/div[@class='vs-info-date']/div[@class='vs-info-date-content']/div[@class='font-14 c-gap-bottom-small']");
                news.Time = TimeHtmlNode == null ? "" : TimeHtmlNode.InnerText;//.InnerText;
                news.Day = t;

                //战队1
                Player1HtmlNode = temp.SelectSingleNode("//div[@class='sfc-contacts-list']/div[2]/a/div[@class='vs-info']/div[@class='vs-info-team-info']/div[@class='font-0']/div[@class='team-row']/div[@class='inline-block font-14 c-line-clamp1']/span[@class='inline-block team-name team-name-360 team-name-320 c-line-clamp1']");
                news.Player1 = Player1HtmlNode == null ? "" : Player1HtmlNode.InnerText;

                //战队2
                Player2HtmlNode = temp.SelectSingleNode("//div[@class='sfc-contacts-list']/div[2]/a/div[@class='vs-info']/div[@class='vs-info-team-info']/div[@class='font-0']/div[@class='c-gap-top-small team-row']/div[@class='inline-block font-14 c-line-clamp1']/span[@class='inline-block team-name team-name-360 team-name-320']");
                news.Player2 = Player2HtmlNode == null ? "" : Player2HtmlNode.InnerText;

                news.Link = "https://www.huya.com/lpl";

                ANewsDownloaded(this, news.Day, news.Time, news.Player1, news.Player2, news.Link);             

                //取时间，几点
                TimeHtmlNode = temp.SelectSingleNode("//div[@class='sfc-contacts-list']/div[3]/a/div[@class='vs-info']/div[@class='vs-info-date']/div[@class='vs-info-date-content']/div[@class='font-14 c-gap-bottom-small']");
                if (TimeHtmlNode != null)
                {
                    news.Time = TimeHtmlNode == null ? "" : TimeHtmlNode.InnerText;//.InnerText;
                    news.Day = t;

                    //战队1
                    Player1HtmlNode = temp.SelectSingleNode("//div[@class='sfc-contacts-list']/div[3]/a/div[@class='vs-info']/div[@class='vs-info-team-info']/div[@class='font-0']/div[@class='team-row']/div[@class='inline-block font-14 c-line-clamp1']/span[@class='inline-block team-name team-name-360 team-name-320 c-line-clamp1']");
                    news.Player1 = Player1HtmlNode == null ? "" : Player1HtmlNode.InnerText;

                    //战队2
                    Player2HtmlNode = temp.SelectSingleNode("//div[@class='sfc-contacts-list']/div[3]/a/div[@class='vs-info']/div[@class='vs-info-team-info']/div[@class='font-0']/div[@class='c-gap-top-small team-row']/div[@class='inline-block font-14 c-line-clamp1']/span[@class='inline-block team-name team-name-360 team-name-320']");
                    news.Player2 = Player2HtmlNode == null ? "" : Player2HtmlNode.InnerText;

                    news.Link = "https://www.huya.com/lpl";

                    ANewsDownloaded(this, news.Day, news.Time, news.Player1, news.Player2, news.Link);
                }
            }
            return true;
        }


        //爬虫入口
        public void Excute()
        {
            this.Start(requestUrl);
        }
        //开始爬取
        public bool Start(string url)
        {
            var html = this.LoadUrl(url, Encoding.UTF8);//对要爬取到网站转格式
            return this.JieXiHtml(html);
        }

    }
}
