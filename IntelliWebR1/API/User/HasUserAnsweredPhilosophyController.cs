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
    public class HasUserAnsweredPhilosophyController : ApiController
    {
        // GET api/<controller>
        public bool Get()
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                PhilosophyUserAnswer[] _UserAnswers = new PhilosophyUserAnswer().GetPhilosophyUserAnswers(_UserID);
                bool _HasUserAnswered = false;

                foreach (var EachAnswer in _UserAnswers)
                {
                    if (EachAnswer.UserID != 0)
                    {
                        _HasUserAnswered = true;
                        break;
                    }
                }

                return _HasUserAnswered;
            }
            catch (Exception)
            {
                return false;
            }
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