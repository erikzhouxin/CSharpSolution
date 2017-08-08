using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famliy.Finance.Models;
using System.Data.Entity;

namespace Famliy.Finance.BLL
{
    public partial class BankAccountService2 : BaseService<bank_account>
    {
        public static readonly BankAccountService2 Instance = new BankAccountService2();

        BankModel db = null;
        public BankAccountService2()
        {
            if (db == null)
            {
                db = base.DbContext;
            }
        }

        public BankAccountService2(DbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// 家庭成员资金帐号列表
        /// </summary>
        /// <param name="user_name"></param>
        /// <returns></returns>
        public IQueryable<bank_account> FindBankAccountByUsers(string user_name)
        {
            IQueryable<bank_account> result = null;
            if (!string.IsNullOrEmpty(user_name))
            {
                result = db.bank_accounts.Where(f => f.user_name == user_name);
            }
            return result;
        }
        public Dictionary<string, bank_account> FindBankAccountDictByUsers(string[] names)
        {
            Dictionary<string, bank_account> result = new Dictionary<string, bank_account>();
            if (names.Length > 0)
            {
                var list = db.bank_accounts.Where(f => names.Contains(f.user_name)).OrderBy(f => f.user_name);
                foreach (var item in list)
                {
                    result.Add(item.user_name, item);
                }
            }
            return result;
        }
        /// <summary>
        /// 家庭成员资金帐号列表
        /// </summary>
        /// <param name="user_name"></param>
        /// <returns></returns>
        public IQueryable<bank_operate_log> FindBankOperateLogByUserArray(string[] names,int pageSize)
        {
            IQueryable<bank_operate_log> result = null;
            if (names.Length > 0)
            {
                result = db.bank_operate_logs.Where(f => names.Contains(f.user_name)).OrderByDescending(f => f.create_date).Take(pageSize);
            }
            return result;
        }

        public IQueryable<bank_operate_log> FindBankOperateLogByUser(string user_name)
        {
            IQueryable<bank_operate_log> result = null;
            if (!string.IsNullOrEmpty(user_name))
            {
                result = db.bank_operate_logs.Where(f => f.user_name == user_name).OrderByDescending(f => f.create_date);
            }
            return result;
        }      

        public IQueryable<sys_user> FindSysUserById(long user_id)
        {
            IQueryable<sys_user> result = null;
            if (user_id >= 0)
            {
                result = db.sys_users.Where(f => f.user_id == user_id);
            }
            return result;
        }
        public IQueryable<sys_user> FindSysUserByName(string user_name)
        {
            IQueryable<sys_user> result = null;
            if (!string.IsNullOrEmpty(user_name))
            {
                result = db.sys_users.Where(f => f.user_name == user_name);
            }
            return result;
        }
    }
}
