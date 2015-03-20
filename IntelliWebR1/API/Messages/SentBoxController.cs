using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using IntellidateR1;
using System.Configuration;

namespace IntelliWebR1.API
{
    public class SentBoxController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<ConversationSnapShot> Get()
        {


            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                List<ConversationSnapShot> _SentConversation = new ConversationSnapShot().GetUserSentConversationSnapshot(_UserID);
                return _SentConversation;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET api/<controller>/5
        public bool Get(int id)
        {
            int m_SenderId = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            int m_RecipientID = Convert.ToInt32(id);
            bool m_res = false;
            if (m_SenderId != m_RecipientID)
            {
                var m_Convrs = new Conversation().GetConversation(m_SenderId, m_RecipientID);
                foreach (var item in m_Convrs)
                {
                    m_res = new Conversation().DeleteConversation(item.ConversationID, m_SenderId);
                }
            }

            return m_res;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
