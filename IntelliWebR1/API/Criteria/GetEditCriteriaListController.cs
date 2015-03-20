using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntellidateR1;

namespace IntelliWebR1.API
{
    public class GetEditCriteriaListController : ApiController
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
        public IEnumerable<IntellidateR1.Criteria> Post([FromBody]GetEditCriteriaList _GetEditCriteriaList)
        {
            return new IntellidateR1.Criteria().GetEditCriteriaList(_GetEditCriteriaList.Criteria_id);
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

    public class GetEditCriteriaList
    {
        public string Criteria_id { get; set; }
    }
}