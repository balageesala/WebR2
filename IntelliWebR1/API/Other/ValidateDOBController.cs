using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntelliWebR1.API
{
    public class ValidateDOBController : ApiController
    {
        // POST api/<controller>
        public int Post([FromBody]DOB value)
        {
            try
            {
                DateTime _Test = new DateTime(value.Year, value.Month, value.Day);

                TimeSpan _Age = DateTime.Now - _Test;
                if (_Age.Days / 365 < 21)
                {
                    return -2;
                }

                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }

    public class DOB
    {
        public int Month { get; set; }
        public int Day { get; set; }
        public int Year { get; set; }
    }
}