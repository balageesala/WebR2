using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web.inner
{
    public partial class messagepassport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["uid"] != null)
                {
                    try
                    {
                        int _OtherUserID = Convert.ToInt32(Request.QueryString["uid"]);
                        string _Scripts = "";
                        List<string> _LoadCss = new List<string>();
                        _LoadCss.Add("web\\css\\messagespassport");
                        _Scripts = _Scripts + "\n" + Helper.LoadCSS(_LoadCss.ToArray());
                    }
                    catch (Exception)
                    {

                    }
                }


            }
        }


        

    }
}