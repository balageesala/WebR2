using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web.inner
{
    public partial class profilewritten : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string _Scripts = "";
                List<string> _LoadMessages = new List<string>();
                List<string> _LoadJs = new List<string>();
                _LoadJs.Add("web\\js\\profilewritten");


                List<string> _LoadCss = new List<string>();
                _LoadCss.Add("web\\css\\myprofilewritten");

                _Scripts = _Scripts + "\n" + Helper.LoadCSS(_LoadCss.ToArray());
                _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadJs.ToArray(), _LoadMessages.ToArray(), false);
                ltScripts.Text = _Scripts;
            }
        }
    }
}