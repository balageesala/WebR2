using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntelliWebR1.API
{
    public class UpdateContactController : ApiController
    {
        public bool Post([FromBody]UpdateContactEmail _Contact)
        {
            try
            {
                bool _Return = new IntellidateR1.UserEmailContacts().UpdateUserContactEmailAddress(_Contact.ContactID,_Contact.EmailAddress);
                return _Return;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public class UpdateContactEmail
    {
        public int ContactID { get; set; }
        public string EmailAddress { get; set; }

    }


}
