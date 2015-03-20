using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntellidateR1;
using System.Web;

namespace IntelliWebR1.API
{
    public class LogoutController : ApiController
    {
        // POST api/<controller>
        public bool Post([FromBody]string value)
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                new OnlineUsers().RemoveOnlineUser(UserID);
            }
            catch (Exception)
            {

            }

            return true;
        }
    }
}
