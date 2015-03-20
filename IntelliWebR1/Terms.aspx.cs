using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1
{
    public partial class Terms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    string _Scripts = "";

                    List<string> _LoadMessages = new List<string>();

                    List<string> _LoadScripts = new List<string>();
                    _LoadScripts.Add("scripts\\js_fun");
                    _LoadScripts.Add("scripts\\default");
                    _LoadScripts.Add("scripts\\intelliwindow");

                    _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadScripts.ToArray(), _LoadMessages.ToArray(), true);


                    ltScripts.Text = _Scripts;

                }
            }
            catch (Exception)
            {

            }
        }
    }
}