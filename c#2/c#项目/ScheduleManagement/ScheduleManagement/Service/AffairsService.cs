using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
//using System.Data.Entity;
using ScheduleManagement.Entity;

namespace ScheduleManagement.Service
{
    
    public partial class AffairServiceDetail
    {
        public AffairServiceDetail()
        { }
        #region  BasicMethod

/*        // 得到最大ID
        public int GetMaxId()
        {
            return DbHelperSQLite.GetMaxID("AffairId", "AffairInfo");
        }*/

        // 是否存在该记录
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from AffairInfo");
            strSql.Append(" where AffairId=@ID ");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@ID", DbType.Int32,8)          };
            parameters[0].Value = ID;

            return DbHelperSQLite.Exists(strSql.ToString(), parameters);
        }

        // 增加一条数据
        public bool Add(Entity.Affair affair)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AffairInfo(");
            strSql.Append("Title,Place,DateTime,Urgency,Content)");
            strSql.Append(" values (");
            strSql.Append("@Title,@Place,@DateTime,@Urgency,@Content)");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Title", DbType.String,25),
                    new SQLiteParameter("@Place", DbType.String,25),
                    new SQLiteParameter("@DateTime", DbType.DateTime),
                    new SQLiteParameter("@Urgency", DbType.String,25),
                    new SQLiteParameter("@Content", DbType.String,100)};
            parameters[0].Value = affair.Title;
            parameters[1].Value = affair.Place;
            parameters[2].Value = affair.DateTime;
            parameters[3].Value = affair.Urgency;
            parameters[4].Value = affair.Content;


            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // 更新一条数据
        public bool Update(Entity.Affair affair)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AffairInfo set ");
            strSql.Append("Title=@Title,");
            strSql.Append("Place=@Place,");
            strSql.Append("DateTime=@DateTime,");
            strSql.Append("Urgency=@Urgency,");
            strSql.Append("Content=@Content");
            strSql.Append(" where AffairId=@AffairId ");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Title", DbType.String,25),
                    new SQLiteParameter("@Place", DbType.String,25),
                    new SQLiteParameter("@DateTime", DbType.DateTime),
                    new SQLiteParameter("@Urgency", DbType.String,25),
                    new SQLiteParameter("@Content", DbType.String,100),
                    new SQLiteParameter("@AffairId", DbType.Int32,8)};
            parameters[0].Value = affair.Title;
            parameters[1].Value = affair.Place;
            parameters[2].Value = affair.DateTime;
            parameters[3].Value = affair.Urgency;
            parameters[4].Value = affair.Content;
            parameters[5].Value = affair.AffairId;

            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // 删除一条数据
        public bool Delete(int AffairId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AffairInfo ");
            strSql.Append(" where AffairId=@AffairId ");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@AffairId", DbType.Int32,8)          };
            parameters[0].Value = AffairId;

            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
 /*       //批量删除数据
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserInfo ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/


 /*       //得到一个对象实体
        public Model.UserInfo GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,UserName,Pwd,Age from UserInfo ");
            strSql.Append(" where ID=@ID ");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@ID", DbType.Int32,8)          };
            parameters[0].Value = ID;

            Model.UserInfo model = new Model.UserInfo();
            DataSet ds = DbHelperSQLite.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 从缓存中得到一个对象实体
        /// </summary>
        public Model.UserInfo DataRowToModel(DataRow row)
        {
            Model.UserInfo model = new Model.UserInfo();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["Pwd"] != null)
                {
                    model.Pwd = row["Pwd"].ToString();
                }
                if (row["Age"] != null && row["Age"].ToString() != "")
                {
                    model.Age = int.Parse(row["Age"].ToString());
                }
            }
            return model;
        }*/

        //获得数据列表
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AffairId,Title,Place,DateTime,Urgency,Content ");
            strSql.Append(" FROM AffairInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQLite.Query(strSql.ToString());
        }

        //获取记录总数
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM AffairInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQLite.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }


        //按urgency获取数据列表

/*        // 分页获取数据列表
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from UserInfo T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQLite.Query(strSql.ToString());
        }*/

        #endregion  BasicMethod
    }


    public partial class AffairService
    {
        private readonly AffairServiceDetail asd = new AffairServiceDetail();
        public AffairService(){ }

        #region  BasicMethod

//       public int GetMaxId(){return asd.GetMaxId();}  // 得到最大ID
        public bool Exists(int affairid){return asd.Exists(affairid); }// 是否存在该记录
        public bool Add(Entity.Affair affair){return asd.Add(affair); }// 增加一条数据
        public bool Update(Entity.Affair affair){return asd.Update(affair); }// 更新一条数据
        public bool Delete(int affairid){return asd.Delete(affairid); }// 删除一条数据
                                                                       //        public bool DeleteList(string IDlist){return asd.DeleteList(IDlist); }//批量删除数据
                                                                       //        public Entity.Affair GetModel(int ID){return asd.GetModel(ID); }// 得到一个对象实体

        ///// <summary>
        ///// 得到一个对象实体，从缓存中
        ///// </summary>
        //public Model.UserInfo GetModelByCache(int ID)
        //{
        //    string CacheKey = "UserInfoModel-" + ID;
        //    object objModel = Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(ID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (Maticsoft.Model.UserInfo)objModel;
        //}

        public DataSet GetList(string strWhere){return asd.GetList(strWhere);}// 获得数据列表-->获取全部数据
/*        public List<Model.UserInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }// 获得数据列表*/
        
/*        // 获得数据列表
        public List<Model.UserInfo> DataTableToList(DataTable dt)
        {
            List<Model.UserInfo> modelList = new List<Model.UserInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.UserInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }*/
        public DataSet GetAllList(){return GetList(""); }// 获得全部数据列表

        public int GetRecordCount(string strWhere){return asd.GetRecordCount(strWhere);}// 获取记录总数
/*        //分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }*/

        /// 分页获取数据列表
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod

    }


    #region AS
    /*   class AffairsService
       {
           public AffairsService()
           {
               using (var ctx = new ScheduleContext())
               {
                   ctx.To_Do_Affairs.Add(new Affair("0", "NULL", DateTime.Parse("2021-01-01 12:00:00"), "NULL", "NULL", "NULL"));
                   ctx.SaveChanges();
               }
           }

           public List<Affair> To_Do_Affairs
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
       }*/
    #endregion AS
}
