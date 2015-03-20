using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntellidateR1;
using System.Configuration;

namespace IntelliWebR1.web.inner
{
    public partial class reportprofile : System.Web.UI.Page
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
                    _LoadJs.Add("Scripts\\js_fun");
                    _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadJs.ToArray(), _LoadMessages.ToArray(), true);
                    ltScripts.Text = _Scripts;
                    if (Request.QueryString["uid"] != null)
                    {
                        int _OtherUserID = Convert.ToInt32(Request.QueryString["uid"]);
                        LoadUserPicture(_OtherUserID);
                    }
                }
                catch (Exception)
                {

                }
            }


        }


        private void LoadUserPicture(int OtherUserID)
        {
            try
            {
                string SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
                TempUser _GetOtherUser = new TempUser().GetUserDetails(OtherUserID);
                if (_GetOtherUser.ProfilePhoto != null)
                {
                    imgPhoto.Src = new Utils().GetPhotoPCTPath(_GetOtherUser.ProfilePhoto.PhotoID, Page.Request);
                }
                else
                {
                    if (_GetOtherUser.Gender == 1)
                    {
                        imgPhoto.Src = SitePath + "web/images/M.png";
                    }
                    else
                    {
                        imgPhoto.Src = SitePath + "web/images/F.png";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}