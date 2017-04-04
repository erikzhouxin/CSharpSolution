using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.OAuth2ApiSI
{
    public class OAuthClient
    {
        public Int64 ID { get; set; }

        public string Client { get; set; }

        public string Secret { get; set; }

        public string Callback { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public DateTime Time { get; set; }
    }
}
