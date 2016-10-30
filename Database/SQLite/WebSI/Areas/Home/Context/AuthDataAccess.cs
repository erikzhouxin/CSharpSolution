using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace EZOper.TechTester.SQLiteWebSI.Areas.Home
{
    public class AuthDataAccess
    {
        public bool IsValid(LogOnViewModel model)
        {
            var helper = new SQLiteHelper();
            var param = new List<SQLiteParameter>()
            {
                new SQLiteParameter()
                {
                   ParameterName = "@account",
                   Value = model.Account,
                },
            };
            var resultTable = helper.GetDataTable("SELECT Account, Salt, Password FROM Users WHERE Account=@account", param);
            if (resultTable.Rows.Count > 0)
            {
                var account = resultTable.Rows[0]["Account"].ToString();
                var salt = resultTable.Rows[0]["Salt"].ToString();
                var password = resultTable.Rows[0]["Password"].ToString();
                var passwordModel = new UserPassword(salt, model.Password);
                return password == passwordModel.HashPassword;
            }
            return false;
        }

        public bool Create(LogOnViewModel book)
        {
            try
            {

                var sql = "INSERT INTO Users VALUES(@ID,@BookName,@Price);";
                var cmdparams = new List<SQLiteParameter>()
                {
                    new SQLiteParameter("ID", null),
                    new SQLiteParameter("BookName", book.Account),
                    new SQLiteParameter("Price", book.Password)
                };
                var sqlExcute = new SQLiteHelper();
                return sqlExcute.ExecuteNonQuery(sql, cmdparams);
            }
            catch (Exception e)
            {
                //Do any logging operation here if necessary
                throw e;
                return false;
            }
        }
        public bool Update(LogOnViewModel book)
        {
            try
            {
                var sql = "update Book set BookName=@BookName,Price=@Price where ID=@ID;";
                var cmdparams = new List<SQLiteParameter>()
                {
                    new SQLiteParameter("ID", null),
                    new SQLiteParameter("BookName", book.Account),
                    new SQLiteParameter("Price", book.Password)
                };
                var sqlExcute = new SQLiteHelper();
                return sqlExcute.ExecuteNonQuery(sql, cmdparams);
            }
            catch (Exception)
            {
                //Do any logging operation here if necessary
                return false;
            }
        }
        public bool Delete(int ID)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=e:\\test.db3"))
                {
                    conn.Open();
                    SQLiteCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "delete from Book where ID=@ID;";
                    cmd.Parameters.Add(new SQLiteParameter("ID", ID));
                    int i = cmd.ExecuteNonQuery();
                    return i == 1;
                }
            }
            catch (Exception)
            {
                //Do any logging operation here if necessary
                return false;
            }
        }
        public LogOnViewModel GetbyID(int ID)
        {
            try
            {
                var sql = "select * from Book where ID=@ID;";
                var cmdparams = new List<SQLiteParameter>()
                {
                    new SQLiteParameter("ID", ID)
                };
                var sqlExcute = new SQLiteHelper();
                var dt = sqlExcute.GetDataTable(sql, cmdparams);
                if (dt.Rows.Count > 0)
                {
                    LogOnViewModel book = new LogOnViewModel();
                    book.Account = dt.Rows[0]["BookName"].ToString();
                    book.Password = dt.Rows[0]["Price"].ToString();
                    return book;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                //Do any logging operation here if necessary
                return null;
            }
        }
    }
}