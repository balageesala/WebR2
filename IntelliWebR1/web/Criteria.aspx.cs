using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web
{
    public partial class Criteria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                List<string> _LoadJs = new List<string>();
                _LoadJs.Add("web\\js\\criteriaquestions");
                
                var _currentCriteria = "";
                if (Session["CriteriaPosition"] != null)
                {
                    _currentCriteria = Session["CriteriaPosition"].ToString();
                }

                string _Scripts = "";
                _Scripts = "<script type=\"text/javascript\">var _currentCriteria=\"" + _currentCriteria + "\"; </script>";
                _Scripts = _Scripts + Helper.LoadScripts(_LoadJs.ToArray(), new List<string>().ToArray(), false);
                ltScripts.Text = _Scripts;
            }
        }
    }
}