using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Configuration;
using EZOper.TechTester.OAuth2ApiSI;

namespace EZOper.TechTester.OAuth2ApiBLL
{
    internal class SQLiteHelper
    {
        /// <summary>
        /// WebConfig中connectionStrings配置
        /// <add name="EZOper.TechTester.SQLite.sqlite3" connectionString="Data Source=|DataDirectory|\SQLite\EZOper.TechTester.SQLite.sqlite3" providerName="System.Data.SQLite" />
        /// </summary>
        internal static readonly string EZOper_TechTester_SQLite_Sqlite3 = ConfigurationManager.ConnectionStrings["EZOper.TechTester.SQLite.sqlite3"].ConnectionString;

        string connString;
        SQLiteConnection cnn;

        public SQLiteHelper()
        {
            connString = EZOper_TechTester_SQLite_Sqlite3;
            cnn = new SQLiteConnection(connString);
        }

        public SQLiteHelper(string dbConnStr)
        {
            connString = dbConnStr;
            cnn = new SQLiteConnection(connString);
        }

        public SQLiteHelper(SQLiteConnectionStringBuilder builder)
        {
            connString = builder.ConnectionString;
            cnn = new SQLiteConnection(connString);
        }

        /// <summary>
        /// 通过配置字典类初始化类
        /// </summary>
        /// <param name="paramDic">配置参数字典</param>
        public SQLiteHelper(Dictionary<string, string> paramDic)
        {
            string str = "";
            foreach (var param in paramDic)
            {
                str += string.Format("{0}={1}; ", param.Key, param.Value);
            }
            connString = str;
            cnn = new SQLiteConnection(connString);
        }

        /// <summary>
        /// 获取一个查询的结果集
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>返回查询结果集DataTable</returns>
        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                cnn.Open();
                using (var mycommand = new SQLiteCommand(cnn))
                {
                    mycommand.CommandText = sql;
                    using (var reader = mycommand.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                cnn.Close();
            }
            return dt;
        }

        /// <summary>
        /// 获取一个带查询参数的结果集
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">可变个数的参数</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql, params SQLiteParameter[] param)
        {
            DataTable dt = new DataTable();
            try
            {
                cnn.Open();
                using (var mycommand = new SQLiteCommand(cnn))
                {
                    mycommand.CommandText = sql;
                    mycommand.Parameters.AddRange(param);
                    mycommand.CommandTimeout = 180;
                    using (var reader = mycommand.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                cnn.Close();
            }
            return dt;
        }

        /// <summary>
        /// 执行不返回结果集的SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>提示信息类</returns>
        public AlertMessage ExecuteNonQuery(string sql)
        {
            var result = new AlertMessage();
            using (var conn = new SQLiteConnection(connString))
            {
                cnn.Open();
                var mytrans = cnn.BeginTransaction();
                try
                {
                    using (var mycommand = new SQLiteCommand(sql, cnn, mytrans))
                    {
                        mycommand.CommandTimeout = 180;
                        mycommand.ExecuteNonQuery();
                        mytrans.Commit();
                        result.IsSuccess = true;
                    }
                }
                catch (Exception e)
                {
                    mytrans.Rollback();
                    result.IsSuccess = false;
                    result.AddMsg(e.Message);
                }
            }

            return result;
        }

        /// <summary>
        /// 执行不返回结果集带参数的SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="param">可变个数的参数</param>
        /// <returns>提示信息类</returns>
        public AlertMessage ExecuteNonQuery(string sql, params SQLiteParameter[] param)
        {
            var result = new AlertMessage();
            using (var conn = new SQLiteConnection(connString))
            {
                cnn.Open();
                var mytrans = cnn.BeginTransaction();
                try
                {
                    using (var mycommand = new SQLiteCommand(sql, cnn, mytrans))
                    {
                        mycommand.CommandTimeout = 180;
                        mycommand.Parameters.AddRange(param);
                        mycommand.ExecuteNonQuery();
                        mytrans.Commit();
                        result.IsSuccess = true;
                    }
                }
                catch (Exception e)
                {
                    mytrans.Rollback();
                    result.IsSuccess = false;
                    result.AddMsg(e.Message);
                }
            }

            return result;
        }

        /// <summary>
        /// 获取结果中第一行第一列的值
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>第一行第一列的字符串</returns>
        public string ExecuteScalar(string sql)
        {
            try
            {
                cnn.Open();
                using (var mycommand = new SQLiteCommand(sql, cnn))
                {
                    object value = mycommand.ExecuteScalar();
                    if (value != null)
                    {
                        return value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return string.Empty;
        }
    }
}