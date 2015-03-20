using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using IntellidateR1;

namespace IntelliWebR1.API
{
    public class GetAllQuestionAnswersController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<QuestionAnswersWeek<OptionsSingleSelectAnswer, OptionsMultiSelectAnswer>> Get()
        {
            int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            var Result = new QuestionAnswersWeek<OptionsSingleSelectAnswer, OptionsMultiSelectAnswer>().GetUserAnswers(UserID);
           
            return Result;
        }

    }
}