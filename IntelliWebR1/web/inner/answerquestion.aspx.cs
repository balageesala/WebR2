using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web.inner
{
    public partial class answerquestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

              

                string _Scripts = "";

                List<string> _LoadCss = new List<string>();
                _LoadCss.Add("web\\css\\rating");
                _LoadCss.Add("web\\css\\questionspopup");
                _Scripts = _Scripts + Helper.LoadCSS(_LoadCss.ToArray());
                List<string> _LoadJs = new List<string>();

                _LoadJs.Add("web\\js\\jquery.barrating");
                _LoadJs.Add("Scripts\\js_fun");
             
                // _Scripts = _Scripts + "\n" + Helper.LoadCSS(_LoadCss.ToArray());
                _Scripts = _Scripts + Helper.LoadScripts(_LoadJs.ToArray(), new List<string>().ToArray(), true);

                ltScripts.Text = _Scripts;
            }
        }
    }
}