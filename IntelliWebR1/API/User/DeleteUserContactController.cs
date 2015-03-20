using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntelliWebR1.API
{
    public class DeleteUserContactController : ApiController
    {
        public bool Post([FromBody]userContact _Contact)
        {
            try
            {
                bool _Return = new IntellidateR1.UserEmailContacts().DeleteUserEmailAddress(_Contact.ContactID);
                return _Return;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public class userContact
    {
        public int ContactID { get; set; }
    }
}