using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using ScheduleManagement.Entity;

namespace ScheduleManagement.Service
{

    public partial class ReminderServiceDetails
    {
        public ReminderServiceDetails() { }

        #region BasicMethod
        //自动在ReminderTime表中增加数据
        public void Add(Entity.ReminderTime rt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ReminderTime(");
            strSql.Append("Title1,DateTime1,EndTime1,State1,TimeInterval1,Unit1,RemindTimes1,ClockTime1,ClockTime2,ClockTime3)");
            strSql.Append(" values (");
            strSql.Append("@Title1,@DateTime1,@EndTime1,@State1,@TimeInterval1,@Unit1,@RemindTimes1,@ClockTime1,@ClockTime2,@ClockTime3)");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Title1", DbType.String,25),
                    new SQLiteParameter("@DateTime1", DbType.DateTime),
                    new SQLiteParameter("@EndTime1", DbType.DateTime),
                    new SQLiteParameter("@State1", DbType.String,25),
                    new SQLiteParameter("@TimeInterval1",DbType.Int32,8),
                    new SQLiteParameter("@Unit1",DbType.String,25),
                    new SQLiteParameter("@RemindTimes1",DbType.Int32,8),
                    new SQLiteParameter("@ClockTime1",DbType.DateTime),
                    new SQLiteParameter("@ClockTime2",DbType.DateTime),
                    new SQLiteParameter("@ClockTime3",DbType.DateTime)};
            parameters[0].Value = rt.Title1;
            parameters[1].Value = rt.DateTime1;
            parameters[2].Value = rt.EndTime1;
            parameters[3].Value = rt.State1;
            parameters[4].Value = rt.TimeInterval1;
            parameters[5].Value = rt.Unit1;
            parameters[6].Value = rt.RemindTimes1;
            parameters[7].Value = rt.ClockTime1;
            parameters[8].Value = rt.ClockTime2;
            parameters[9].Value = rt.ClockTime3;

            DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            return;
        }

        //更新
        public void Update(Entity.ReminderTime rt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ReminderTime set ");
            strSql.Append("Title1=@Title1,");
            strSql.Append("DateTime1=@DateTime1,");
            strSql.Append("EndTime1=@EndTime1,");
            strSql.Append("State1=@State1,");
            strSql.Append("TimeInterval1=@TimeInterval1,");
            strSql.Append("Unit1=@Unit1,");
            strSql.Append("RemindTimes1=@RemindTimes1,");
            strSql.Append("ClockTime1=@ClockTime1,");
            strSql.Append("ClockTime2=@ClockTime2,");
            strSql.Append("ClockTime3=@ClockTime3");
            strSql.Append(" where AffId=@AffId ");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Title1", DbType.String,25),
                    new SQLiteParameter("@DateTime1", DbType.DateTime),
                    new SQLiteParameter("@EndTime1", DbType.DateTime),
                    new SQLiteParameter("@State1",DbType.String,25),
                    new SQLiteParameter("@TimeInterval1",DbType.Int32,8),
                    new SQLiteParameter("@Unit1",DbType.String,25),
                    new SQLiteParameter("@RemindTimes1",DbType.Int32,8),
                    new SQLiteParameter("@ClockTime1", DbType.DateTime),
                    new SQLiteParameter("@ClockTime2", DbType.DateTime),
                    new SQLiteParameter("@ClockTime3", DbType.DateTime),
                    new SQLiteParameter("@AffId", DbType.Int32,8)};
            parameters[0].Value = rt.Title1;
            parameters[1].Value = rt.DateTime1;
            parameters[2].Value = rt.EndTime1;
            parameters[3].Value = rt.State1;
            parameters[4].Value = rt.TimeInterval1;
            parameters[5].Value = rt.Unit1;
            parameters[6].Value = rt.RemindTimes1;
            parameters[7].Value = rt.ClockTime1;
            parameters[8].Value = rt.ClockTime2;
            parameters[9].Value = rt.ClockTime3;
            parameters[10].Value = rt.AffId;

            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            return;
        }

