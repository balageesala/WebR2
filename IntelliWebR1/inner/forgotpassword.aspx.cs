using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.inner
{
    public partial class forgotpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string _Scripts = "";
                List<string> _LoadMessages = new List<string>();
                _LoadMessages.Add("FORGOTPWD");
                List<string> _LoadScripts = new List<string>();
                _LoadScripts.Add("scripts\\js_fun");
                _LoadScripts.Add("scripts\\forgotpassword");
                _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadScripts.ToArray(), _LoadMessages.ToArray(), true);
                ltForgotPassword.Text = _Scripts;
            }
        }
    }
}