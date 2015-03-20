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

    }
}