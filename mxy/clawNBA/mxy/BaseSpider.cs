using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading;

namespace clawNBA
{
    public abstract class BaseSpider
    {

        //调用：设置中的球队偏好数据
        /*输出：
        1.弹出询问
        2.加入待办事项：string：时间，对阵球队，比赛url
        3.从弹窗跳转到目标url（怎么实现？）     
        */


        // 所属任务ID
        public int TaskId { get; set; }       
        // 赛程列表地址
        public string ListUrl { get; set; }      
        // 爬取关键字，用 / 分隔
        public string KeyWords { get; set; }  
        // 爬取个数
        public int Count { get; set; }

        
        // 爬取最近天数
        public int ScanLastDay { get; set; }

        
        // 列表标签  
        public string ListTag { get; set; }

        
        // 列表球队信息标签 ，通过数据绑定实现
        public string ListTitleTag { get; set; }

      
        // 列表时间标签
        public string ListDateTag { get; set; }

        // 页码起始index
        public int PageStartInx { get; set; }
        
        //网站编码
        public string Charset { get; set; }
        protected HtmlWeb htmlWeb;
        protected BackgroundWorker backgroundWorker = null;
        protected Form1 mainForm = null;
        protected TaskInfo TaskInfo;

        
        // 是否存储到数据库，用于添加进待办事项
        protected bool saveToDB = true;

        
        // 线程结束后做些事情
        private Action callbackFunc;

        
        // 爬取到的数据，按标题存储，用以展示、筛选或添加进待办事项
        public Dictionary<string, Context> ResultDataDic;

        

        public BaseSpider(mainForm mainForm)
        {
            
        }

        //爬取的大框架
        protected void doWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //爬取
                for (int ipage = 0; ipage <= PageCount; ipage++)//获取每一页的赛程数据，设置截止条件，即最大比赛数，按时间排序（因为每一页就是按时间顺序）
                {
                }
                if (getdata > 0 && max<n)//爬到的数据数量,设置最大数量，避免弹窗过多
                {
                    for{//对每场比赛进行弹出提醒
                        //如果添加，则添加进待办事项
                        //如果查看，则调到详情url
                        //如果忽略，则不作操作，下一个
                    }
                }
                else
                {
                    //没比赛，不做操作
                }
            }
           
        }

        
        /// 线程执行完毕
        protected virtual void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        
        /// 外部调用执行任务
        public bool Run(TaskInfo taskInfo, Action callbackFunc, bool saveToDB = true)
        {
        }


        /// 获取比赛列表
        protected abstract void GetTitleList(HtmlNodeCollection htmlNodes);

        /// 获取下一页赛程

        protected abstract string GetNextPage(int pageNum);       


        /// 关键字判断,即关注的球队名，决定是否添加进爬取到的数据列表
        protected bool IsContains(string context)
        {

            return true;
        }


        /// 从标题中提取时间、球队等信息
        public static string GetDateFromString(string str)
        {
            string res = "";
            return res;
        }



        //得到比赛详情页的url
        protected string GetdetailUrl(string localhost, string url)
        {
            string result = string.Empty;

            return result;
        }


        //弹窗提醒


        //将赛程信息写入待办事项
        public void writein(Context)
        {
            //写进对应的数据库
        }
        

        /// 点击“查看详情”跳转到比赛详情页面
        public HtmlDocument GetDoc(HtmlWeb htmlWeb, string url)
        {
            
        }

        
        /// 按任务ID来存储任务清单
        private Dictionary<int, TaskInfo> taskInfos;

        public List<TaskInfo> TaskInfos => taskInfos.Values.ToList();

        private TaskMngBLL()//取任务清单
        {
            taskInfos = GetTaskInfos();
        }


        /// 保存新的任务，定时自动实现，以实现定时爬取
        public bool AddNewTask(TaskInfo taskInfo)
        {
            bool b = SaveNewTask(taskInfo);
            return b;
        }


        /// 获取任务
        public TaskInfo GetTask(int taskId)
        {
        }


        /// 更新任务
        public bool UpdateTask(TaskInfo taskInfo)
        {
        }


        /// 运行计划任务，并设置爬取的时间频率等
        public bool Run(mainForm mainForm)
        {

        }
    }
}
