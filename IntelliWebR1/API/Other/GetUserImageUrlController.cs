using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntelliWebR1.API
{
    public class GetUserImageUrlController : ApiController
    {
        public string Post([FromBody]UserPictureCls _UserObj)
        {
            try
            {
                if (_UserObj != null)
                {
                    string ImageUrl = string.Empty;
                    string SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
                    TempUser _GetUser = new TempUser().GetUserDetails(_UserObj.UserID);
                    if (_GetUser != null)
                    {
                        if (_GetUser.ProfilePhoto != null)
                        {
                            ImageUrl = new Utils().GetSmallPPCTPath(_GetUser.ProfilePhoto.PhotoID);
                        }
                        else
                        {
                            if (_GetUser.Gender == 1)
                            {
                                ImageUrl = SitePath + "web/images/M.png";
                            }
                            else
                            {
                                ImageUrl = SitePath + "web/images/F.png";
                            }
                        }
                    }
                    return ImageUrl;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

    }

    public class UserPictureCls
    {
        public int UserID { get; set; }
    }

}
