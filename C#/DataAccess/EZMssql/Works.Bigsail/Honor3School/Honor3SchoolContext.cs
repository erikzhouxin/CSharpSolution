using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.DataAccess.EZMssql.Works.Bigsail
{
    internal class Honor3SchoolContext : DbContext
    {
        public Honor3SchoolContext()
            : base("name=WorksBigsailHonor3School")
        {

        }
    }
}
