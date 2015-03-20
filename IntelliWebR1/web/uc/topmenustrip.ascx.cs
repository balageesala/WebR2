using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using IntellidateR1;

namespace IntellidateR1Web.web.uc
{
    public partial class topmenustrip : System.Web.UI.UserControl
    {
        public bool ShowAllItems { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (ShowAllItems)
                {
                    divAllItems.Visible = true;
                    divOnlyLogOut.Visible = false;
                }
                else
                {
                    divAllItems.Visible = false;
                    divOnlyLogOut.Visible = true;
                }

                string _Scripts = "";
                List<string> _LoadMessages = new List<string>();
                List<string> _LoadJs = new List<string>();
                _LoadJs.Add("web\\js\\topmenustrip");
                
                _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadJs.ToArray(), _LoadMessages.ToArray(), true);
                ltScripts.Text = _Scripts;
                //SetAllItemValues();

                LoadUserPhoto();
            }
        }

        private void SetAllItemValues()
        {
            try
            {
                 int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                 var _GetRecivedMessages = new ConversationSnapShot().GetUserReceivedConversationSnapshot(UserID);
                 int _recivedMessagesCiunt = _GetRecivedMessages.Where(x => x.LastConversation.HasRecipientSeen == false && x.LastConversation.IsDeletedByRecipient==false).ToArray().Count();
                 if (_recivedMessagesCiunt > 0)
                 {
                   //  lblMsgs.Visible = true;
                   //  lblMsgs.InnerText = _recivedMessagesCiunt.ToString();
                 }
                 else
                 {
                  //   lblMsgs.Visible = false;
                 }
                 
               //lblNotifications.InnerText = "4";
               
            }
            catch (Exception)
            {
                
            }
        }

        private void LoadUserPhoto()
        {
            try
            {
                string SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                User UserDetails = new User().GetUserDetails(UserID);

                if (UserDetails.ProfilePhoto != null)
                {
                    //imgUserIcon.Visible = true;

                    imgUserIcon.Src = new Utils().GetPhotoPCTPath(UserDetails.ProfilePhoto.PhotoID, Page.Request);
                }
                else
                {
                    //imgUserIcon.Visible = false;
                    if (UserDetails.Gender == 1)
                    {
                        imgUserIcon.Src = SitePath + "web/images/M.png";
                    }
                    else
                    {
                        imgUserIcon.Src = SitePath + "web/images/F.png";
                    }
                }

                //hide and show subscribe image

                if (UserDetails.IsUserSubscribed)
                {
                    lnkSubscribe.Visible = false;
                }
                else
                {
                    lnkSubscribe.Visible = true;
                }
            }
            catch (Exception)
            {

            }
        }
    }
}