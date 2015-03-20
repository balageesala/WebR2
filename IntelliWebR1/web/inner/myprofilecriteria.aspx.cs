using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntellidateR1Web.web.inner
{
    public partial class myprofilecriteria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string _Scripts = "";

                List<string> _LoadCss = new List<string>();
                _LoadCss.Add("css\\intelliwindow");
                _LoadCss.Add("css\\profile");
                //_LoadCss.Add("web\\css\\intellidate");


                _Scripts = _Scripts + "\n" + Helper.LoadCSS(_LoadCss.ToArray());

                List<string> _LoadJs = new List<string>();
                _LoadJs.Add("web\\js\\criteriaquestions");
                _LoadJs.Add("Scripts\\intelliwindow");
                _LoadJs.Add("web\\js\\myprofilecriteria");
                _LoadJs.Add("Scripts\\js_fun");

                _Scripts = _Scripts + "\n" + Helper.LoadCSS(_LoadCss.ToArray());
                _Scripts = _Scripts + Helper.LoadScripts(_LoadJs.ToArray(), new List<string>().ToArray(), true);

                ltScripts.Text = _Scripts;
            }
        }
    }
}