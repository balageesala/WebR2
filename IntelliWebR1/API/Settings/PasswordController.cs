using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API
{
       public class PasswordController : ApiController
        {
            // GET api/<controller>
            public string Get()
            {
                try
                {
                    int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                    IntellidateR1.User UserDetails = new IntellidateR1.User().GetUserDetails(_UserID);

                    return UserDetails.Password;
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
            public bool Post([FromBody]PasswordClass Password)
            {
                try
                {
                    int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                    bool _Return = new IntellidateR1.User().ChangePassword(_UserID, Password.PasswordSelected);
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
        public class PasswordClass
        {
            public string PasswordSelected { get; set; }
        }
    }
