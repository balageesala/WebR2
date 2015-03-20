using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.inner
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string _Scripts = "";
                List<string> _LoadMessages = new List<string>();
                _LoadMessages.Add("LOGIN");
                List<string> _LoadScripts = new List<string>();
                _LoadScripts.Add("scripts\\js_fun");
                _LoadScripts.Add("scripts\\login");
                _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadScripts.ToArray(), _LoadMessages.ToArray(), true);
                ltScripts.Text = _Scripts;

                if (!Request.IsAuthenticated)
                {
                    HttpCookie ck = Request.Cookies[FormsAuthentication.FormsCookieName];

                    if (ck != null)
                    {
                        FormsAuthenticationTicket oldTicket = FormsAuthentication.Decrypt(ck.Value);
                        var _userTecket = oldTicket.UserData;
                    }
                }
            }
        }
    }
}