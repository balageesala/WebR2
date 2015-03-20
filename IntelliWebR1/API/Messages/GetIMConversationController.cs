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
    public class GetIMConversationController : ApiController
    {
        // POST api/<controller>
        public IEnumerable<IMConversation> Post([FromBody]GetIMClass GetIM)
        {
            int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            IMConversation[] m_IMConversations = new IMConversation().GetIMConversation(_UserID, GetIM.OtherUserID);
            return m_IMConversations;
        }


        //delete IM
        public bool Get(string id)
        {
            return new IMConversation().DeleteIMConversation(id);
        }



    }
}
