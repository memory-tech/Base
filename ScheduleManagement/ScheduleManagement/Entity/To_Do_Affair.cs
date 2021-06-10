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
        public string Place { get; set; }
        public string Content { get; set; }
        public string Urgency { get; set; }

        public To_Do_AffairEntity()
        {
            To_Do_AffairId = Guid.NewGuid().ToString();
        }

        public To_Do_AffairEntity(string to_do_affairid, string title,  DateTime endtime, string place, string content, string urgency) : this()
        {
            this.To_Do_AffairId = to_do_affairid;
            this.Title = title;
            this.Endtime = endtime;
            this.Place = place;
            this.Content = content;
            this.Urgency = urgency;
        }
        public override bool Equals(object obj)
        {
            var to_do_affairentity = obj as To_Do_AffairEntity;
            return to_do_affairentity != null &&
                   To_Do_AffairId == to_do_affairentity.To_Do_AffairId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
