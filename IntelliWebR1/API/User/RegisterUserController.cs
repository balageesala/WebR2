using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntellidateR1;

namespace IntelliWebR1.API
{
    public class RegisterUserController : ApiController
    {
        public string Get()
        {
            return "value";
        }

        // POST api/<controller>
        public IntellidateR1.User Post([FromBody]RegisterUser m_RegisterUser)
        {
            return new IntellidateR1.User().RegisterUser(m_RegisterUser.LoginName, m_RegisterUser.EmailAddress, m_RegisterUser.Password, m_RegisterUser.Gender, m_RegisterUser.DateOfBirth);
        }
    }

    public class RegisterUser
    {
        public string LoginName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}