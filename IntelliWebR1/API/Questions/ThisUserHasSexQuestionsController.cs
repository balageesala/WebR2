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
    public class ThisUserHasSexQuestionsController : ApiController
    {
        public bool Post([FromBody]ClsOtherUser value)
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                var _GetAnsweredSexQuestions = new QuestionAnswersWeek<OptionsSingleSelectAnswer, OptionsMultiSelectAnswer>().GetUserAnswers(UserID).Where(x => x.QuestionDetails.QuestionCategory == 1).ToArray();
                var _GetOtherUserAnswers = new QuestionAnswersWeek<OptionsSingleSelectAnswer, OptionsMultiSelectAnswer>().GetUserAnswers(value.OtherUserID).Where(x => x.QuestionDetails.QuestionCategory == 1).ToArray();
                if (_GetAnsweredSexQuestions.Count() > 0 && _GetOtherUserAnswers.Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }      
            }
            catch (Exception)
            {

                return false;
            }
            
        }
    }


    public class ClsOtherUser
    {
        public int OtherUserID { get; set; }

    }

}
