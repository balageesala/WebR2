using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntelliWebR1.API
{
    public class AboutmeController : ApiController
    {

        public string Get()
        {
            try
            {
                return "hi";
            }
            catch (Exception)
            {
                return "ex";
            }
        }


        // POST api/<controller>
        public DescriptionAnswers[] POST([FromBody]AboutmeDesc _DescriptionObj)
        {
            try
            {
                DescriptionAnswers[] _DescriptionAnswers = new DescriptionAnswers().GetAnswers(_DescriptionObj.UserID);
                return _DescriptionAnswers;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

    public class AboutmeDesc
    {
        public int UserID { get; set; }

    }


}
