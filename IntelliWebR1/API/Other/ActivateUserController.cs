using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API.Other
{
    public class ActivateUserController : ApiController
    {
        public bool Post([FromBody]EmailCLS _Obj)
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                return new SecurityCode().SaveSecurityCode(UserID, _Obj.EmailAddress);
            }
            catch (Exception)
            {
                return false;
            }
        }

    }

    public class EmailCLS
    {
        //here _value means email or code
        public string EmailAddress { get; set; }
    }



}
