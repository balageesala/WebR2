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
    public class GetChatWindowController : ApiController
    {

        public IEnumerable<IMConversation> Post([FromBody]GetIMClass GetIM)
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                IMConversation[] m_IMConversations = new IMConversation().GetIMConversation(_UserID, GetIM.OtherUserID);
                return m_IMConversations.Reverse().Take(10).OrderBy(x => x.SentTime);
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}
