﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using EZOper.NetSiteUtilities.Wepayment;

namespace EZOper.CSharpSolution.WebUI.WebForm.Wepayment
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WxPayLog.Info(this.GetType().ToString(), "page load");
        }
    }
}