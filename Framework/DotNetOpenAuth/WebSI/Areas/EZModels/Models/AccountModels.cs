using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EZOper.TechTester.OAuth2WebSI.Areas.EZModels
{
    public class LogOnModel
    {
        [Required]
        [DisplayName("OpenID")]
        public string UserSuppliedIdentifier { get; set; }

        [DisplayName("Remember me?")]
        public bool RememberMe { get; set; }
    }
}
