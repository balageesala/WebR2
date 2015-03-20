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
    public class SetFemaleMessageLimitController : ApiController
    {

        public bool Post([FromBody]SetFemaleConversation _SetObj)
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                IntellidateR1.User m_UserDetails = new IntellidateR1.User().GetUserDetails(_UserID);
                bool m_Res = false;
                if (m_UserDetails.Gender == 2)
                {
                  //  m_Res = new SetFemaleConversationLimit().UpdateFemaleConversationLimit(_UserID, _SetObj.OneTimeLimit);
                }
                return m_Res;
            }
            catch (Exception)
            {

                return false;
            }
        }




    }

    public class SetFemaleConversation
    {
        public int OneTimeLimit { get; set; }

    }
}
