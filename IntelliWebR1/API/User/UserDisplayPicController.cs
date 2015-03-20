using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API
{
    public class UserDisplayPicController : ApiController
    {


        // POST api/<controller>
        public string Post([FromBody]UserDisplayPicClass UserDisplayPic)
        {
            try
            {
                IntellidateR1.User UserDetails = new IntellidateR1.User().GetUserDetails(UserDisplayPic.UserID);
                string SitePath = System.Configuration.ConfigurationManager.AppSettings["SitePath"].ToString();
                string _profilePhoto = string.Empty;
                if (UserDetails.ProfilePhoto != null)
                {
                    string _UserPhoto = new Utils().GetSmallPPCTPath(UserDetails.ProfilePhoto.PhotoID);
                     if(_UserPhoto!=""){
                         _profilePhoto = _UserPhoto;
                     }
                     else
                     {
                         if (UserDetails.Gender == 1)
                         {
                             _profilePhoto = SitePath + "web/images/M.png";
                         }
                         else
                         {
                             _profilePhoto = SitePath + "web/images/F.png";
                         }
                     }
                }
                else
                {
                    if (UserDetails.Gender == 1)
                    {
                        _profilePhoto = SitePath + "web/images/M.png";
                    }
                    else
                    {
                        _profilePhoto = SitePath + "web/images/F.png";
                    }
                }

                return _profilePhoto;
            }
            catch (Exception)
            {
                return "";
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }

    public class UserDisplayPicClass
    {
        public int UserID { get; set; }
        public int Width { get; set; }
    }
}
