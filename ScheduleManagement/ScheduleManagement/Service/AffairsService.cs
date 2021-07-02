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

        // 是否存在该记录
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from AffairInfo");
            strSql.Append(" where AffairId=@ID ");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@ID", DbType.Int32,8)};
            parameters[0].Value = ID;

            return DbHelperSQLite.Exists(strSql.ToString(), parameters);
        }

        // 增加一条数据
        public bool Add(Entity.Affair affair)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AffairInfo(");
            strSql.Append("Title,Place,DateTime,EndTime,Urgency,Content,State,TimeInterval,Unit,RemindTimes,Stander)");
            strSql.Append(" values (");
            strSql.Append("@Title,@Place,@DateTime,@EndTime,@Urgency,@Content,@State,@TimeInterval,@Unit,@RemindTimes,@Stander)");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Title", DbType.String,25),
                    new SQLiteParameter("@Place", DbType.String,25),
                    new SQLiteParameter("@DateTime", DbType.DateTime),
                    new SQLiteParameter("@EndTime", DbType.DateTime),
                    new SQLiteParameter("@Urgency", DbType.String,25),
                    new SQLiteParameter("@Content", DbType.String,100),
                    new SQLiteParameter("@State",DbType.String,25),
                    new SQLiteParameter("@TimeInterval",DbType.Int32,8),
                    new SQLiteParameter("@Unit",DbType.String,25),
                    new SQLiteParameter("@RemindTimes",DbType.Int32,8),
                    new SQLiteParameter("@Stander",DbType.Int32,8)};
            parameters[0].Value = affair.Title;
            parameters[1].Value = affair.Place;
            parameters[2].Value = affair.DateTime;
            parameters[3].Value = affair.EndTime;
            parameters[4].Value = affair.Urgency;
            parameters[5].Value = affair.Content;
            parameters[6].Value = affair.State;
            parameters[7].Value = affair.TimeInterval;
            parameters[8].Value = affair.Unit;
            parameters[9].Value = affair.RemindTimes;
            parameters[10].Value = affair.Stander;

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
            strSql.Append("EndTime=@EndTime,");
            strSql.Append("Urgency=@Urgency,");
            strSql.Append("Content=@Content,");
            strSql.Append("State=@State,");
            strSql.Append("TimeInterval=@TimeInterval,");
            strSql.Append("Unit=@Unit,");
            strSql.Append("RemindTimes=@RemindTimes,");
            strSql.Append("Stander=@Stander");
            strSql.Append(" where AffairId=@AffairId ");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Title", DbType.String,25),
                    new SQLiteParameter("@Place", DbType.String,25),
                    new SQLiteParameter("@DateTime", DbType.DateTime),
                    new SQLiteParameter("@EndTime", DbType.DateTime),
                    new SQLiteParameter("@Urgency", DbType.String,25),
                    new SQLiteParameter("@Content", DbType.String,100),
                    new SQLiteParameter("@State",DbType.String,25),
                    new SQLiteParameter("@TimeInterval",DbType.Int32,8),
                    new SQLiteParameter("@Unit",DbType.String,25),
                    new SQLiteParameter("@RemindTimes",DbType.Int32,8),
                    new SQLiteParameter("@Stander",DbType.Int32,8),
                    new SQLiteParameter("@AffairId", DbType.Int32,8)};
            parameters[0].Value = affair.Title;
            parameters[1].Value = affair.Place;
            parameters[2].Value = affair.DateTime;
            parameters[3].Value = affair.EndTime;
            parameters[4].Value = affair.Urgency;
            parameters[5].Value = affair.Content;
            parameters[6].Value = affair.State;
            parameters[7].Value = affair.TimeInterval;
            parameters[8].Value = affair.Unit;
            parameters[9].Value = affair.RemindTimes;
            parameters[10].Value = affair.Stander;
            parameters[11].Value = affair.AffairId;

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

        //获得数据列表
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AffairId,Title,Place,DateTime,EndTime,Urgency,Content,State,TimeInterval,Unit,RemindTimes,Stander ");
            strSql.Append(" FROM AffairInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQLite.Query(strSql.ToString());
        }

        //Title 与 urgency 调换位置
        public DataSet GetListOrderbyUrgency(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
        strSql.Append("select AffairId,Urgency,Place,DateTime,EndTime,Title,Content,State,TimeInterval,Unit,RemindTimes,Stander ");
            strSql.Append(" FROM AffairInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by Urgency desc ");
            return DbHelperSQLite.Query(strSql.ToString());
        }

        public DataSet GetBList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AffairId,Title,Place,DateTime,EndTime,Urgency,Content,State,TimeInterval,Unit,RemindTimes,Stander ");
            strSql.Append(" FROM AffairInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQLite.Query(strSql.ToString());
        }

        public DataSet GetTodayList(string strWhere,string s)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AffairId,Title,Place,DateTime,EndTime,Urgency,Content,State,TimeInterval,Unit,RemindTimes FROM AffairInfo WHERE Title like '%s%'");
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
                strSql.Append(" where State='" + strWhere + "'");
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

        public int GetStander(DateTime d1)
        {
            DateTime d2 = DateTime.Now;
            TimeSpan d3 = d2.Subtract(d1);
            return Convert.ToInt32(d3.Days);
        }
        
        //获取所需的记录数（新增）
        public int GetRecordCount(string strWhere, int i )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM AffairInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where State='" + strWhere+"' AND ");
                //当前年份
                int year = DateTime.Now.Year;
                string ys = "" + year;
                //当前月份
                int month = DateTime.Now.Month;
                string ms;
                if (month < 10)
                {
                    ms = "0" + month;
                }
                else
                {
                    ms = "" + month;
                }
                //当前季度
                int jidu = (month - 1) / 3;
                string ss=""+jidu;
                string[] str = new string[3];
                for(int k = 0; k < 3; k++)
                {
                    int temp = k + 1 + jidu * 3;
                    if (temp < 10)
                    {
                        str[k] = "0" + temp;
                    }
                    else
                    {
                        str[k] = "" + temp;
                    }
                }
                switch (i)
                {
                    case 0:
                        strSql.Append("strftime('%m', DateTime)='" + ms + "'");
                        break;
                    case 1:
                        strSql.Append("(strftime('%m', DateTime)='" + str[0] + "' OR ");
                        strSql.Append("strftime('%m', DateTime)='" + str[1] + "' OR ");
                        strSql.Append("strftime('%m', DateTime)='" + str[2] + "')");
                        break;
                    case 2:
                        strSql.Append("strftime('%Y', DateTime)='" + ys + "'");
                        break;
                }
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
        #endregion  BasicMethod
    }

    public partial class AffairService
    {
        private readonly AffairServiceDetail asd = new AffairServiceDetail();
        public AffairService(){ }

        #region  BasicMethod

        public bool Exists(int affairid){return asd.Exists(affairid); }// 是否存在该记录
        public bool Add(Entity.Affair affair){return asd.Add(affair); }// 增加一条数据
        public bool Update(Entity.Affair affair){return asd.Update(affair); }// 更新一条数据
        public bool Delete(int affairid){return asd.Delete(affairid); }// 删除一条数据
        public DataSet GetList(string strWhere){return asd.GetList(strWhere);}// 获得数据列表-->获取全部数据
        public DataSet GetAllList(){return GetList(""); }// 获得全部数据列表
        public DataSet GetListOrderbyUrgency(string strWhere) { return asd.GetListOrderbyUrgency(strWhere); }//按紧急程度得到列表
        public int GetRecordCount(string strWhere){return asd.GetRecordCount(strWhere);}// 获取记录总数
        public int GetRecordCount(string strWhere, int i) {return asd.GetRecordCount(strWhere, i);}
        public int GetStander(DateTime d1) { return asd.GetStander(d1); }

        #endregion  BasicMethod

    }
}
