using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API
{
    public class IsUserAbleToChatController : ApiController
    {
        public bool Post([FromBody]GetIMClass GetIM)
        {
            int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            bool ISUSerAbleToChat = new UserAccountSettings().ISUserAbleToChat(_UserID, GetIM.OtherUserID);
            return ISUSerAbleToChat;
        }


    }
}
