using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleManagement.Entity
{
    public class ReminderTime
    {
        public int AffId { get; set; }  //----id是否可以不起作用
        public string Title1 { get; set; }
        public DateTime DateTime1 { get; set; }
        public DateTime EndTime1 { get; set; }//新增，截止时间
        public string State1 { get; set; }//----------------------------------???
        public int TimeInterval1 { get; set; }//新增，时间间隔N
        public string Unit1 { get; set; }//新增，时间间隔单位
        public int RemindTimes1 { get; set; }//新增,提醒次数
        public DateTime ClockTime1 { get; set; }
        public DateTime ClockTime2 { get; set; }
        public DateTime ClockTime3 { get; set; }

        public ReminderTime()
        {
            
        }

        public ReminderTime(int affid, string title1, DateTime datetime1, DateTime endtime1, string state1, int timeinterval1, string unit1, int remindtimes1,
                            DateTime clocktime1, DateTime clocktime2, DateTime clocktime3) : this()
        {
            this.AffId = affid;
            this.Title1 = title1;
            this.DateTime1 = datetime1;
            this.DateTime1 = endtime1;
            this.State1 = state1;
            this.TimeInterval1 = timeinterval1;
            this.Unit1 = unit1;
            this.RemindTimes1 = remindtimes1;
            this.ClockTime1 = clocktime1;
            this.ClockTime2 = clocktime2;
            this.ClockTime3 = clocktime3;
        }
        public override bool Equals(object obj)
        {
            var rt = obj as ReminderTime;
            return rt != null &&
                   AffId == rt.AffId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


    }

    public class Others
    {
        public int OthersId { get; set; }
        public int Preference { get; set; }
        public string Music_path { get; set; }
        public int Achievement_unit { get; set; }
        public string Theme_path { get; set; }

        public Others() { }
        public Others(int othersid, int preference, string music_path,int achievement_unit, string theme_path):this()
        {
            this.OthersId = othersid;
            this.Preference = preference;
            this.Music_path = music_path;
            this.Achievement_unit = achievement_unit;
            this.Theme_path = theme_path;
        }
    }
}
