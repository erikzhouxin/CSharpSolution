using EZOper.TechTester.OAuth2ApiDBH;
using EZOper.TechTester.OAuth2ApiDEMV;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace EZOper.TechTester.OAuth2ApiDAL
{
    internal class AuthDataAccess : IAuthDataAccess
    {
        public bool IsValid(LogOnViewModel model)
        {
            var helper = new SQLiteHelper();
            var accountParam = new SQLiteParameter("account", model.Account);
            var resultTable = helper.GetDataTable("SELECT Account, Salt, Password FROM Users WHERE Account=@account", accountParam);
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

        public AlertMessage Create(LogOnViewModel book)
        {
            var sql = "INSERT INTO Users VALUES(@ID,@BookName,@Price);";
            var idParam = new SQLiteParameter("ID", null);
            var bookNameParam = new SQLiteParameter("BookName", book.Account);
            var priceParam = new SQLiteParameter("Price", book.Password);
            var sqlExcute = new SQLiteHelper();
            return sqlExcute.ExecuteNonQuery(sql, idParam, bookNameParam, priceParam);
        }
        public AlertMessage Update(LogOnViewModel book)
        {
            var sql = "update Book set BookName=@BookName,Price=@Price where ID=@ID;";
            var idParam = new SQLiteParameter("ID", null);
            var bookNameParam = new SQLiteParameter("BookName", book.Account);
            var priceParam = new SQLiteParameter("Price", book.Password);
            var sqlExcute = new SQLiteHelper();
            return sqlExcute.ExecuteNonQuery(sql, idParam, bookNameParam, priceParam);
        }
        public AlertMessage Delete(int ID)
        {
            var sql = "delete from Book where ID=@ID;";
            var sqlExcute = new SQLiteHelper();
            return sqlExcute.ExecuteNonQuery(sql, new SQLiteParameter("ID", ID));
        }
        public LogOnViewModel GetbyID(int ID)
        {
            var sql = "select * from Book where ID=@ID;";
            var idParam = new SQLiteParameter("ID", ID);
            var sqlExcute = new SQLiteHelper();
            var dt = sqlExcute.GetDataTable(sql, idParam);
            if (dt.Rows.Count > 0)
            {
                LogOnViewModel book = new LogOnViewModel();
                book.Account = dt.Rows[0]["BookName"].ToString();
                book.Password = dt.Rows[0]["Price"].ToString();
                return book;
            }

            return null;
        }
    }
}