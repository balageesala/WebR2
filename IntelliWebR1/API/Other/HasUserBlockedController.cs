using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API.Other
{
    public class HasUserBlockedController : ApiController
    {

        public bool Post([FromBody]BlockThisProfile _Obj)
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                return new BlockUser().IsUserBlocked(UserID, _Obj.BlockedUserID);
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
