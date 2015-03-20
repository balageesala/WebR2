﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntellidateR1;
using System.Web;

namespace IntelliWebR1.API
{
    public class GetPhilosophyListController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Philosophy> Get()
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                Philosophy[] _AllPhilosophy= new Philosophy().GetUnAnsweredQuestions(UserID);
                return _AllPhilosophy;
            }
            catch (Exception ex)
            {
                Error.LogError(ex, "IEnumerable<Philosophy> Get()");
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