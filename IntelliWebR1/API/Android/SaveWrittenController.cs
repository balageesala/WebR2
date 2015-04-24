using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntellidateR1;

namespace IntelliWebR1.API
{
    public class SaveWrittenController : ApiController
    {
        public bool POST([FromBody]SaveWrittenDetails _WrittenObj)
        {
            try
            {
                bool profArraObj = new DescriptionAnswers().SaveAnswer(_WrittenObj.AnswerText, _WrittenObj.QuestionId, _WrittenObj.UserID);
                return profArraObj;
            }
            catch (Exception ex)
            {
                Error.LogError(ex, "DescriptionController POST");
                return false;
            }
        }

    }

    public class SaveWrittenDetails
    {
        public int UserID { get; set; }
        public int QuestionId { get; set; }
        public string AnswerText { get; set; }
    }

}
