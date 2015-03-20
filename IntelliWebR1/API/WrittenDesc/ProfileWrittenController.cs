using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API.WrittenDesc
{
    public class ProfileWrittenController : ApiController
    {

        // GET api/<controller>
        public DescriptionAnswers[] POST([FromBody]writtendesc _WrittenObj)
        {
            try
            {
                DescriptionAnswers[] _DescriptionAnswers = new DescriptionAnswers().GetAnswers(_WrittenObj.OtherUserID);
                _DescriptionAnswers = _DescriptionAnswers.Where(x => x.Answer.Trim() != "").ToArray();
                return _DescriptionAnswers;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }


    public class writtendesc
    {
        public int OtherUserID { get; set; }
    }


}