        //删除
        public void Delete(int AffId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ReminderTime ");
            strSql.Append(" where AffId=@AffId ");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@AffId", DbType.String,25)};
            parameters[0].Value = AffId;

            DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            return;
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AffId,Title1,DateTime1,EndTime1,State1,TimeInterval1,Unit1,RemindTimes1,ClockTime1,ClockTime2,ClockTime3 ");
            strSql.Append(" FROM ReminderTime ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQLite.Query(strSql.ToString());
        }

        //按状态、时间排序，未完成、距离时间最近的排在前面
        public DataSet GetOrderedList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AffId, Title1,DateTime1,EndTime1,State1,ClockTime1,ClockTime2,ClockTime3 ");//新增了状态位
            strSql.Append(" from ReminderTime ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ClockTime1 asc");//desc
            return DbHelperSQLite.Query(strSql.ToString());
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ReminderTime ");
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
        #endregion DasicMethod

    }

    public partial class ReminderService
    {
        private readonly ReminderServiceDetails rsd = new ReminderServiceDetails();
        public ReminderService() { }

        #region Method
        public void Add(Entity.ReminderTime rt) { rsd.Add(rt); }// 增加一条数据
        public void Delete(int AffId) { rsd.Delete(AffId); }// 删除一条数据
        public void Update(Entity.ReminderTime rt) { rsd.Update(rt); }//修改
        public DataSet GetList(string strWhere) { return rsd.GetList(strWhere); }
        public DataSet GetOrderedList(string strWhere) { return rsd.GetOrderedList(strWhere); }
        public int GetRecordCount(string strWhere) { return rsd.GetRecordCount(strWhere); }

        #endregion Method

    }

    public partial class OthersServiceDetails
    {
        public OthersServiceDetails() { }

        #region Basic Methon

        public void UpdatePreference(Entity.Others oth)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Others set ");
            strSql.Append("Preference=@Preference");
            strSql.Append(" where OthersId=1 ");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Preference", DbType.Int32,8)};
            parameters[0].Value = oth.Preference;

            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            return;
        }

        public DataSet GetPreferenceList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Preference ");
            strSql.Append(" FROM Others ");
            strSql.Append(" where OthersId=1 ");
            return DbHelperSQLite.Query(strSql.ToString());
        }

        public void UpdateMusic(Entity.Others oth)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Others set ");
            strSql.Append("Music_path=@Music_path");
            strSql.Append(" where OthersId=1 ");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Music_path", DbType.String,200)};
            parameters[0].Value = oth.Music_path;

            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            return;
        }

        public DataSet GetMusic_pathList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Music_path ");
            strSql.Append(" FROM Others ");
            strSql.Append(" where OthersId=1 ");
            return DbHelperSQLite.Query(strSql.ToString());
        }

        public void UpdateAchievement_unit(Entity.Others oth)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Others set ");
            strSql.Append("Achievement_unit=@Achievement_unit");
            strSql.Append(" where OthersId=1 ");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Achievement_unit", DbType.Int32,8)};
            parameters[0].Value = oth.Achievement_unit;

            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            return;
        }

        public DataSet GetAchievement_unitList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Achievement_unit ");
            strSql.Append(" FROM Others ");
            strSql.Append(" where OthersId=1 ");
            return DbHelperSQLite.Query(strSql.ToString());
        }

        public void UpdateTheme_path(Entity.Others oth)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Others set ");
            strSql.Append("Theme_path=@Theme_path");
            strSql.Append(" where OthersId=1 ");
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@Theme_path", DbType.String,200)};
            parameters[0].Value = oth.Theme_path;

            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            return;
        }

        public DataSet GetTheme_pathList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Theme_path ");
            strSql.Append(" FROM Others ");
            strSql.Append(" where OthersId=1 ");
            return DbHelperSQLite.Query(strSql.ToString());
        }
        #endregion Basic Region
    }
}