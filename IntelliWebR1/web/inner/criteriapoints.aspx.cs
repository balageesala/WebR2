using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web.inner
{
    public partial class criteriapoints : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string _Scripts = "";

            List<string> _LoadCss = new List<string>();
            _LoadCss.Add("css\\intelliwindow");
            _Scripts = _Scripts + "\n" + Helper.LoadCSS(_LoadCss.ToArray());

            List<string> _LoadJs = new List<string>();
            _LoadJs.Add("web\\js\\criteriaquestions");
            _LoadJs.Add("web\\js\\criteriapoints");
            _LoadJs.Add("Scripts\\intelliwindow");

            _Scripts = _Scripts + Helper.LoadScripts(_LoadJs.ToArray(), new List<string>().ToArray(), false);
            ltScripts.Text = _Scripts;
        }
    }
}