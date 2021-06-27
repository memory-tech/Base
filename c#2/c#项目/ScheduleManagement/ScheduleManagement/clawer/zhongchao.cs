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
    class zhongchao
    {

        public event Action<zhongchao, string,string, string, string, string, string, string> NewsDownloaded;
        public string loveplayer;
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

            //首个
            HtmlNodeCollection htmlNodes1 = doc.DocumentNode.SelectNodes("//section[@class='match-section match-today']");


            if (htmlNodes1.Count == 0)
                return false;//没取到，说明没赛程安排
            var htmlNodeList1 = htmlNodes1.ToList();

            for (var i = 0; i < htmlNodeList1.Count; i++)
            {
                var htmlNode = htmlNodeList1[i];
                //取页面section中的内容
                //用temp而不是htmlNode再进行相关的赋值即可
                var temp = HtmlNode.CreateNode(htmlNode.OuterHtml);
                var news = new News();
                //取日期，几号
                var DayHtmlNode = temp.SelectSingleNode("//div[@class='time-label']/span");
                string t = DayHtmlNode == null ? "" : DayHtmlNode.InnerText;
                t = t.Replace("&nbsp;", "s");
                news.Day = t.Substring(0, 10);
                news.weekday = t.Substring(11, 3);
                //取详情页面url   
                var UrlHtmlNode = temp.SelectSingleNode("//section[@class='match-section match-today']/div[@class='match-list match-list-notstarted']");
                string str = UrlHtmlNode == null ? "" : Convert.ToString(UrlHtmlNode.InnerHtml);
                string reg = @"<a[^>]*href=([""'])?(?<href>[^'""]+)\1[^>]*>";
                Match item = Regex.Match(str, reg, RegexOptions.IgnoreCase);
                news.Link = item.Groups["href"].Value;
                //具体几点
                var TimeHtmlNode = temp.SelectSingleNode("//div[@class='match-state']");
                news.Time = TimeHtmlNode == null ? "" : TimeHtmlNode.InnerText;

                //球队1
                var Player1HtmlNode = temp.SelectSingleNode("//div[@class='team-name']/div[1]/h4");
                news.Player1 = Player1HtmlNode == null ? "" : Player1HtmlNode.InnerText;
                //球队2
                var Player2HtmlNode = temp.SelectSingleNode("//div[@class='team-name']/div[2]/h4");
                news.Player2 = Player2HtmlNode == null ? "" : Player2HtmlNode.InnerText;
                //场次
                var TurnHtmlNode = temp.SelectSingleNode("//div[@class='match-played']");
                news.Turn = TurnHtmlNode == null ? "" : TurnHtmlNode.InnerText;
                if (loveplayer == "" || news.Player1.Contains(loveplayer) || news.Player2.Contains(loveplayer))
                {
                    NewsDownloaded(this, news.Day, news.weekday, news.Time, news.Player1, news.Player2, news.Turn, news.Link);
                }
                //当天第二队

                //取日期，几号
                DayHtmlNode = temp.SelectSingleNode("//div[@class='time-label']/span");
                t = DayHtmlNode == null ? "" : DayHtmlNode.InnerText;
                t = t.Replace("&nbsp;", "s");
                news.Day = t.Substring(0, 10);
                news.weekday = t.Substring(11, 3);
                //取详情页面url    href?
                UrlHtmlNode = temp.SelectSingleNode("//section[@class='match-section match-today']/div[3]");
                str = UrlHtmlNode == null ? "" : Convert.ToString(UrlHtmlNode.InnerHtml);
                reg = @"<a[^>]*href=([""'])?(?<href>[^'""]+)\1[^>]*>";
                item = Regex.Match(str, reg, RegexOptions.IgnoreCase);
                news.Link = item.Groups["href"].Value;
                //具体几点
                TimeHtmlNode = temp.SelectSingleNode("//section[@class='match-section match-today']/div[3]/a/div[@class='match-col-1']/ div[@class='match-state']");
                news.Time = TimeHtmlNode == null ? "" : TimeHtmlNode.InnerText;
                //球队1
                Player1HtmlNode = temp.SelectSingleNode("//section[@class='match-section match-today']/div[3]/a/div[@class='team-name']/div[1]/h4");
                news.Player1 = Player1HtmlNode == null ? "" : Player1HtmlNode.InnerText;
                //球队2
                Player2HtmlNode = temp.SelectSingleNode("//section[@class='match-section match-today']/div[3]/a/div[@class='team-name']/div[2]/h4");
                news.Player2 = Player2HtmlNode == null ? "" : Player2HtmlNode.InnerText;
                //场次
                TurnHtmlNode = temp.SelectSingleNode("//section[@class='match-section match-today']/div[3]/a/div[@class='match-played']");
                news.Turn = TurnHtmlNode == null ? "" : TurnHtmlNode.InnerText;
                if (loveplayer == "" || news.Player1.Contains(loveplayer) || news.Player2.Contains(loveplayer))
                {
                    NewsDownloaded(this, news.Day, news.weekday, news.Time, news.Player1, news.Player2, news.Turn, news.Link);
                }
            }

            //接下来三天
            //下面的意思是：通过属性class的值，来定位节点信息
            HtmlNodeCollection htmlNodes = doc.DocumentNode.SelectNodes("//section[@class='match-section ']");


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
                string t = DayHtmlNode == null ? "" : DayHtmlNode.InnerText;
                t = t.Replace("&nbsp;", "s");
                news.Day = t.Substring(0, 10);
                news.weekday = t.Substring(11, 3);
                //取详情页面url  
                var UrlHtmlNode = temp.SelectSingleNode("//div[@class='match-list match-list-notstarted']");
                string str = UrlHtmlNode == null ? "" : Convert.ToString(UrlHtmlNode.InnerHtml);
                string reg = @"<a[^>]*href=([""'])?(?<href>[^'""]+)\1[^>]*>";
                Match item = Regex.Match(str, reg, RegexOptions.IgnoreCase);
                news.Link = item.Groups["href"].Value;
                //具体几点
                var TimeHtmlNode = temp.SelectSingleNode("//div[@class='match-state']");
                news.Time = TimeHtmlNode == null ? "" : TimeHtmlNode.InnerText;
                //球队1
                var Player1HtmlNode = temp.SelectSingleNode("//div[@class='team-name']/div[1]/h4");
                news.Player1 = Player1HtmlNode == null ? "" : Player1HtmlNode.InnerText;
                //球队2
                var Player2HtmlNode = temp.SelectSingleNode("//div[@class='team-name']/div[2]/h4");
                news.Player2 = Player2HtmlNode == null ? "" : Player2HtmlNode.InnerText;
                //场次
                var TurnHtmlNode = temp.SelectSingleNode("//div[@class='match-played']");
                news.Turn = TurnHtmlNode == null ? "" : TurnHtmlNode.InnerText;
                if (loveplayer == "" || news.Player1.Contains(loveplayer) || news.Player2.Contains(loveplayer))
                {
                    NewsDownloaded(this, news.Day, news.weekday, news.Time, news.Player1, news.Player2, news.Turn, news.Link);
                }

                //当天第二队

                //取日期，几号
                DayHtmlNode = temp.SelectSingleNode("//div[@class='time-label']/span");
                t = DayHtmlNode == null ? "" : DayHtmlNode.InnerText;
                t = t.Replace("&nbsp;", "s");
                news.Day = t.Substring(0, 10);
                news.weekday = t.Substring(11, 3);
                //取详情页面url    href?
                UrlHtmlNode = temp.SelectSingleNode("//section[@class='match-section ']/div[3]");
                str = UrlHtmlNode == null ? "" : Convert.ToString(UrlHtmlNode.InnerHtml);
                reg = @"<a[^>]*href=([""'])?(?<href>[^'""]+)\1[^>]*>";
                item = Regex.Match(str, reg, RegexOptions.IgnoreCase);
                news.Link = item.Groups["href"].Value;
                //具体几点
                TimeHtmlNode = temp.SelectSingleNode("//section[@class='match-section ']/div[3]/a/div[@class='match-col-1']/ div[@class='match-state']");
                news.Time = TimeHtmlNode == null ? "" : TimeHtmlNode.InnerText;
                //球队1
                Player1HtmlNode = temp.SelectSingleNode("//section[@class='match-section ']/div[3]/a/div[@class='team-name']/div[1]/h4");
                news.Player1 = Player1HtmlNode == null ? "" : Player1HtmlNode.InnerText;
                //球队2
                Player2HtmlNode = temp.SelectSingleNode("//section[@class='match-section ']/div[3]/a/div[@class='team-name']/div[2]/h4");
                news.Player2 = Player2HtmlNode == null ? "" : Player2HtmlNode.InnerText;
                //场次
                TurnHtmlNode = temp.SelectSingleNode("//section[@class='match-section ']/div[3]/a/div[@class='match-played']");
                news.Turn = TurnHtmlNode == null ? "" : TurnHtmlNode.InnerText;
                if (loveplayer == "" || news.Player1.Contains(loveplayer) ||  news.Player2.Contains(loveplayer))
                {
                    NewsDownloaded(this, news.Day, news.weekday, news.Time, news.Player1, news.Player2, news.Turn, news.Link);
                }
            }
            return true;
        }

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
            //     }
            /*
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
       */

        public void Excute()//(object sender, EventArgs e)
        {
           // var isTrue = true;
            this.Start(requestUrl);
            /*
            while (isTrue)
            {
                isTrue = this.Start(requestUrl);
            }
            */
        }

        public bool Start(string url)
        {
            var html = this.LoadUrl(url, Encoding.UTF8);
            return this.JieXiHtml(html);
        }

    }
}
