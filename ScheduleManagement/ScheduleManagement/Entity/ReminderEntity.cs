using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ScheduleManagement.Entity
{
    public class S_ReminderEntity
    {
        public string S_REMIND_MUSIC { get; set; }
        public int S_Times { get; set; }
        //日程提醒次数
        public int S_Minutes { get; set; }
        //日程提醒间隔时间

        public S_ReminderEntity()
        {
        }

        public S_ReminderEntity(string s_remind_music, int s_times, int s_minutes) : this()
        {
            this.S_REMIND_MUSIC = s_remind_music;
            this.S_Times = s_times;
            this.S_Minutes = s_minutes;
        }
    }

    public class T_ReminderEntity
    {
        public string T_REMIND_MUSIC { get; set; }
        public int T_Minutes { get; set; }
        //待办事项提前提醒时间

        public T_ReminderEntity() { }

        public T_ReminderEntity(string t_remind_music, int t_minutes) : this()
        {
            this.T_REMIND_MUSIC = t_remind_music;
            this.T_Minutes = t_minutes;
        }
    }
}