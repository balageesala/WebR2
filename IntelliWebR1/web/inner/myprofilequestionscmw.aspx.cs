using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace IntelliWebR1.web.inner
{
    public partial class myprofilequestionscmw : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                List<string> _LoadCss = new List<string>();

                List<string> _LoadJs = new List<string>();
                _LoadJs.Add("web\\js\\questions");


                string _Scripts = "";

                _Scripts = _Scripts + Helper.LoadScripts(_LoadJs.ToArray(), new List<string>().ToArray(), true);
                ltScripts.Text = _Scripts;

            }
        }
    }
}