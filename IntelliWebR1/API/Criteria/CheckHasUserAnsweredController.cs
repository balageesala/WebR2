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
    public class CheckHasUserAnsweredController : ApiController
    {
        // POST api/<controller>
        public bool Post([FromBody]CheckHasUserAnswered value)
        {
            int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            CriteriaUserAnswerWeek m_CriteriaUserAnswer = new CriteriaUserAnswerWeek().GetCriteriaUserAnswer(UserID, value.CriteriaQuestionID);
            return (m_CriteriaUserAnswer != null);
        }

    }

    public class CheckHasUserAnswered
    {
        public string CriteriaQuestionID { get; set; }
    }
}