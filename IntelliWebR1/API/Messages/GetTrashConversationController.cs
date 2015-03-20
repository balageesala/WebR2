using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntellidateR1;
using System.Web;


namespace IntelliWebR1.API
{
    public class GetTrashConversationController : ApiController
    {
        // POST api/<controller>
        public IEnumerable<Conversation> Post([FromBody]GetTrash GetTr)
        {
            int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            Conversation[] m_TrashConversations = new Conversation().GetTrashConversation(_UserID, GetTr.OtherUserID);
            return m_TrashConversations;
        }




        //Trash user conversation
        public bool Get(int id)
        {
            int m_ConversationId = Convert.ToInt32(id);
            int m_UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            bool m_res = false;
            m_res = new Conversation().TrashConversation(m_ConversationId, m_UserID);
            return m_res;
        }

    }

    public class GetTrash
    {
        public int OtherUserID { get; set; }
    }
}
