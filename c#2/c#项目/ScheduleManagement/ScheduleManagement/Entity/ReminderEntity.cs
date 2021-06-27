using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleManagement.Entity
{
    class ReminderEntity
    {
        public string REMIND_MUSIC { get; set; }
        public int S_Times { get; set; }
        //日程提醒次数（1）
        public int T_Times{ get; set; }
        //待办事项提醒次数（间隔多次）
        public int S_Minutes { get; set; }
        //日程提醒间隔时间（具体到小时分钟）
        public int T_Minutes { get; set; }
        //待办事项提前提醒时间（提前到天）

       
    }
}
