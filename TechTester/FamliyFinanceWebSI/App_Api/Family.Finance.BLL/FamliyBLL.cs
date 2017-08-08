using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Famliy.Finance.Models;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace Famliy.Finance.BLL
{
    public class FamliyBLL
    {
        public static readonly FamliyBLL Instance = new FamliyBLL();
        private static BankModel db;
        public FamliyBLL()
        {
            if (db == null)
            {
                db = new BankModel();
            }
        }     

        public List<bank_family> Find_FamliysByUser(string user_name)
        {
            List<bank_family> list = null;
            if (!string.IsNullOrEmpty(user_name))
            {
                list = db.bank_familys.Include("sys_users")
                    .Where(f => f.sys_users.Where(u => u.user_name == user_name).ToList().Count > 0)
                    .ToList();
            }
            return list;
        }

        public async Task<List<bank_family>> Find_FamliyByUser2(string user_name)
        {
            List<bank_family> list = null;
            if (!string.IsNullOrEmpty(user_name))
            {
                await Task.Run(() =>
                {
                    list = db.bank_familys.Include("sys_users")
                   .Where(f => f.sys_users.Where(u => u.user_name == user_name).ToList().Count > 0)
                   .ToList();
                });
            }
            return list;
        }
    }
}
