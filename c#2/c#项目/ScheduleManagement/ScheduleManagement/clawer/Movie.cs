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
    class Movie
    {
        public event Action<Movie, string, string, string, string, string, string> MoviesDownloaded;
        //要爬取的网址
        public string requestUrl = "https://maoyan.com/films?sortId=2";

        /// 加载URL

        public string LoadUrl(string url, Encoding encoding)
        {
            //使用 WebRequest 类
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            //避免403被ban
            webRequest.KeepAlive = true;
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*;q=0.8";
           // webRequest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.2; zh-CN; rv:1.9.2.8) Gecko/20100722 Firefox/3.6.8";
            //  webRequest.UserAgent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64; rv: 74.0) Gecko / 20100101 Firefox / 74.0";
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.99 Safari/537.36";
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
            //  using (RISDBContext dbContext = new RISDBContext())
            //  {
            var doc = this.CreateHtmlDocument(html);

           
            HtmlNodeCollection htmlNodesmovie = doc.DocumentNode.SelectNodes("//dd");
           
            if (htmlNodesmovie.Count == 0)
                return false;//没取到电影信息
            var htmlNodeList1 = htmlNodesmovie.ToList();

            for (var i = 0; i < htmlNodeList1.Count; i++)
            {
                var htmlNode = htmlNodeList1[i];
                var temp = HtmlNode.CreateNode(htmlNode.OuterHtml);
                var news = new Ms();

                //取电影名字
                var TitleHtmlNode = temp.SelectSingleNode("//div[@class='channel-detail movie-item-title']/a");
                news.name = TitleHtmlNode == null ? "" : TitleHtmlNode.InnerText;
                //  news.name = Convert.ToString(htmlNodeList1.Count);
                
                  //取详情页面url   
                  var UrlHtmlNode = temp.SelectSingleNode("//div[@class='movie-item film-channel']");
                  string str = UrlHtmlNode == null ? "" : Convert.ToString(UrlHtmlNode.InnerHtml);
                  string reg = @"<a[^>]*href=([""'])?(?<href>[^'""]+)\1[^>]*>";
                  Match item = Regex.Match(str, reg, RegexOptions.IgnoreCase);
                  news.url = "https://maoyan.com"+item.Groups["href"].Value;

                  //类型
                  var TypeHtmlNode = temp.SelectSingleNode("//div[@class='movie-hover-info']/div[2]");
                // var TypeHtmlNodec = temp.SelectSingleNode("//div[@class='movie-hover-info']/div[2]/span");
                // TypeHtmlNode = TypeHtmlNode.RemoveChild(TypeHtmlNodec);
                string x = @"[\u4E00-\u9FFF]+";
                MatchCollection Matchestype = Regex.Matches
                (TypeHtmlNode.InnerText, x, RegexOptions.IgnoreCase);
                StringBuilder itstype = new StringBuilder();
                foreach (Match NextMatch in Matchestype)
                {
                    itstype.Append(NextMatch.Value);
                }
                string thetype = itstype.ToString();
                news.type = TypeHtmlNode == null ? "" : thetype.Substring(2,thetype.Length-2);

                  //主演
                  var ActorsHtmlNode = temp.SelectSingleNode("//div[@class='movie-hover-info']/div[3]");
                MatchCollection Matchesactor = Regex.Matches
                (ActorsHtmlNode.InnerText, x, RegexOptions.IgnoreCase);
                StringBuilder itsactor = new StringBuilder();
                foreach (Match NextMatch in Matchesactor)
                {
                    itsactor.Append(NextMatch.Value);
                }
                string theactor = itsactor.ToString();
                news.actors = ActorsHtmlNode == null ? "" : theactor.Substring(2, theactor.Length - 2);

                  //上映时间
                  var TimeHtmlNode = temp.SelectSingleNode("//div[@class='movie-hover-title movie-hover-brief']");
                string timestr = Regex.Replace(TimeHtmlNode.InnerText, @"[^\d-^\d-^\d]", "");
                news.time = TimeHtmlNode == null ? "" : timestr;

                  //评分
                  var ScoresHtmlNode = temp.SelectSingleNode("//div[@class='channel-detail channel-detail-orange']");
                  news.scores = ScoresHtmlNode == null ? "" : ScoresHtmlNode.InnerText;
                
                MoviesDownloaded(this, news.name, news.time, news.type, news.actors, news.scores, news.url);
            
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
