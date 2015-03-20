using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web.inner
{
    public partial class chatwindow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string _Scripts = "";
                List<string> _LoadMessages = new List<string>();
                List<string> _LoadCss = new List<string>();
                _LoadCss.Add("web\\css\\chatwindow");

                _Scripts = _Scripts + "\n" + Helper.LoadCSS(_LoadCss.ToArray());
                ltScripts.Text = _Scripts;
            }
        }
    }
}