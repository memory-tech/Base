using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleManagement.Entity
{
    public class TomatoData
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public string Title { get; set; }
        public int Tomatos { get; set; }
        public int TotalTime { get; set; }
        public TomatoData() { }

        public TomatoData(int id, int month, string title, int tomatos, int totalTime)
        {
            Id = id;
            Month = month;
            Title = title;
            Tomatos = tomatos;
            TotalTime = totalTime;
        }

        public override bool Equals(object obj)
        {
            return obj is TomatoData data &&
                   Id == data.Id &&
                   Month == data.Month &&
                   Title == data.Title &&
                   Tomatos == data.Tomatos &&
                   TotalTime == data.TotalTime;
        }

        public override int GetHashCode()
        {
            int hashCode = 1530916674;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + Month.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + Tomatos.GetHashCode();
            hashCode = hashCode * -1521134295 + TotalTime.GetHashCode();
            return hashCode;
        }
    }
}
