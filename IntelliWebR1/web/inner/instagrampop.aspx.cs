using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web.inner
{
    public partial class instagrampop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                string _Scripts = "";
                List<string> _Loadcss = new List<string>();
                _Loadcss.Add("web\\css\\intellidate");
                _Scripts = _Scripts + "\n" + Helper.LoadCSS(_Loadcss.ToArray());

                List<string> _LoadMessages = new List<string>();
                List<string> _LoadJs = new List<string>();
                _LoadJs.Add("Scripts\\js_fun");
                _LoadJs.Add("web\\js\\addphotos\\oauth");
                _LoadJs.Add("web\\js\\addphotos\\instafeed");
                _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadJs.ToArray(), _LoadMessages.ToArray(), true);

                ltScripts.Text = _Scripts;
            }
        }
    }
}