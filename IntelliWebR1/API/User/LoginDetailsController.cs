using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using IntellidateR1;


namespace IntelliWebR1.API
{
    public class LoginDetailsController : ApiController
    {
        public bool Post([FromBody]UserAgent m_UserAgent)
        {
            try
            {
                if (HttpContext.Current.User.Identity.Name != "")
                {
                    int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                    string _IpAddress = HttpContext.Current.Request.UserHostAddress;
                    new LoginDetails().AddUserLogin(_UserID, m_UserAgent.UaProfile, m_UserAgent.OS, m_UserAgent.Latitude, m_UserAgent.Longitude, m_UserAgent.Referrer, _IpAddress);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public class UserAgent
    {
        public string UaProfile { get; set; } //browser
        public string Referrer { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string OS { get; set; }
      
    }



}
