using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace ScheduleManagement.Entity
{
    public class To_Do_AffairEntity
    {
        public string To_Do_AffairId { get; set; }
        public string Title { get; set; }
        public DateTime Endtime { get; set; }
        public string Content { get; set; }
        public string Urgency { get; set; }
        public bool IsFinished { get; set; }
        public int Tomato_Number { get; set; }
        public int Tomato_Time { get; set; }

        public To_Do_AffairEntity()
        {
            To_Do_AffairId = Guid.NewGuid().ToString();
        }

        public To_Do_AffairEntity(string to_Do_AffairId, string title, DateTime endtime, string content, string urgency, bool isFinished, int tomato_Number, int tomato_Time)
        {
            To_Do_AffairId = to_Do_AffairId;
            Title = title;
            Endtime = endtime;
            Content = content;
            Urgency = urgency;
            IsFinished = isFinished;
            Tomato_Number = tomato_Number;
            Tomato_Time = tomato_Time;
        }

        public override bool Equals(object obj)
        {
            return obj is To_Do_AffairEntity entity &&
                   To_Do_AffairId == entity.To_Do_AffairId &&
                   Title == entity.Title &&
                   Endtime == entity.Endtime &&
                   Content == entity.Content &&
                   Urgency == entity.Urgency &&
                   IsFinished == entity.IsFinished &&
                   Tomato_Number == entity.Tomato_Number &&
                   Tomato_Time == entity.Tomato_Time;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}