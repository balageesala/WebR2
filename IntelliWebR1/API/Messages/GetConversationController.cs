using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntellidateR1;
using System.Web;
using Newtonsoft.Json;

namespace IntelliWebR1.API
{
     public class GetConversationController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };  
            

        }

        // GET api/<controller>/5
        public bool Get(int id)
        {
            int m_RecipientID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
             bool  m_res = new Conversation().DeleteConversation(id, m_RecipientID);
             return m_res;
        }

        // POST api/<controller>
        public IEnumerable<Conversation> Post([FromBody]GetConversationClass GetConversationClass)
        {
            int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            Conversation[] _Conversations = new Conversation().GetConversation(_UserID, GetConversationClass.OtherUserID);

            //as well as update the user seen time here
            foreach (var item in _Conversations)
            {
                if (!item.HasRecipientSeen && item.RecipientID == _UserID)
                {
                    new Conversation().UpdateRecipientSeenConversation(item.ConversationID, _UserID);
                }
            }
          //  string m_Result = JsonConvert.SerializeObject(_Conversations);
            return _Conversations;
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

    public class GetConversationClass
    {
        public int OtherUserID { get; set; }
    }
}
