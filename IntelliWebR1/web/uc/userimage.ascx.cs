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
    public partial class userimage : System.Web.UI.UserControl
    {
        public int UserID { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (UserID != null)
                {
                    string ImageUrl = string.Empty;
                    string SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
                    TempUser _GetUser = new TempUser().GetUserDetails(UserID);
                    if (_GetUser != null)
                    {
                        if (_GetUser.ProfilePhoto != null)
                        {
                            userPicture.Src = new Utils().GetPhotoPCTPath(_GetUser.ProfilePhoto.PhotoID, Request);
                        }
                        else
                        {
                            if (_GetUser.Gender == 1)
                            {
                                userPicture.Src = SitePath + "web/images/M.png";
                            }
                            else
                            {
                                userPicture.Src = SitePath + "web/images/F.png";
                            }
                        }
                    }
                }
            }
        }
    }
}