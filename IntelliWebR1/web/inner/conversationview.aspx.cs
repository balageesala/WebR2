using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace IntelliWebR1.web.inner
{
    public partial class conversationview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string _Scripts = "";
                List<string> _LoadMessages = new List<string>();
                List<string> _LoadJs = new List<string>();
                _LoadJs.Add("web\\js\\conversationview");
              
                //if (Request.QueryString["id"] != null)
                //{
                //    int _otherUserID = Convert.ToInt32(Request.QueryString["id"]);
                //    int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                //    Conversation[] _Conversations = new Conversation().GetConversation(_UserID, _otherUserID);
                //    //string _ConvData = JsonConvert.SerializeObject(_Conversations);
                //    _Scripts = _Scripts + "\n" + "<script type=\"text/javascript\">var _ConvData =\"" + _Conversations.ToString() + "\"</script>";
                        
                //}

                _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadJs.ToArray(), _LoadMessages.ToArray(), false);


                ltScripts.Text = _Scripts;
            }
        }
    }
}