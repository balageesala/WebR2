using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace IntelliWebR1.API
{
    public class CriteriaiPositionController : ApiController
    {
        // GET api/<controller>
        public string Get()
        {
            string sessionId = "";
            CookieHeaderValue cookie = Request.Headers.GetCookies("session-criteriaposition").FirstOrDefault();
            if (cookie != null)
            {
                sessionId = cookie["session-criteriaposition"].Value;
            }
            if (sessionId != "")
            {
                return sessionId;
            }
            else
            {
                return "";
            }
        }


        // POST api/<controller>
        public void Post([FromBody]CriteriaPosition value)
        {
            var resp = new HttpResponseMessage();

            var cookie = new CookieHeaderValue("session-criteriaposition", value.Criteria_id);
            cookie.Expires = DateTimeOffset.Now.AddDays(1);
            cookie.Domain = Request.RequestUri.Host;
            cookie.Path = "/";

            resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
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

    public class CriteriaPosition
    {
        public string Criteria_id { get; set; }
    }
}