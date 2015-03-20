using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntellidateR1;

namespace IntelliWebR1.API
{
    public class GetEditPhilosophyListController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Philosophy> Get()
        {
            return new Philosophy().GetPhilosophyList();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public IEnumerable<Philosophy> Post([FromBody]GetEditPhilosophyList _GetEditPhilosophyList)
        {
            return new Philosophy().GetEditPhilosophyList(_GetEditPhilosophyList.Philosophy_id);
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

    public class GetEditPhilosophyList
    {
        public string Philosophy_id { get; set; }
    }
}