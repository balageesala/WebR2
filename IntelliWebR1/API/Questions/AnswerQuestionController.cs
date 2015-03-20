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
    public class AnswerQuestionController : ApiController
    {
        
        // POST api/<controller>
        public QuestionAnswersWeek<OptionsSingleSelectAnswer, OptionsMultiSelectAnswer> Post([FromBody]AnswerQuestion value)
        {
            int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            return new QuestionAnswersWeek<OptionsSingleSelectAnswer, OptionsMultiSelectAnswer>().AnswerQuestion(UserID, value.Question_id, value.OptionAnswer, value.PreferenceAnswer, value.Rating, value.Comment,value.AnsweredPrivately);
        }

    }
    public class AnswerQuestion
    {
        public string Question_id { get; set; }
        public string OptionAnswer { get; set; }
        public string[] PreferenceAnswer { get; set; }
        public decimal Rating { get; set; }
        public string Comment { get; set; }
        public bool AnsweredPrivately { get; set; }
    }
}