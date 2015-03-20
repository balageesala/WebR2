using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API.Questions
{
    public class GetUnAnswredQuestionController : ApiController
    {
        public Questions<ElementTypeMultiSelect, ElementTypeMultiSelect> Post([FromBody]EditGetQuestion _Editquestion)
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                Questions<ElementTypeMultiSelect, ElementTypeMultiSelect> _result = new Questions<ElementTypeMultiSelect, ElementTypeMultiSelect>().GetUnAnswredQuestion(_Editquestion.Question_id);
                return _result;
            }
            catch (Exception)
            {
                return null;
            }
          
        }



    }
}
