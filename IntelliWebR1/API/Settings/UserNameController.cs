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
    public class UserNameController : ApiController
    {
        // GET api/<controller>
        public string Get()
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                IntellidateR1.User UserDetails = new IntellidateR1.User().GetUserDetails(_UserID);

                return UserDetails.LoginName;
            }
            catch (Exception)
            {
                return "";
            }
        }


        // POST api/<controller>
        public bool Post([FromBody]UserNameClass UserName)
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                bool _Return = new IntellidateR1.User().ChangeUserName(_UserID, UserName.UserNameSelected);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
    public class UserNameClass
    {
        public string UserNameSelected { get; set; }
    }
}
