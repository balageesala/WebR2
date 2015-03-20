using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API
{
    public class DeleteQuestionController : ApiController
    {

        public bool Post([FromBody]EditGetQuestion _Editquestion)
        {
            int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            return new QuestionAnswersWeek<OptionsSingleSelectAnswer, OptionsMultiSelectAnswer>().DeleteQuestion(_Editquestion.Question_id,UserID);
        }

    }
}
