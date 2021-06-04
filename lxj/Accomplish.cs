using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dailyrecord
{
    class Accomplish
    {
        //分类查询各项事件的完成情况：完成数、未完成数、花费时间
        public int GetAccomplishedRecord(DateTime StartTime, DateTime EndTime, string groupBy) 
        {
            int AccNum;
            /
            return AccNum;
        }/查询已完成

        public int GetUnccomplishedRecord(DateTime StartTime, DateTime EndTime, string groupBy)
        {
            int UnaccNum;
            return UnaccNum;
        }

        public void SearchRecord(DateTime dateFrom, DateTime dateTo, string groupBy)  
        {
            //统计dateFrom到dateTo时间，groupBy为事件分类
            //各类活动的总时间


        }

        
    }
}
