using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API
{
    public class SessionCheckController : ApiController
    {
        // POST api/<controller>
        public bool Get()
        {
            if (HttpContext.Current.User.Identity.Name == "" || HttpContext.Current.User.Identity.Name == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
