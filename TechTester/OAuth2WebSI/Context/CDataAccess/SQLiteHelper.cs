using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Configuration;

namespace EZOper.TechTester.OAuth2ApiSI
{
    internal class SQLiteHelper
    {
        /// <summary>
        /// WebConfig中connectionStrings配置
        /// <add name="EZOper.TechTester.OAuth.sqlite3" connectionString="Data Source=|DataDirectory|\SQLite\EZOper.TechTester.OAuth.sqlite3" providerName="System.Data.SQLite" />
        /// </summary>
        internal static readonly string EZOper_TechTester_OAuth_Sqlite3 = ConfigurationManager.ConnectionStrings["EZOper.TechTester.OAuth.sqlite3"].ConnectionString;

        private string _connStr;
        private SQLiteConnection _conn;

        /// <summary>
        /// 使用WebConfig配置初始化
        /// </summary>
        public SQLiteHelper()
            : this(EZOper_TechTester_OAuth_Sqlite3)
        { }

        /// <summary>
        /// 使用SQLite连接字符串创建类初始化
        /// </summary>
        /// <param name="builder">连接字符串创建类</param>
        public SQLiteHelper(SQLiteConnectionStringBuilder builder)
            : this(builder.ConnectionString)
        { }

        /// <summary>
        /// 使用SQLite连接字符串初始化
        /// </summary>
        /// <param name="dbConnStr">数据库连接字符串</param>
        public SQLiteHelper(string dbConnStr)
        {
            _connStr = dbConnStr;
            _conn = new SQLiteConnection(_connStr);
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
            _connStr = str;
            _conn = new SQLiteConnection(_connStr);
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
                _conn.Open();
                using (var cmd = new SQLiteCommand(_conn))
                {
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
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
                _conn.Close();
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
                _conn.Open();
                using (var cmd = new SQLiteCommand(_conn))
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(param);
                    cmd.CommandTimeout = 180;
                    using (var reader = cmd.ExecuteReader())
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
                _conn.Close();
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
            _conn.Open();
            var trans = _conn.BeginTransaction();
            try
            {
                using (var cmd = new SQLiteCommand(sql, _conn, trans))
                {
                    cmd.CommandTimeout = 180;
                    cmd.ExecuteNonQuery();
                    trans.Commit();
                    result.IsSuccess = true;
                }
            }
            catch (Exception e)
            {
                trans.Rollback();
                result.IsSuccess = false;
                result.AddMsg(e.Message);
            }
            finally
            {
                _conn.Close();
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
            _conn.Open();
            var trans = _conn.BeginTransaction();
            try
            {
                using (var mycommand = new SQLiteCommand(sql, _conn, trans))
                {
                    mycommand.CommandTimeout = 180;
                    mycommand.Parameters.AddRange(param);
                    mycommand.ExecuteNonQuery();
                    trans.Commit();
                    result.IsSuccess = true;
                }
            }
            catch (Exception e)
            {
                trans.Rollback();
                result.IsSuccess = false;
                result.AddMsg(e.Message);
            }
            finally
            {
                _conn.Close();
            }

            return result;
        }

        /// <summary>
        /// 执行不返回结果集的SQL语句影响的行数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>影响的行数提示信息类</returns>
        public AlertMsgDbRowsEffect ExecNonQuery(string sql)
        {
            var result = new AlertMsgDbRowsEffect();
            _conn.Open();
            var trans = _conn.BeginTransaction();
            try
            {
                using (var cmd = new SQLiteCommand(sql, _conn, trans))
                {
                    cmd.CommandTimeout = 180;
                    result.EffectLines = cmd.ExecuteNonQuery();
                    trans.Commit();
                    result.IsSuccess = true;
                    return result;
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
                result.EffectLines = -1;
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
            finally
            {
                _conn.Close();
            }
        }

        /// <summary>
        /// 执行不返回结果集带参数的SQL语句影响的行数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="param">可变个数的参数</param>
        /// <returns>影响行数提示信息类</returns>
        public AlertMsgDbRowsEffect ExecNonQuery(string sql, params SQLiteParameter[] param)
        {
            var result = new AlertMsgDbRowsEffect();
            _conn.Open();
            var trans = _conn.BeginTransaction();
            try
            {
                using (var mycommand = new SQLiteCommand(sql, _conn, trans))
                {
                    mycommand.CommandTimeout = 180;
                    mycommand.Parameters.AddRange(param);
                    result .EffectLines = mycommand.ExecuteNonQuery();
                    trans.Commit();
                    result.IsSuccess = true;
                    return result;
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
                result.EffectLines = -1;
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
            finally
            {
                _conn.Close();
            }
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
                _conn.Open();
                using (var cmd = new SQLiteCommand(sql, _conn))
                {
                    object value = cmd.ExecuteScalar();
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
                _conn.Close();
            }
            return string.Empty;
        }
    }
}