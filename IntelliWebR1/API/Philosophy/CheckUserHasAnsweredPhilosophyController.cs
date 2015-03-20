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
    public class CheckUserHasAnsweredPhilosophyController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public bool Post([FromBody]CheckUserHasAnsweredPhilosophy value)
        {
            int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            return new PhilosophyUserAnswer().HasUserAnsweredPhilosophy(UserID, value.PhilosophyID);
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

    public class CheckUserHasAnsweredPhilosophy
    {
        public string PhilosophyID { get; set; }
    }
}