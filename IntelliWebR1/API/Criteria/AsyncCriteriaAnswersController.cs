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
    public class AsyncCriteriaAnswersController : ApiController
    {
        public void Post()
        {
            int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            new CriteriaUserAnswer().SendCriteriaUserAnswerToLive(UserID);
        }
    }
}
