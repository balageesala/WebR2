using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntellidateR1;

namespace IntelliWebR1.web.uc
{
    public partial class userphoto : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadUserPhoto();
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
                    imgProfile.Visible = true;
                    imgProfile.Src = SitePath + "web/service/PhotoView?c=y&pid=" + UserDetails.ProfilePhoto.PhotoID.ToString();
                }
                else
                {
                   if(UserDetails.Gender==1){
                       imgProfile.Src = SitePath + "web/images/M.png";
                   }
                   else
                   {
                       imgProfile.Src = SitePath + "web/images/F.png";
                   }
                }
                lblUserName.InnerText = UserDetails.LoginName;
            }
            catch (Exception)
            {

            }
        }
    }
}