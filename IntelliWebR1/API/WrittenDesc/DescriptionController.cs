using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntellidateR1;
using System.Web;
using Newtonsoft.Json;

namespace IntelliWebR1.API
{
    public class DescriptionController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<DescriptionAnswers> Get()
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                DescriptionAnswers[] _DescriptionAnswers = new DescriptionAnswers().GetAnswers(_UserID);
                return _DescriptionAnswers;
            }
            catch (Exception)
            {
                return null;
            }
        }


        // POST api/<controller>
        public string POST([FromBody]DescriptionDetails _DescriptionObj)
        {
            try
            {
                string _MethodOutput = string.Empty;
                string _MethodCall = _DescriptionObj.Method;
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                switch (_MethodCall)
                {
                    //save answer
                    case "SA":
                        {

                            if (_DescriptionObj.AnswerText == null)
                            {
                                _DescriptionObj.AnswerText = "";
                            }
                            bool profArraObj = new DescriptionAnswers().SaveAnswer(_DescriptionObj.AnswerText, _DescriptionObj.QuestionId, UserID);
                            if (profArraObj)
                            {
                                DescriptionAnswers[] _ProfileAnswers = new DescriptionAnswers().GetAnswers(UserID);
                                string m_Result = JsonConvert.SerializeObject(_ProfileAnswers);
                                _MethodOutput = m_Result;
                            }
                            break;
                        }
                }
                return _MethodOutput;
            }
            catch (Exception ex)
            {
                Error.LogError(ex, "DescriptionController POST");
                return null;
            }
        }


    }


    public class DescriptionDetails
    {
        public string Method { get; set; }
        public int QuestionId { get; set; }
        public string AnswerText { get; set; }
        public int Priority { get; set; }

        public QuestionPriorityMap[] QuestionPriorityMap { get; set; }
    }

    public class QuestionPriorityMap
    {
        public int QuestionID { get; set; }
        public int Priority { get; set; }
    }


}
