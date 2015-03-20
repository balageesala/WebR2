﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntellidateR1Web.web.uc
{
    public partial class viewedmemenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string _Scripts = "";
            List<string> _LoadMessages = new List<string>();
            List<string> _LoadJs = new List<string>();
            _LoadJs.Add("web\\js\\viewedmemenu");

            _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadJs.ToArray(), _LoadMessages.ToArray(), true);
            ltScripts.Text = _Scripts;
        }
    }
}