using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ScheduleManagement.Entity
{
    public class ScheduleEntity
    {
        #region 成员变量
        public string ScheduleId { get; set; }
        public string Title { get; set; }
        public DateTime Datetime { get; set; }
        public string Place { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        #endregion

        public ScheduleEntity()
        {
            ScheduleId = Guid.NewGuid().ToString();
        }

        public ScheduleEntity(string scheduleid, string title, DateTime datetime, string place, string content, string category) : this()
        {
            this.ScheduleId = scheduleid;
            this.Title = title;
            this.Datetime = datetime;
            this.Place = place;
            this.Content = content;
            this.Category = category;
        }

        public override bool Equals(object obj)
        {
            var scheduleentity = obj as ScheduleEntity;
            return scheduleentity != null &&
                   ScheduleId == scheduleentity.ScheduleId;
        }

        public override int GetHashCode()
        {
             return base.GetHashCode();
        }
}
}
