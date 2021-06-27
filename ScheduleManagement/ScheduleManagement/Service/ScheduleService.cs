﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ScheduleManagement.Entity;

namespace ScheduleManagement.Service
{
    public class ScheduleService
    {

        public ScheduleService()
        {
            using (var ctx = new ScheduleContext())
            {
                ctx.Schedules.Add(new ScheduleEntity("0", "NULL", DateTime.Parse("2021-01-01 12:00:00"), "NULL", "NULL", "NULL"));
                ctx.SaveChanges();
            }
        }

        public List<ScheduleEntity> Schedules
        {
            get
            {
                using (var ctx = new ScheduleContext())
                {
                    return ctx.Schedules.ToList<ScheduleEntity>();
                }
            }
        }
        public ScheduleEntity GetScheduleEntity(string id)
        {
            using (var ctx = new ScheduleContext())
            {
                return ctx.Schedules.SingleOrDefault(s => s.ScheduleId == id);
            }
        }

        #region 增删改
        public void AddScheduleEntity(ScheduleEntity scheduleentity)
        {
            using (var ctx = new ScheduleContext())
            {
                ctx.Entry(scheduleentity).State = EntityState.Added;
                ctx.SaveChanges();
            }
        }

        public void RemoveScheduleEntity(string id)
        {
            using (var ctx = new ScheduleContext())
            {
                var scheduleentity = ctx.Schedules.SingleOrDefault(s => s.ScheduleId == id);
                if (scheduleentity == null) return;
                ctx.Schedules.Remove(scheduleentity);
                ctx.SaveChanges();
            }
        }
        
        public void UpdateScheduleEntity(ScheduleEntity newscheduleentity)
        {
            RemoveScheduleEntity(newscheduleentity.ScheduleId);
            AddScheduleEntity(newscheduleentity);
        }
        #endregion

        #region 按分类展示
        public List<ScheduleEntity> ShowSchedulesByCategory(string category)
        {
            using (var ctx = new ScheduleContext())
            {
                var query = ctx.Schedules
                    .Where(scheduleentity => scheduleentity.Category == category);
                return query.ToList();
            }
        }
        #endregion
            
        /// <summary>
        /// 删除当天日程事务
        /// 删除所有已处理日程事务
        /// 删除所有事务
        /// 查询当天日程事务
        /// 查询返回所有日程的DataSet
        /// 更新处理状态
        /// 自动更新日程状态
        /// 构造当日未完成事务
        /// </summary>
        
    }
}