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
    public class GetTrashIMController : ApiController
    {

        // POST api/<controller>
        public IEnumerable<IMConversation> Post([FromBody]GetIMClass GetIM)
        {
            int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            IMConversation[] m_IMConversations = new IMConversation().GetTrashIMConversation(_UserID, GetIM.OtherUserID);
            return m_IMConversations;
        }
    }
}
