using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using ScheduleManagement.Entity;

namespace ScheduleManagement.Service
{
    class To_Do_AffairsService
    {
        public To_Do_AffairsService()
        {
            using (var ctx = new ScheduleContext())
            {
                ctx.To_Do_Affairs.Add(new To_Do_AffairEntity("0", "NULL", DateTime.Parse("2021-01-01 12:00:00"), "NULL", "NULL", "NULL"));
                ctx.SaveChanges();
            }
        }

        public List<To_Do_AffairEntity> To_Do_Affairs
        {
            get
            {
                using (var ctx = new ScheduleContext())
                {
                    return ctx.To_Do_Affairs.ToList<To_Do_AffairEntity>();
                }
            }
        }
        public To_Do_AffairEntity GetTo_Do_AffairEntity(string id)
        {
            using (var ctx = new ScheduleContext())
            {
                return ctx.To_Do_Affairs.SingleOrDefault(a => a.To_Do_AffairId == id);
            }
        }

        #region 增删改
        public void AddTo_Do_AffairEntity(To_Do_AffairEntity to_do_affairentity)
        {
            using (var ctx = new ScheduleContext())
            {
                ctx.Entry(to_do_affairentity).State = EntityState.Added;
                ctx.SaveChanges();
            }
        }

        public void RemoveTo_Do_AffairEntity(string id)
        {
            using (var ctx = new ScheduleContext())
            {
                var to_do_affairentity = ctx.To_Do_Affairs.SingleOrDefault(a => a.To_Do_AffairId == id);
                if (to_do_affairentity == null) return;
                ctx.To_Do_Affairs.Remove(to_do_affairentity);
                ctx.SaveChanges();
            }
        }

        public void UpdateTo_Do_AffairEntity(To_Do_AffairEntity newto_do_affair)
        {
            RemoveTo_Do_AffairEntity(newto_do_affair.To_Do_AffairId);
            AddTo_Do_AffairEntity(newto_do_affair);
        }
        #endregion

        #region 按紧急情况展示
        public List<To_Do_AffairEntity> ShowTo_Do_AffairsByCategory(string urgency)
        {
            using (var ctx = new ScheduleContext())
            {
                var query = ctx.To_Do_Affairs
                    .Where(a => a.Urgency == urgency);
                return query.ToList();
            }
        }
        #endregion

        /// <summary>
        /// 删除当天事务
        /// 删除所有已处理事务
        /// 删除所有事务
        /// 查询当天事务
        /// 查询返回所有事务的DataSet
        /// 更新处理状态
        /// 自动更新事务状态
        /// 自动更新事务等级
        /// 构造当日未完成事务
        /// </summary>
    }
}
