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
    public class FilteredInboxController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<FilteredConversationSnapShot> Get()
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);


                List<FilteredConversationSnapShot> _RecConversation = new FilteredConversationSnapShot().GetUserFilteredConversationSnapshot(_UserID);

                return _RecConversation;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
