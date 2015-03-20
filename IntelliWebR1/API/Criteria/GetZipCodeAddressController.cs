using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntelliWebR1.API
{
    public class GetZipCodeAddressController : ApiController
    {
        public string Post([FromBody]ZipCodeAddress zip)
        {
            return Distance.GetAddressFromZipCode(zip.zipcode);
        }

    }

    public class ZipCodeAddress
    {
        public string zipcode { get; set; }

    }
}
