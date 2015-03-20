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
    public class LogOutController : ApiController
    {
       
        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            new OnlineUsers().RemoveOnlineUser(UserID);
        }

    }
}