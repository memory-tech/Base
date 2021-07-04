using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleManagement.Entity;

namespace ScheduleManagement.Service
{
    public partial class ClockTimeCalculation
    {
        public ClockTimeCalculation() { }

        public void GetClockTime1to3(Entity.Affair aff, Entity.ReminderTime rt,DateTime Time)
        {
            string Unit = aff.Unit;
            int RemindTimes = aff.RemindTimes;
            int TimeInterval = aff.TimeInterval;       
            if (Unit == "天")
            {
                switch (RemindTimes)
                {
                    case 1:
                        rt.ClockTime1 = Time.AddDays(-TimeInterval);
                        break;
                    case 2:
                        rt.ClockTime2 = Time.AddDays(-TimeInterval);
                        rt.ClockTime1 = Time.AddDays(-2 * TimeInterval);
                        break;
                    case 3:
                        rt.ClockTime3 = Time.AddDays(-TimeInterval);
                        rt.ClockTime2 = Time.AddDays(-2 * TimeInterval);
                        rt.ClockTime1 = Time.AddDays(-3 * TimeInterval);
                        break;
                    default:
                        break;
                }
            }
            else if (Unit == "时")
            {
                switch (RemindTimes)
                {
                    case 1:
                        rt.ClockTime1 = Time.AddHours(-TimeInterval);
                        break;
                    case 2:
                        rt.ClockTime2 = Time.AddHours(-TimeInterval);
                        rt.ClockTime1 = Time.AddHours(-2 * TimeInterval);
                        break;
                    case 3:
                        rt.ClockTime3 = Time.AddHours(-TimeInterval);
                        rt.ClockTime2 = Time.AddHours(-2 * TimeInterval);
                        rt.ClockTime1 = Time.AddHours(-3 * TimeInterval);
                        break;
                    default:
                        break;
                }
            }
            else if (Unit == "分")
            {
                switch (RemindTimes)
                {
                    case 1:
                        rt.ClockTime1 = Time.AddMinutes(-TimeInterval);
                        break;
                    case 2:
                        rt.ClockTime2 = Time.AddMinutes(-TimeInterval);
                        rt.ClockTime1 = Time.AddMinutes(-2 * TimeInterval);
                        break;
                    case 3:
                        rt.ClockTime3 = Time.AddMinutes(-TimeInterval);
                        rt.ClockTime2 = Time.AddMinutes(-2 * TimeInterval);
                        rt.ClockTime1 = Time.AddMinutes(-3 * TimeInterval);
                        break;
                    default:
                        break;
                }
            }

        }
    }
}