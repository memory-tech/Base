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
        public string Urgency { get; set; }
        public string Content { get; set; }

        public Affair()
        {
            //To_Do_AffairId = Guid.NewGuid().ToString();
        }

        public Affair(int affairid, string title, string place, DateTime endtime, string urgency, string content) : this()
        {
            this.AffairId = affairid;
            this.Title = title;
            this.DateTime = endtime;
            this.Place = place;
            this.Content = content;
            this.Urgency = urgency;
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
