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
    public class ComposeController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public bool Get(int id)
        {
            int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            return new Conversation().IsUserAbleToSendSecoundMessage(_UserID, id);
        }

        // POST api/<controller>
        public Conversation Post([FromBody]ComposeClass Compose)
        {
            try
            {
               int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
               Conversation _Conversation = new Conversation().SendMessage(_UserID, Compose.RecipientID, Compose.MessageText);
               new DiscussConversation().AddDiscussConversationBoth(_Conversation.ConversationID, Compose.DiscussType, Compose.DiscussType_id, Compose.DiscussTypeID);
               return _Conversation;
            }
            catch (Exception)
            {
                return null;
            }
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
    public class ComposeClass
    {
        public int RecipientID { get; set; }
        public string MessageText { get; set; }

        //0 = Only Compose
        //1 = Replay to message
        //2 = Question
        //3 = criteria
        //4 = photos
        //5 = written (about me)
        public int DiscussType { get; set; }
        public string DiscussType_id { get; set; }
        public int DiscussTypeID { get; set; }


    }
}
