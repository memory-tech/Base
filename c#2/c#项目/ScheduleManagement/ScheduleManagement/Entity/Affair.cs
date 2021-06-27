using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ScheduleManagement.Entity
{
    public class Affair
    {
        public int AffairId { get; set; }
        public string Title { get; set; }
        public string Place { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime EndTime { get; set; }//新增，截止时间
        public string Urgency { get; set; }
        public string Content { get; set; }
        public string State { get; set; }//新增，状态
        public int TimeInterval { get; set; }//新增，时间间隔N
        public string Unit { get; set; }//新增，时间间隔单位
        public int RemindTimes { get; set; }//新增,提醒次数
        
        public Affair()
        {
            //To_Do_AffairId = Guid.NewGuid().ToString();
        }

        public Affair(int affairid, string title, string place, DateTime datetime, DateTime endtime, string urgency, string content,
                      string state, int timeinterval, string unit, int remindtimes) : this()
        {
            this.AffairId = affairid;
            this.Title = title;
            this.DateTime = datetime;
            this.DateTime = endtime;
            this.Place = place;
            this.Content = content;
            this.Urgency = urgency;
            this.State = state;
            this.TimeInterval = timeinterval;
            this.Unit = unit;
            this.RemindTimes = remindtimes;
        }
        public override bool Equals(object obj)
        {
            var affair = obj as Affair;
            return affair != null &&
                   AffairId == affair.AffairId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
