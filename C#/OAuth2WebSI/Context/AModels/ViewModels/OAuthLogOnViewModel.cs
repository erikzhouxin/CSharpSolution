using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.OAuth2ApiSI
{
    public class OAuthLogOnViewModel
    {
        [Required]
        [DisplayName("OpenID")]
        public string UserSuppliedIdentifier { get; set; }

        [DisplayName("Remember me?")]
        public bool RememberMe { get; set; }
    }
}
