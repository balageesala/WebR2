using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntelliWebR1.API
{
    public class ISCheckExistingEmailAddressController : ApiController
    {

        public bool Post([FromBody]CheckExistingEmailAddress m_CheckExistingEmailAddress)
        {
            try
            {
                return new IntellidateR1.User().CheckExistingEmailAddress(m_CheckExistingEmailAddress.EmailAddress);
            }
            catch (Exception)
            {
                return true;
            }
        }

    }
}
