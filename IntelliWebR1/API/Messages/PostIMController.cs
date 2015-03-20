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
    public class PostIMController : ApiController
    {
        // POST api/<controller>
        public IMConversation Post([FromBody]PostIMClass PostIM)
        {
            int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            IMConversation m_IMConversation = new IMConversation().SendMessage(_UserID, PostIM.OtherUserID, PostIM.MessageText);
            return m_IMConversation;
        }
    }

    public class PostIMClass
    {
        public int OtherUserID { get; set; }
        public string MessageText { get; set; }
    }
}
