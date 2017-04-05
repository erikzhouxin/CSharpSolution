using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.OAuth2ApiSI
{
    public class OAuthSymmetricCryptoKey
    {
        public Int64 ID { get; set; }

        public string Bucket { get; set; }

        public string Handle { get; set; }

        public byte[] Secret { get; set; }

        public DateTime ExpiresUtc { get; set; }
    }
}
