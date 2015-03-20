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
    public class GetPhilosophyUserAnswerController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<PhilosophyUserAnswer> Get()
        {
            int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            return new PhilosophyUserAnswer().GetPhilosophyUserAnswers(UserID);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public PhilosophyUserAnswer Post([FromBody]GetPhilosophyUserAnswer gc)
        {
            int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            return new PhilosophyUserAnswer().GetPhilosophyUserAnswer(UserID, gc.Philosophy_id);
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
    public class GetPhilosophyUserAnswer
    {
        public string Philosophy_id { get; set; }
    }
}