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
    public class GetCriteriaUserAnswerController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<CriteriaUserAnswerWeek> Get()
        {
            int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            return new CriteriaUserAnswerWeek().GetCriteriaUserAnswers(UserID);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";

        }

        // POST api/<controller>
        public CriteriaUserAnswerWeek Post([FromBody]GetCriteriaUserAnswer gc)
        {
            int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            return new CriteriaUserAnswerWeek().GetCriteriaUserAnswer(UserID, gc.Criteria_id);
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
    public class GetCriteriaUserAnswer
    {
        public string Criteria_id { get; set; }
    }
}