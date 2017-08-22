using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EZOper.CSharpSolution.WebUI.WebForm.Alipayment
{
    public partial class result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Text"] != null)
                {
                    Response.Write(Request.QueryString["Text"].ToString());
                }
            }

        }
    }
}