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
    public class AddContactController : ApiController
    {
        // POST api/<controller>
        public bool Post([FromBody]AddContact m_Contact)
        {
            try
            {
               int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
               bool _result = new UserEmailContacts().AddUserContacts(_UserID, m_Contact.FirstName, m_Contact.LastName, m_Contact.EmailAddress, m_Contact.PhoneNoOne, m_Contact.PhoneNoTwo, 0, m_Contact.CityName, m_Contact.ZipCode, "", null);
               return _result;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }


    public class AddContact
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNoOne { get; set; }

        public string PhoneNoTwo { get; set; }
       
        public string CityName { get; set; }

        public string ZipCode { get; set; }
    }

}
