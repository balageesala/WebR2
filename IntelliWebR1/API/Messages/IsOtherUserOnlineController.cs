using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntellidateR1;

namespace IntelliWebR1.API
{
    public class IsOtherUserOnlineController : ApiController
    {
        public bool Post([FromBody]OnlineUserCls _OtherUserObj)
        {
            string _ConnectionId = new OnlineUsers().GetUserConnectionID(_OtherUserObj.OtherUserID);
            bool ISUSerAbleToChat = false;
            if (_ConnectionId != "")
            {
                ISUSerAbleToChat = true;
            }
            else
            {
                ISUSerAbleToChat = false;
            }

            return ISUSerAbleToChat;
        }




    }


    public class OnlineUserCls
    {
        public int OtherUserID { get; set; }

    }


}
