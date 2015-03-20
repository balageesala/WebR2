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
    public class CriteriaPointsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public IEnumerable<CriteriaUserAnswerWeek> Post([FromBody]CriteriaPoints CriteriaPoints)
        {
            try
            {
                string[] _QuestionIDs = CriteriaPoints.CriteriaQuestionIDs.Split(',');
                string[] _Points = CriteriaPoints.Points.Split(',');

                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                // Activate user
                new IntellidateR1.User().ActivateUser(_UserID);

                for (int i = 0; i < _QuestionIDs.Count(); i++)
                {
                    new CriteriaUserAnswerWeek().AssignCriteriaPoints(_UserID, _QuestionIDs[i], Convert.ToDecimal(_Points[i]));
                    new CriteriaUserAnswer().AssignCriteriaPoints(_UserID, _QuestionIDs[i], Convert.ToDecimal(_Points[i]));
                }


                CriteriaUserAnswerWeek[] _CriteriaUserAnswers = new CriteriaUserAnswerWeek().GetCriteriaUserAnswers(_UserID);
                return _CriteriaUserAnswers;
            }
            catch (Exception)
            {
                return null;
            }

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }

    public class CriteriaPoints
    {
        public string CriteriaQuestionIDs { get; set; }
        public string Points { get; set; }
    }
}