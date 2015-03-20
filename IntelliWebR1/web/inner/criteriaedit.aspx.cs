using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web.inner
{
    public partial class criteriaedit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               
                string _Scripts = "";
                if (Request.QueryString["c"] != null)
                {
                    _Scripts = _Scripts + "\n" + "<script type=\"text/javascript\">var _editCriteria = \"" + Request.QueryString["c"].ToString() + "\";</script>";
                }
                

                List<string> _LoadMessages = new List<string>();

                List<string> _LoadScripts = new List<string>();
                _LoadScripts.Add("scripts\\js_fun");
                _LoadScripts.Add("web\\js\\criteriaquestions");

                _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadScripts.ToArray(), _LoadMessages.ToArray(), true);


                List<string> _LoadCss = new List<string>();
                _LoadCss.Add("web\\css\\criteria");
                _LoadCss.Add("web\\css\\master");
                _Scripts = _Scripts + "\n" + Helper.LoadCSS(_LoadCss.ToArray());

                

                ltScripts.Text = _Scripts;


            }
            catch (Exception)
            {

            }
        }
    }
}