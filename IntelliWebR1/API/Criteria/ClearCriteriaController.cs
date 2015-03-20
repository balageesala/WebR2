using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API.Criteria
{
    public class ClearCriteriaController : ApiController
    {
        public bool Post([FromBody]GetCriteriaUserAnswer gc)
        {
            int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            return new CriteriaUserAnswerWeek().ClearCriteriaQuestion(UserID, gc.Criteria_id);
        }
    }
}
