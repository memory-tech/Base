using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace clawNBA
{
    class claw
    {
            public event Action<Crawler> CrawlerStopped;
            public event Action<Crawler, int, string, string> PageDownloaded;
            public ConcurrentDictionary<string, bool> AlreadyDownload = new ConcurrentDictionary<string, bool>();
            private ConcurrentQueue<string> WaitforDownload = new ConcurrentQueue<string>();
            private readonly string urlDetectRegex = @"(href|HREF)[]*=[]*[""'](?<url>[^""'#>]+)[""']";
            public static readonly string urlParseRegex = @"^(?<site>https?://(?<host>[\w.-]+)(:\d+)?($|/))(\w+/)*(?<file>[^#?]*)";
            public string HostFilter { get; set; }
            public string FileFilter { get; set; }
            public string StartURL { get; set; }
            public int MaxPage { get; set; }
            public Encoding HtmlEncoding { get; set; }
            public Dictionary<string, bool> DownloadedPages { get; }
            public int Downloadnumber { get; set; }
            public Crawler()
            {
                HtmlEncoding = Encoding.UTF8;
            }

            public void Excute()
            {
                AlreadyDownload.Clear();
                WaitforDownload = new ConcurrentQueue<string>();
                Downloadnumber = 0;
                WaitforDownload.Enqueue(StartURL);
                List<Task> tasks = new List<Task>();
                int complatedCount = 0;//已完成的任务数
                PageDownloaded += (crawler, index, url, info) => { complatedCount++; };
                while (Downloadnumber < MaxPage && tasks.Count < MaxPage)
                {
                    if (!WaitforDownload.TryDequeue(out string url))
                    {
                        if (complatedCount < tasks.Count)
                        {
                            continue;
                        }
                        else
                        {
                            break;//所有任务都完成，队列无url
                        }
                    }

                    int index = tasks.Count; //给每个并发的task编号
                    Task task = Task.Run(() => DownloadAndParse(url, index));//建立每一个url对应的task并加入task池
                    tasks.Add(task);
                }

                Task.WaitAll(tasks.ToArray()); //等待剩余任务全部执行完毕
                CrawlerStopped(this);
            }

            //url: 待处理的网址，index：任务序号
            private void DownloadAndParse(string url, int index)
            {
                try
                {
                    string html = DownLoad(url, index);
                    AlreadyDownload[url] = true;
                    Parse(html, url);//解析,并加入新的链接
                    PageDownloaded(this, index, url, "success");
                }
                catch (Exception ex)
                {
                    PageDownloaded(this, index, url, "Error:" + ex.Message);
                }
            }
            //url: 待处理的网址，index：任务序号
            public string DownLoad(string url, int index)
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = HtmlEncoding;
                string html = webClient.DownloadString(url);
                string fileName = "number." + AlreadyDownload.Count.ToString();
                File.WriteAllText(fileName, html, HtmlEncoding);
                return html;
            }

            private void Parse(string html, string startUrl)
            {
                var matches = new Regex(urlDetectRegex).Matches(html);
                foreach (Match match in matches)
                {
                    string linkUrl = match.Groups["url"].Value;
                    if (linkUrl == null || linkUrl == "" || linkUrl.StartsWith("javascript:")) continue;
                    linkUrl = ToAbsoluteUrl(linkUrl, startUrl);//转绝对路径
                    Match linkUrlMatch = Regex.Match(linkUrl, urlParseRegex);
                    string host = linkUrlMatch.Groups["host"].Value;
                    string file = linkUrlMatch.Groups["file"].Value;
                    if (file == "") file = "index.html";
                    if (Regex.IsMatch(host, HostFilter) && Regex.IsMatch(file, FileFilter)
                      && !AlreadyDownload.ContainsKey(linkUrl))
                    {
                        WaitforDownload.Enqueue(linkUrl);
                        AlreadyDownload.TryAdd(linkUrl, false);
                    }

                }
            }


            //将相对路径转为绝对路径
            private string ToAbsoluteUrl(string url, string pageUrl)
            {
                if (url.Contains("://"))
                {
                    return url;
                }
                if (url.StartsWith("/"))
                {
                    Match urlMatch = Regex.Match(pageUrl, urlParseRegex);
                    String site = urlMatch.Groups["site"].Value;
                    return site.EndsWith("/") ? site + url.Substring(1) : site + url;
                }

                if (url.StartsWith("../"))
                {
                    url = url.Substring(3);
                    int idx = pageUrl.LastIndexOf('/');
                    return ToAbsoluteUrl(url, pageUrl.Substring(0, idx));
                }

                if (url.StartsWith("./"))
                {
                    return ToAbsoluteUrl(url.Substring(2), pageUrl);
                }
                if (url.StartsWith("//"))
                {
                    Match urlMatch = Regex.Match(pageUrl, urlParseRegex);
                    string protocal = urlMatch.Groups["protocal"].Value;
                    return protocal + ":" + url;
                }

                int end = pageUrl.LastIndexOf("/");
                return pageUrl.Substring(0, end) + "/" + url;
            }


}

}


/*
 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework10
{
    public partial class Form1 : Form
    {
        BindingSource resultBindingSource = new BindingSource();
        Crawler crawler = new Crawler();
        Thread thread = null;

        public Form1()
        {
            InitializeComponent();
            Result.DataSource = resultBindingSource;
            crawler.PageDownloaded += Crawler_PageDownloaded;
            crawler.CrawlerStopped += Crawler_CrawlerStopped;
        }

        private void Crawler_CrawlerStopped(Crawler obj)
        {
            Action action = () => statelabel.Text = "爬取结束..." + Convert.ToString(crawler.MaxPage)+"个，显示如下";
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }
        private void Crawler_PageDownloaded(Crawler crawler, int index, string url, string info)
        {
            var newpage = new { Index = index, URL = url, Status = info };
            Action action = () => { resultBindingSource.Add(newpage); };
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
            crawler.Downloadnumber += 1;
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            resultBindingSource.Clear();
            crawler.StartURL = textStartURL.Text;
            int maxnumber;
            int.TryParse(textmax.Text, out maxnumber);
            crawler.MaxPage = maxnumber;

            Match match = Regex.Match(crawler.StartURL, Crawler.urlParseRegex);
            if (match.Length == 0) return;
            string host = match.Groups["host"].Value;
            crawler.HostFilter = "^" + host + "$";
            crawler.FileFilter = "((.html?|.aspx|.jsp|.php)$|^[^.]+$)";

            if (thread != null)
            {
                thread.Abort();
            }
            thread = new Thread(crawler.Excute);
            thread.Start();
            statelabel.Text = "爬虫已启动....";
        }

        private void maxnum_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


*/