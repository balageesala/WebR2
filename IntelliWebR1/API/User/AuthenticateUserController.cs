﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntellidateR1;

namespace IntelliWebR1.API
{
    public class AuthenticateUserController : ApiController
    {

        public IntellidateR1.User Post([FromBody]AuthenticateUser m_AuthenticateUser)
        {
            if (m_AuthenticateUser.IsEmail == 1)
            {
               return new IntellidateR1.User().AuthenticateUserWithEmail(m_AuthenticateUser.LoginName, m_AuthenticateUser.Password);
            }
            else
            {
                return new IntellidateR1.User().AuthenticateUser(m_AuthenticateUser.LoginName, m_AuthenticateUser.Password);
            }
            
        }

    }
    public class AuthenticateUser
    {
        public string LoginName { get; set; }
        public string Password { get; set; }
        public int IsEmail { get; set; }
    }
}