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
    public class PasswordConfirmController : ApiController
    {
        // POST api/<controller>
        public bool Post([FromBody]PasswordConfirm PasswordConfirm)
        {
            int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            IntellidateR1.User m_UserObject = new IntellidateR1.User().GetUserDetails(_UserID);
            if (m_UserObject != null)
            {
                if (m_UserObject.Password == PasswordConfirm.Password)
                {
                    return true;
                }
            }
            return false;
        }
    }
    public class PasswordConfirm
    {
        public string Password { get; set; }
    }
}
