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
    public class GetCriteriaListController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<IntellidateR1.Criteria> Get()
        {
            try
            {
                return new IntellidateR1.Criteria().GetCriteriaList();
            }
            catch (Exception ex)
            {
                Error.LogError(ex, "IEnumerable<Criteria> Get()");
                return null;
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