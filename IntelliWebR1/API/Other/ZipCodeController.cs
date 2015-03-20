using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntellidateR1;


namespace IntelliWebR1.API
{
    public class ZipCodeController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<zipcodes> Get()
        {
            return new zipcodes().GetZipCodes();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public string Post([FromBody]ZipCodeData ZipCodeData)
        {
            return new zipcodes().GetLocationName(ZipCodeData.ZipCode);
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
    public class ZipCodeData
    {
        public string ZipCode { get; set; }
    }
}