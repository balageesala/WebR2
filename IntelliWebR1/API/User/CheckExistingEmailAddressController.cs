using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using IntellidateR1;

namespace IntelliWebR1.API
{
    public class CheckExistingEmailAddressController : ApiController
    {

        // POST api/<controller>
        public bool Post([FromBody]CheckExistingEmailAddress m_CheckExistingEmailAddress)
        {
            try
            {

                if (HttpContext.Current.User.Identity.Name != "")
                {
                    
                    int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                    return new IntellidateR1.User().CheckExistingEmailAddress(_UserID, m_CheckExistingEmailAddress.EmailAddress);
                }
                else
                {
                    return new IntellidateR1.User().CheckExistingEmailAddress(m_CheckExistingEmailAddress.EmailAddress);
                }


            }
            catch (Exception)
            {
                return true;
            }
        }

    }

    public class CheckExistingEmailAddress
    {
        public string EmailAddress { get; set; }
    }
}