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
    public class GetQuestionController : ApiController
    {

        public QuestionAnswersWeek<OptionsSingleSelectAnswer, OptionsMultiSelectAnswer> Post([FromBody]EditGetQuestion _Editquestion)
        {
            int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            return new QuestionAnswersWeek<OptionsSingleSelectAnswer, OptionsMultiSelectAnswer>().GetAnswer(UserID, _Editquestion.Question_id);
        }

    }

    public class EditGetQuestion
    {
        public string Question_id { get; set; }
    }
     


}
