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
    public class GetIMController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5  delete IM
        public bool Get(int id)
        {
            int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            int m_OtherUserID = id;
            bool m_Res = false;
            IMConversation[] m_IMConversations = new IMConversation().GetIMConversation(_UserID, m_OtherUserID);
            foreach (var item in m_IMConversations)
            {
                m_Res = new IMConversation().DeleteIMConversation(item._id);
            }
            return m_Res;
        }

        // POST api/<controller>
        public IEnumerable<IMConversationView> Post([FromBody]GetIMClass GetIM)
        {
            int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            IMConversationView[] m_IMConversations = new IMConversationView().GetIMConversationView(_UserID, GetIM.OtherUserID);
            return m_IMConversations;
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
    public class GetIMClass
    {
        public int OtherUserID { get; set; }
    }

    public class ChatConvesation
    {
        public IMConversation  IMConversation { get; set; }
        public string SenderImg { get; set; }
        public string RecipientImg { get; set; }
    }





}
