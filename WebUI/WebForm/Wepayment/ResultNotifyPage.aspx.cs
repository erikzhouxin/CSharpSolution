using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using EZOper.NetSiteUtilities.Wepayment;

namespace EZOper.CSharpSolution.WebUI.WebForm.Wepayment
{
    public partial class ResultNotifyPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WxPayApiBiz.ProcessResultNotify(this);
        }       
    }
}