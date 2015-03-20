using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web.inner
{
    public partial class profilephotos : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    string _Scripts = "";

                    List<string> _LoadMessages = new List<string>();

                    List<string> _LoadJs = new List<string>();
                    _LoadJs.Add("Scripts\\underscore");
                    _LoadJs.Add("Scripts\\IntelliPin");
                    _LoadJs.Add("Scripts\\js_fun");
                    _LoadJs.Add("web\\js\\profilephotos");

                    _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadJs.ToArray(), _LoadMessages.ToArray(), true);
                    ltScripts.Text = _Scripts;
                }
            }
            catch (Exception)
            {

            }
        }
    }
}