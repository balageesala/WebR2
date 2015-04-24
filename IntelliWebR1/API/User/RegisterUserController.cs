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
            DateTime DT = new DateTime(m_RegisterUser.DY, m_RegisterUser.DM, m_RegisterUser.DD);
            return new IntellidateR1.User().RegisterUser(m_RegisterUser.LoginName, m_RegisterUser.EmailAddress, m_RegisterUser.Password, m_RegisterUser.Gender, m_RegisterUser.GenderLookingFor,DT);
        }
    }

    public class RegisterUser
    {
        public string LoginName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public int Gender { get; set; }
        public int GenderLookingFor { get; set; }
        public int DD { get; set; }
        public int DM { get; set; }
        public int DY { get; set; }

    }
}