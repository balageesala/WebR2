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
    public class GetUserGenderController : ApiController
    {
        // GET api/<controller>
        public int Get()
        {
            int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            return new IntellidateR1.User().GetUserDetails(_UserID).Gender;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
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
}