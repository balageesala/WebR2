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
    public class SetWrittnPriorityController : ApiController
    {
        public bool POST([FromBody]WrittnPriority _ObjPriority)
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                new DescriptionAnswers().SetDescriptionAnswerPriority(_ObjPriority.AnswerID, _ObjPriority.Priority, _UserID);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


    }

    public class WrittnPriority
    {
        public int AnswerID { get; set; }
        public int Priority { get; set; }
    }

}
