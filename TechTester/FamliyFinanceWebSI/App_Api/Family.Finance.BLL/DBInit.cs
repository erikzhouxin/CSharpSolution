using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famliy.Finance.DAL;
using Famliy.Finance.Models;

namespace Famliy.Finance.BLL
{
    public class DBInit
    {
        public static readonly DBInit Instance = new DBInit();

        public void Init(BankModel bankModel)
        {
            BankModelInitializer init = new BankModelInitializer();
            init.InitializeDatabase(bankModel);
        }
    }
}
