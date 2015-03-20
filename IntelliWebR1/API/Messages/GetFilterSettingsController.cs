using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API.Messages
{
    public class GetFilterSettingsController : ApiController
    {
        public MessageFilters Get()
        {
            int m_RecipientID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            MessageFilters m_res = new MessageFilters().GetMessageFilter(m_RecipientID);
            return m_res;
        }
    }
}
