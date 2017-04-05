using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.OAuth2ApiSI
{
    public class OAuthNonce
    {
        public Int64 ID { get; set; }

        public string Context { get; set; }

        public string Code { get; set; }

        public DateTime Time { get; set; }
    }
}
