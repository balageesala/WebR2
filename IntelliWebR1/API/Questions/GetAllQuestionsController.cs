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
    public class GetAllQuestionsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Questions<ElementTypeSingleSelect, ElementTypeMultiSelect>> Get()
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                return new Questions<ElementTypeSingleSelect, ElementTypeMultiSelect>().GetAllUserUnAnswredQuestions(UserID);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}