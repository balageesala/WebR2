using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web.inner
{
    public partial class photopopup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    List<string> _LoadCss = new List<string>();
                    _LoadCss.Add("web\\css\\popups");
                    string _Scripts = "";
                    List<string> _LoadMessages = new List<string>();
                    List<string> _LoadJs = new List<string>();
                    _LoadJs.Add("Scripts\\js_fun");
                    _Scripts = _Scripts + Helper.LoadCSS(_LoadCss.ToArray());
                    _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadJs.ToArray(), _LoadMessages.ToArray(), true);
                    ltScripts.Text = _Scripts;
                }
                catch (Exception)
                {

                }
            }
        }
    }
}