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
    public class BlockUserProfileController : ApiController
    {
        public bool Post([FromBody]BlockThisProfile _Obj)
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                return new BlockUser().AddBlockUser(UserID, _Obj.BlockedUserID);
            }
            catch (Exception)
            {

                return false;
            }
        }
    }

    public class BlockThisProfile
    {
        public int BlockedUserID { get; set; }

    }

}
