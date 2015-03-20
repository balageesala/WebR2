using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntellidateR1;
using System.Configuration;

namespace IntelliWebR1.web.uc
{
    public partial class otheruserpic : System.Web.UI.UserControl
    {
        public int OtherUserID { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
                User OtherUser = new User().GetUserDetails(OtherUserID);
                if (OtherUser != null)
                {
                    lblOtherUserName.InnerHtml = OtherUser.LoginName;
                    if (OtherUser.ProfilePhoto != null)
                    {
                        imgOtherProfilePic.Src = new Utils().GetPhotoPCTPath(OtherUser.ProfilePhoto.PhotoID, Page.Request);
                    }
                    else
                    {
                        if (OtherUser.Gender == 1)
                        {
                            imgOtherProfilePic.Src = SitePath + "web/images/M.png";
                        }
                        else
                        {
                            imgOtherProfilePic.Src = SitePath + "web/images/F.png";
                        }
                    }
                }
            }
        }
    }
}