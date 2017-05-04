using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.DataAccess.EZMssql.Works.Bigsail
{
    internal class Honor3SuperviseContext : DbContext
    {
        public Honor3SuperviseContext() : base("name=WorksBigsailHonor3Supervise")
        {
        }
    }
}
