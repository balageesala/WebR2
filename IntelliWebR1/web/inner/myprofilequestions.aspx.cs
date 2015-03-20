using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web.inner
{
    public partial class myprofilequestions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {

                    List<string> _LoadCss = new List<string>();
                    
                    List<string> _LoadJs = new List<string>();
                    _LoadJs.Add("web\\js\\questions");
                    _LoadJs.Add("web\\js\\jquery.barrating");
                   // _LoadJs.Add("Scripts\\js_fun");
                    _LoadCss.Add("web\\css\\rating");
                    string _Scripts = "";
                    _Scripts = _Scripts + Helper.LoadCSS(_LoadCss.ToArray());
                    _Scripts = _Scripts + Helper.LoadScripts(_LoadJs.ToArray(), new List<string>().ToArray(), false);
                    ltScripts.Text = _Scripts;
                }
            }
            catch (Exception)
            {

            }
        }
    }
}