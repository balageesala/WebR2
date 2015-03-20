using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web.inner
{
    public partial class profilequestionsfilter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<string> _LoadCss = new List<string>();
                List<string> _LoadJs = new List<string>();
                _LoadCss.Add("web\\css\\popups");
                string _Scripts = "";
                _Scripts = _Scripts + Helper.LoadCSS(_LoadCss.ToArray());
                //   _Scripts = _Scripts + Helper.LoadScripts(_LoadJs.ToArray(), new List<string>().ToArray(), false);
                ltScripts.Text = _Scripts;
            }
        }
    }
}