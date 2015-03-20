using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntellidateR1;

namespace IntelliWebR1.web.inner
{
    public partial class compose : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    string _Scripts = "";
                    List<string> _Loadcss = new List<string>();
                    _Loadcss.Add("web\\css\\popups");
                    _Scripts = _Scripts + "\n" + Helper.LoadCSS(_Loadcss.ToArray());

                    List<string> _LoadMessages = new List<string>();
                    List<string> _LoadJs = new List<string>();
                    _LoadJs.Add("web\\js\\compose");
                    _LoadJs.Add("Scripts\\js_fun");
                    _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadJs.ToArray(), _LoadMessages.ToArray(), true);

                    ltScripts.Text = _Scripts;



                    if (Request.QueryString["recid"] != null)
                    {
                        string _OtherUserID = Request.QueryString["recid"].ToString();
                        int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                        User m_OtherUser = new User().GetUserDetails(Convert.ToInt32(_OtherUserID));
                        divUserName.InnerHtml = m_OtherUser.LoginName;
                        if (_OtherUserID == "0")
                        {
                            divCanSend.Visible = false;
                            divCantSend.Visible = true;
                        }
                        else
                        {
                            bool _IsUserAbleToCompose = new Conversation().IsUserAbleToSendSecoundMessage(UserID, Convert.ToInt32(_OtherUserID));
                            divCanSend.Visible = _IsUserAbleToCompose;
                            divCantSend.Visible = !_IsUserAbleToCompose;
                        }
                    }
                }
                catch (Exception)
                {
                   divCanSend.Visible = false;
                   divCantSend.Visible = true;
                }
            }
        }
    }
}