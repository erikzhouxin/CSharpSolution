using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using FirebirdSql.Data.FirebirdClient;

namespace EZOper.TechTester.DataAccess
{
    public class FirebirdHelper
    {
        /// <summary>
        /// WebConfig中connectionStrings配置
        /// <add name="EZOper.TechTester.OAuth.sqlite3" connectionString="Data Source=|DataDirectory|\SQLite\EZOper.TechTester.OAuth.sqlite3" providerName="System.Data.SQLite" />
        /// </summary>
        internal static readonly string EZOper_TechTester_Firebird_Fdb = ConfigurationManager.ConnectionStrings["EZOper.TechTester.Firebird.Fdb"].ConnectionString;

        string connString;
        FbConnection cnn;

        public FirebirdHelper()
        {
            connString = EZOper_TechTester_Firebird_Fdb;
        }

        public FirebirdHelper(string dbConnStr)
        {
            connString = dbConnStr;
            cnn = new FbConnection(connString);
        }

        /// <summary>
        /// Single Param Constructor for specifying advanced connection options.
        /// </summary>
        /// <param name="connectionOpts">A dictionary containing all desired options and their values</param>
        public FirebirdHelper(Dictionary<string, string> connectionOpts)
        {
            string str = "";
            foreach (var param in connectionOpts)
            {
                str += string.Format("{0}={1}; ", param.Key, param.Value);
            }
            connString = str;
            cnn = new FbConnection(connString);
        }

        /// <summary>
        /// Allows the programmer to run a query against the Database.
        /// </summary>
        /// <param name="sql">The SQL to run</param>
        /// <returns>A DataTable containing the result set.</returns>
        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                cnn.Open();
                var mycommand = new FbCommand(sql, cnn);
                mycommand.CommandText = sql;
                var reader = mycommand.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                cnn.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdparams"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql, IList<FbParameter> cmdparams)
        {
            DataTable dt = new DataTable();
            try
            {
                cnn.Open();
                var mycommand = new FbCommand(sql, cnn);
                mycommand.CommandText = sql;
                mycommand.Parameters.AddRange(cmdparams.ToArray());
                mycommand.CommandTimeout = 180;
                var reader = mycommand.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                cnn.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dt;
        }

        /// <summary>
        /// Allows the programmer to interact with the database for purposes other than a query.
        /// </summary>
        /// <param name="sql">The SQL to be run.</param>
        /// <returns>An Integer containing the number of rows updated.</returns>
        public bool ExecuteNonQuery(string sql)
        {
            bool successState = false;
            cnn.Open();
            using (FbTransaction mytrans = cnn.BeginTransaction())
            {
                var mycommand = new FbCommand(sql, cnn);
                try
                {
                    mycommand.CommandTimeout = 180;
                    mycommand.ExecuteNonQuery();
                    mytrans.Commit();
                    successState = true;
                    cnn.Close();
                }
                catch (Exception e)
                {
                    mytrans.Rollback();
                }
                finally
                {
                    mycommand.Dispose();
                    cnn.Close();
                }
            }
            return successState;
        }

        /// <summary>
        /// Allows the programmer to interact with the database for purposes other than a query.
        /// </summary>
        /// <param name="sql">The SQL to be run.</param>
        /// <param name="cmdparams">The Cmd Parameter Of SQL</param>
        /// <returns></returns>
        public bool ExecuteNonQuery(string sql, IList<FbParameter> cmdparams)
        {
            bool successState = false;
            cnn.Open();
            using (var mytrans = cnn.BeginTransaction())
            {
                var mycommand = new FbCommand(sql, cnn, mytrans);
                try
                {
                    mycommand.Parameters.AddRange(cmdparams.ToArray());
                    mycommand.CommandTimeout = 180;
                    mycommand.ExecuteNonQuery();
                    mytrans.Commit();
                    successState = true;
                    cnn.Close();
                }
                catch (Exception e)
                {
                    mytrans.Rollback();
                    throw e;
                }
                finally
                {
                    mycommand.Dispose();
                    cnn.Close();
                }

            }
            return successState;
        }

        /// <summary>
        /// Allows the programmer to retrieve single items from the DB.
        /// </summary>
        /// <param name="sql">The query to run.</param>
        /// <returns>A string.</returns>
        public string ExecuteScalar(string sql)
        {
            cnn.Open();
            var mycommand = new FbCommand(sql, cnn);
            mycommand.CommandText = sql;
            object value = mycommand.ExecuteScalar();
            cnn.Close();
            if (value != null)
            {
                return value.ToString();
            }
            return "";
        }

        /// <summary>
        /// Allows the programmer to easily update rows in the DB.
        /// </summary>
        /// <param name="tableName">The table to update.</param>
        /// <param name="data">A dictionary containing Column names and their new values.</param>
        /// <param name="where">The where clause for the update statement.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public bool Update(String tableName, Dictionary<String, String> data, String where)
        {
            String vals = "";
            Boolean returnCode = true;
            if (data.Count >= 1)
            {
                foreach (KeyValuePair<String, String> val in data)
                {
                    vals += String.Format(" {0} = '{1}',", val.Key.ToString(), val.Value.ToString());
                }
                vals = vals.Substring(0, vals.Length - 1);
            }
            try
            {
                this.ExecuteNonQuery(String.Format("update {0} set {1} where {2};", tableName, vals, where));
            }
            catch
            {
                returnCode = false;
            }
            return returnCode;
        }
    }
}