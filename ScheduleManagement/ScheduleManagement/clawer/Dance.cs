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
    class Dance
    {
        public event Action<Dance, string, string, string, string, string, string> DanceDownloaded;
        //要爬取的网址
        public string requestUrl = "https://www.moretickets.com/search/%E6%AD%A6%E6%B1%89%20%E9%9F%B3%E4%B9%90%E4%BC%9A/dance";

        /// 加载URL

        public string LoadUrl(string url, Encoding encoding)
        {
            //使用 WebRequest 类
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            //设置代理，避免403被ban
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
        //获取需要的信息
        public bool JieXiHtml(string html)
        {           
            var doc = this.CreateHtmlDocument(html);

            HtmlNodeCollection htmlNodesmovie = doc.DocumentNode.SelectNodes("//a[@class='show-items sa_entrance']");

            if (htmlNodesmovie.Count == 0)
                return false;//没取到舞蹈演出信息
            var htmlNodeList1 = htmlNodesmovie.ToList();

            for (var i = 0; i < htmlNodeList1.Count; i++)
            {
                var htmlNode = htmlNodeList1[i];
                var temp = HtmlNode.CreateNode(htmlNode.OuterHtml);
                var news = new news();

                //取舞蹈演出名字
                var TitleHtmlNode = temp.SelectSingleNode("//div[@class='show-name']");
                news.name = TitleHtmlNode == null ? "" : TitleHtmlNode.InnerText;

                //取详情页面url   
                var UrlHtmlNode = temp;
                string str = UrlHtmlNode == null ? "" : Convert.ToString(UrlHtmlNode.OuterHtml);

                string reg = @"<a[^>]*href=([""'])?(?<href>[^'""]+)\1[^>]*>";
                Match item = Regex.Match(str, reg, RegexOptions.IgnoreCase);
                //去掉//中的一个，保证拼接出正确的url
                string s = item.Groups["href"].Value;
                s = s.Substring(1, s.Length-1);
                news.Link = "https://www.moretickets.com/" + s;

                //演出时间
                var TimeHtmlNode = temp.SelectSingleNode("//div[@class='row-wrapper bottom-align']/div[@class='show-time']");
                news.Time = TimeHtmlNode == null ? "" : TimeHtmlNode.InnerText;

                //演出地点
                var PlaceHtmlNode = temp.SelectSingleNode("//div[@class='row-wrapper bottom-align']/div[@class='show-addr']");
                news.place = PlaceHtmlNode == null ? "" : PlaceHtmlNode.InnerText;

                //状态
                var ZtHtmlNode = temp.SelectSingleNode("//span[@class='tag selling']");
                news.state = ZtHtmlNode == null ? "" : ZtHtmlNode.InnerText;

                //价格
                var MoneyHtmlNode = temp.SelectSingleNode("//div[@class='row-wrapper bottom-align']/div[@class='show-price']");
                news.money = MoneyHtmlNode == null ? "" : MoneyHtmlNode.InnerText;
                //委托的调用
                DanceDownloaded(this, news.state, news.name, news.Time, news.place, news.money, news.Link);
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
