using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using IntellidateR1;

namespace IntellidateR1Web.web.inner
{
    public partial class todaymatch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //string _Scripts = "";

                //List<string> _LoadJs = new List<string>();
                //_LoadJs.Add("web\\js\\load-image.min");
                //_Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadJs.ToArray(), new List<string>().ToArray(), false);
                //ltScripts.Text = _Scripts;
                ////re set matchp
                //GetTodaysMatch();
               
            }
        }

       



        
    }
}