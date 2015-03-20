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
    public class GetChatController : ApiController
    {
        // Get api/<controller>
        public List<IMConversationSnapShot> Get()
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                var m_IMConversations = new IMConversationSnapShot().GetUserIMConversation(_UserID);
                return m_IMConversations;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
