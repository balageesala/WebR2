using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API.User
{
    public class GetUserDetailsController : ApiController
    {
        public IntellidateR1.User Get()
        {
            int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            return new IntellidateR1.User().GetUserDetails(_UserID);
        }

        public IntellidateR1.User Post([FromBody]GetOtherUser _obj)
        {
            return new IntellidateR1.User().GetUserDetails(_obj.OtherUserID);
        }
    }

    public class GetOtherUser
    {
        public int OtherUserID { get; set; }
    }


}
