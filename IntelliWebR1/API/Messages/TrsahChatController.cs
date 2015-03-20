using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API.Messages
{
    public class TrsahChatController : ApiController
    {
        public bool Post([FromBody]ChatMessage _DelObj)
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                bool _res = new IMConversation().TrashIMConversation(_DelObj.IM_id, _UserID);
                return _res;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
