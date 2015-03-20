using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntellidateR1;
using System.Web;

namespace IntelliWebR1.API
{
    public class CheckHasUserAnsweredQuestionController : ApiController
    {

        // POST api/<controller>
        public bool Post([FromBody]QuestionDetails value)
        {
            int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            return new QuestionAnswersWeek<OptionsSingleSelectAnswer, OptionsMultiSelectAnswer>().CheckHasUserAnsweredQuestion(UserID, value.Question_id);
        }
    }
    public class QuestionDetails
    {
        public string Question_id { get; set; }
    }
}