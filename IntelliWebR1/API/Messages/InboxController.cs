using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API
{
    public class InboxController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<ConversationSnapShot> Get()
        {


            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                List<ConversationSnapShot> _RecConversation = new ConversationSnapShot().GetUserNotFilteredReceivedConversationSnapshot(_UserID);
                return _RecConversation;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET api/<controller>/5
        public bool Get(int id)
        {
            int m_SenderId = Convert.ToInt32(id);
            int m_UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            bool m_res = false;
            if (m_SenderId != m_UserID)
            {
                var m_Convrs = new Conversation().GetConversation(m_UserID, m_SenderId);
                foreach (var item in m_Convrs)
                {
                    m_res = new Conversation().DeleteConversation(item.ConversationID, m_UserID);
                }
            }

            return m_res;
        }

        // POST api/<controller>
        //here delete recipient to sender conversation
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
