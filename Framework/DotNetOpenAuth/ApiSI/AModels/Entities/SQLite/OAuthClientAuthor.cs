using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.OAuth2ApiSI
{
    public class OAuthClientAuthor
    {
        public long UserID { get; set; }
        public long ClientID { get; set; }
        public string Scope { get; set; }
        public DateTime ExpireUtc { get; set; }
        public DateTime Time { get; set; }
    }
}
