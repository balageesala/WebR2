using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web.uc
{
    public partial class headermenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    LoadUserPhoto();
                    SetAllItemValues();
                }
                catch (Exception ex)
                {
                    IntellidateR1.Error.LogError(ex, "headermenu Page_Load");
                }
            }

        }

        private void LoadUserPhoto()
        {
            try
            {
                string SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                User UserDetails = new User().GetUserDetails(UserID);
                profilePercentage.InnerText = new ProfileCompletion().GetTotalProfileCompletion(UserID).ToString() +"%";
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
            catch (Exception ex)
            {
                IntellidateR1.Error.LogError(ex, "headermenu LoadUserPhoto");
            }
        }



        private void SetAllItemValues()
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                var _GetRecivedMessages = new ConversationSnapShot().GetUserReceivedConversationSnapshot(UserID);
                int _recivedMessagesCiunt = _GetRecivedMessages.Where(x => x.LastConversation.HasRecipientSeen == false && x.LastConversation.IsDeletedByRecipient == false).ToArray().Count();
                if (_recivedMessagesCiunt > 0)
                {
                    lblMsgsCount.Visible = true;
                    lblMsgsCount.InnerText = _recivedMessagesCiunt.ToString();
                }
                else
                {
                    lblMsgsCount.Visible = false;
                }

                int _TotalCount = new IntellidateR1.Notifications().GetUnViewedNotificationsCount(UserID);

                if (_TotalCount > 0)
                {
                    lblNotisCount.Visible = true;
                    lblNotisCount.InnerText = _TotalCount.ToString();
                }
                else
                {
                    lblNotisCount.Visible = false;
                }

            }
            catch (Exception)
            {

            }
        }


    }
}