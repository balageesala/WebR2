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
    public class EmailProfileController : ApiController
    {
        public bool Post([FromBody]ThisEmailAddress emailA)
        {
            try
            {
                 int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                 return new EmailThisProfile().AddEmailAddress(UserID,emailA.ProfileUserID, emailA.EmailAddress);
            }
            catch (Exception)
            {

                return false;
            }
        }
    }

    public class ThisEmailAddress
    {
        public int ProfileUserID { get; set; }
        public string EmailAddress { get; set; }
    }
}
