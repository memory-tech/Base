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


namespace ScheduleManagement.clawer
{
    class clawerbasketball
    {
        
        //要爬取的网址
        public string requestUrl = "https://m.hupu.com/soccer/csl/match";
        
        /// 加载URL
        
        public string LoadUrl(string url, Encoding encoding)
        {
            //使用 WebRequest 类
            WebRequest webRequest = WebRequest.Create(url);
            //模仿向浏览器输入了一个网页，再用WebResponse类获得响应
            WebResponse webResponse = (WebResponse)webRequest.GetResponse();
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
          //  using (RISDBContext dbContext = new RISDBContext())
          //  {
                var doc = this.CreateHtmlDocument(html);
                //下面的意思是：通过属性class的值，来定位节点信息
                HtmlNodeCollection htmlNodes = doc.DocumentNode.SelectNodes("//section[@class='match-section match-today']");

                if (htmlNodes.Count == 0)
                    return false;//没取到，说明没赛程安排
                var htmlNodeList = htmlNodes.ToList();

                for (var i = 0; i < htmlNodeList.Count; i++)
                {
                    var htmlNode = htmlNodeList[i];
                    //取页面section中的内容
                    //用temp而不是htmlNode再进行相关的赋值即可
                    var temp = HtmlNode.CreateNode(htmlNode.OuterHtml);
                    var news = new News();
                    //取日期，几号
                    var DayHtmlNode = temp.SelectSingleNode("//div[@class='time-label']/span");
                    news.Day = DayHtmlNode == null ? "" : DayHtmlNode.InnerText;
                    //取详情页面url    href?
                    var UrlHtmlNode = temp.SelectSingleNode("//div[@class='time-label']/href");
                    news.Link = UrlHtmlNode == null ? "" : UrlHtmlNode.InnerText;
                    //具体几点
                    var TimeHtmlNode = temp.SelectSingleNode("//div[@class='match-state']");
                    news.Time = TimeHtmlNode == null ? "" : TimeHtmlNode.InnerText;
                    //球队1
                    var Player1HtmlNode = temp.SelectSingleNode("//div[@class='team-name']/div[0]/h4");
                    news.Player1 = Player1HtmlNode == null ? "" : Player1HtmlNode.InnerText;
                    //球队2
                    var Player2HtmlNode = temp.SelectSingleNode("//div[@class='team-name']/div[1]/h4");
                    news.Player2 = Player2HtmlNode == null ? "" : Player2HtmlNode.InnerText;
                    //场次
                    var TurnHtmlNode = temp.SelectSingleNode("//div[@class='match-played']");
                    news.Turn = TurnHtmlNode == null ? "" : TurnHtmlNode.InnerText;
           
                    //对比赛详情页的查询统计,首场6.21
                    /*
                    if (!string.IsNullOrEmpty(news.Link) && news.Link.Contains("http://"))
                    {
                        var contentHtml = this.LoadUrl(news.Link, Encoding.Default);
                        var contentDoc = this.CreateHtmlDocument(contentHtml);
                        HtmlNode sourceHtmlNode = contentDoc.DocumentNode.SelectSingleNode("//div[@id='cont_1_1_2']/div[@class='left-time']/div[@class='left-t']");
                        news.Source = sourceHtmlNode == null ? "" : sourceHtmlNode.InnerText;
                        HtmlNode contentHtmlNode = contentDoc.DocumentNode.SelectSingleNode("//div[@id='cont_1_1_2']/div[@class='left_zw']");
                        news.Content = contentHtmlNode == null ? "" : contentHtmlNode.InnerHtml;
                        HtmlNode authorHtmlNode = contentDoc.DocumentNode.SelectSingleNode("//div[@id='cont_1_1_2']/div[@class='left_name']/div[@class='left_name']");
                        news.Author = authorHtmlNode == null ? "" : authorHtmlNode.InnerText;
                    }
                    */
                //保存到数据库    dbContext.News.Add(news);
            //    }
                try
                {
                 //保存到数据库   dbContext.SaveChanges();
                }
                catch (Exception ex)
                {

                }

                return true;//继续爬取
            }

            return false;
        }
       

        private void startBtn_Click(object sender, EventArgs e)
        {
            var isTrue = true;
            while (isTrue)
            {
                isTrue = this.Start(requestUrl);
            }
        }

        public bool Start(string url)
        {
            var html = this.LoadUrl(url, Encoding.UTF8);
            return this.JieXiHtml(html);
        }

    }
}
