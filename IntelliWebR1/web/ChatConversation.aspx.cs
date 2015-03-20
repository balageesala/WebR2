using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web
{
    public partial class ChatConversation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("Messages");
                }
                else
                {
                    string _OtherUserID = Request.QueryString["id"].ToString();
                    string _Scripts = "";
                    _Scripts = _Scripts + "<script type=\"text/javascript\">var _OtherUserID=\"" + _OtherUserID + "\";</script>";
                    List<string> _LoadMessages = new List<string>();
                    List<string> _LoadJs = new List<string>();
                    _LoadJs.Add("web\\js\\chatconversationview");
                    _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadJs.ToArray(), _LoadMessages.ToArray(), false);
                    ltScripts.Text = _Scripts;
                }
            }
        }
    }
}