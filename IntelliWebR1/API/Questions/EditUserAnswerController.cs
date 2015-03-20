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
    public class EditUserAnswerController : ApiController
    {

        public bool Post([FromBody]AnswerQuestion value)
        {
            int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            return new QuestionAnswersWeek<OptionsSingleSelectAnswer, OptionsMultiSelectAnswer>().EditAnswerQuestion(UserID, value.Question_id, value.OptionAnswer, value.PreferenceAnswer, value.Rating, value.Comment, value.AnsweredPrivately);
        }


    }
}
