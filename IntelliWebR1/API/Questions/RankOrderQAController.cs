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
    public class RankOrderQAController : ApiController
    {

        public IEnumerable<QuestionAnswers<OptionsSingleSelectAnswer, OptionsMultiSelectAnswer>> Get()
        {
            int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            QuestionAnswers<OptionsSingleSelectAnswer, OptionsMultiSelectAnswer>[] _Answers = new QuestionAnswers<OptionsSingleSelectAnswer, OptionsMultiSelectAnswer>().GetUserAnswersForRankOrder(UserID);
            var _Result = _Answers.OrderBy(x => x.RankOrder);
            return _Result;
        
        }

    }
}
