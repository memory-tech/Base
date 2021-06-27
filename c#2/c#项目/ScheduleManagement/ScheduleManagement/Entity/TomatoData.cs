using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleManagement.Entity
{
    public class TomatoData
    {
        public DateTime Time { get; set; }
        public string Title { get; set; }
        public int Tomatos { get; set; }
        public int TotalTime { get; set; }
        public TomatoData() { }

        public TomatoData(DateTime time, string title, int tomatos, int totalTime)
        {
            Time = time;
            Title = title;
            Tomatos = tomatos;
            TotalTime = totalTime;
        }

        public override bool Equals(object obj)
        {
            return obj is TomatoData data &&
                   Time == data.Time &&
                   Title == data.Title &&
                   Tomatos == data.Tomatos &&
                   TotalTime == data.TotalTime;
        }

        public override int GetHashCode()
        {
            int hashCode = -1262897303;
            hashCode = hashCode * -1521134295 + Time.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + Tomatos.GetHashCode();
            hashCode = hashCode * -1521134295 + TotalTime.GetHashCode();
            return hashCode;
        }
    }
}
