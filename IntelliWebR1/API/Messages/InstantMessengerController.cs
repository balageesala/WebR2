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
    public class InstantMessengerController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<IMConversationSnapShot> Get()
        {


            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                List<IMConversationSnapShot> _RecConversation = new IMConversationSnapShot().GetUserIMConversation(_UserID);
                return _RecConversation;
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}
