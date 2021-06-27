using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
namespace ScheduleManagement.Service
{
    class TomatoServiceDetail
    {
        public bool Add(Entity.TomatoData tomatoData)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TomatoInfo");//有问题的地方
            strSql.Append("(Time,Title,Tomatos,TotalTime)");
            strSql.Append(" values ");
            strSql.Append("(@Time,@Title,@Tomatos,@TotalTime)");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Time", DbType.DateTime),
                    new SQLiteParameter("@Title", DbType.String),
                    new SQLiteParameter("@Tomatos", DbType.Int32),
                    new SQLiteParameter("@TotalTime", DbType.Int32)};
            parameters[0].Value = tomatoData.Time;
            parameters[1].Value = tomatoData.Title;
            parameters[2].Value = tomatoData.Tomatos;
            parameters[3].Value = tomatoData.TotalTime;
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
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Time,Title,Tomatos,TotalTime ");
            strSql.Append(" FROM TomatoInfo ");//有问题的地方
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQLite.Query(strSql.ToString());
        }
    }
    public class TomatoService
    {
        private TomatoServiceDetail tsd = new TomatoServiceDetail();
        public TomatoService() { }
        public bool Add(Entity.TomatoData tomatoData) { return tsd.Add(tomatoData); }// 增加一条数据
        public DataSet GetList(string strWhere) { return tsd.GetList(strWhere); }// 获得数据列表
        public DataSet GetAllList() { return GetList(""); }// 获得全部数据列表
    }
}
