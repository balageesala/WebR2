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
    public class EmailAddressController : ApiController
    {
        // GET api/<controller>
        public string Get()
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                IntellidateR1.User UserDetails = new IntellidateR1.User().GetUserDetails(_UserID);

                return UserDetails.EmailAddress;
            }
            catch (Exception)
            {
                return "";
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public bool Post([FromBody]EmailAddressClass EmailAddress)
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                bool _Return = new IntellidateR1.User().ChangeEmailAddress(_UserID, EmailAddress.EmailAddressSelected);
                return true;
            }
            catch (Exception)
            {
                return false;
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
    public class EmailAddressClass
    {
        public string EmailAddressSelected { get; set; }
    }
}
