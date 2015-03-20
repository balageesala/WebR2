using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntellidateR1;
using System.Web;
using Newtonsoft.Json.Bson;

namespace IntelliWebR1.API
{
    public class AddCriteriaUserAnswerController : ApiController
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
        public CriteriaUserAnswerWeek Post([FromBody]AddCriteriaUserAnswer ac)
        {
            int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            CriteriaUserAnswerWeek m_CriteriaUserAnswer = new CriteriaUserAnswerWeek();
            bool IsHasUserMatch = new UserTodayMatch().IsGetUserMatch(UserID);
            switch (ac.CriteriaType)
            {
                case "1":
                    {
                        AnswerTypeSingle m_AnswerTypeSingle = new AnswerTypeSingle
                        {
                            _id = ac.UserOption
                        };

                        if (IsHasUserMatch)
                        {
                            m_CriteriaUserAnswer = new CriteriaUserAnswerWeek().UpdateCriteriaUserAnswer(ac.Criteria_id, UserID, m_AnswerTypeSingle);
                        }
                        else
                        {
                            new CriteriaUserAnswer().UpdateCriteriaUserAnswer(ac.Criteria_id, UserID, m_AnswerTypeSingle);
                            m_CriteriaUserAnswer = new CriteriaUserAnswerWeek().UpdateCriteriaUserAnswer(ac.Criteria_id, UserID, m_AnswerTypeSingle);
                        }
                        break;

                    }

                case "2":
                    {
                        AnswerTypeMultiple m_AnswerTypeMultiple = new AnswerTypeMultiple();
                        m_AnswerTypeMultiple._ids = ac.UserOptions;

                        if (IsHasUserMatch)
                        {
                            m_CriteriaUserAnswer = new CriteriaUserAnswerWeek().UpdateCriteriaUserAnswer(ac.Criteria_id, UserID, m_AnswerTypeMultiple);
                        }
                        else
                        {
                            new CriteriaUserAnswer().UpdateCriteriaUserAnswer(ac.Criteria_id, UserID, m_AnswerTypeMultiple);
                            m_CriteriaUserAnswer = new CriteriaUserAnswerWeek().UpdateCriteriaUserAnswer(ac.Criteria_id, UserID, m_AnswerTypeMultiple);                      
                        }                     
                        break;
                    }

                case "5":
                    {
                        AnswerTypeSingle m_AnswerTypeSingle = new AnswerTypeSingle
                        {
                            _id = ac.UserOption
                        };
                        if (IsHasUserMatch)
                        {
                            m_CriteriaUserAnswer = new CriteriaUserAnswerWeek().UpdateCriteriaUserAnswer(ac.Criteria_id, UserID, m_AnswerTypeSingle);
                        }
                        else
                        {
                            new CriteriaUserAnswer().UpdateCriteriaUserAnswer(ac.Criteria_id, UserID, m_AnswerTypeSingle);
                            m_CriteriaUserAnswer = new CriteriaUserAnswerWeek().UpdateCriteriaUserAnswer(ac.Criteria_id, UserID, m_AnswerTypeSingle);                      
                        }
                        break;
                    }
                case "7":
                    {
                        AnswerTypeDate m_AnswerTypeDate = new AnswerTypeDate
                        {
                            Day = ac.UserOption_Day,
                            Month = ac.UserOption_Month,
                            Year = ac.UserOption_Year
                        };

                        if (IsHasUserMatch)
                        {
                            m_CriteriaUserAnswer = new CriteriaUserAnswerWeek().UpdateCriteriaUserAnswer(ac.Criteria_id, UserID, m_AnswerTypeDate);
                        }
                        else
                        {
                            new CriteriaUserAnswer().UpdateCriteriaUserAnswer(ac.Criteria_id, UserID, m_AnswerTypeDate);
                            m_CriteriaUserAnswer = new CriteriaUserAnswerWeek().UpdateCriteriaUserAnswer(ac.Criteria_id, UserID, m_AnswerTypeDate);
                        }

                        // Reset DOB
                        DateTime _DateOfBirth = new DateTime(Convert.ToInt32(m_AnswerTypeDate.Year), Convert.ToInt32(m_AnswerTypeDate.Month), Convert.ToInt32(m_AnswerTypeDate.Day));
                        new IntellidateR1.User().ChangeUserDateOfBirth(UserID, _DateOfBirth);
                        break;
                    }

                case "8":
                    {
                        AnswerTypeText m_AnswerTypeText = new AnswerTypeText
                        {
                            Value = ac.UserOption
                        };

                        if (IsHasUserMatch)
                        {
                            m_CriteriaUserAnswer = new CriteriaUserAnswerWeek().UpdateCriteriaUserAnswer(ac.Criteria_id, UserID, m_AnswerTypeText);
                        }
                        else
                        {
                            new CriteriaUserAnswer().UpdateCriteriaUserAnswer(ac.Criteria_id, UserID, m_AnswerTypeText);
                            m_CriteriaUserAnswer = new CriteriaUserAnswerWeek().UpdateCriteriaUserAnswer(ac.Criteria_id, UserID, m_AnswerTypeText);
                        }
                        break;
                    }
                case "9":
                    {
                        AnswerTypeText m_AnswerTypeText = new AnswerTypeText
                        {
                            Value = ac.UserOption
                        };

                        if (IsHasUserMatch)
                        {
                            m_CriteriaUserAnswer = new CriteriaUserAnswerWeek().UpdateCriteriaUserAnswer(ac.Criteria_id, UserID, m_AnswerTypeText);
                        }
                        else
                        {
                            new CriteriaUserAnswer().UpdateCriteriaUserAnswer(ac.Criteria_id, UserID, m_AnswerTypeText);
                            m_CriteriaUserAnswer = new CriteriaUserAnswerWeek().UpdateCriteriaUserAnswer(ac.Criteria_id, UserID, m_AnswerTypeText);
                        }
                        break;
                    }
            }



            switch (ac.CriteriaPreferenceType)
            {
                case "1":
                    {
                        AnswerTypeMultiple m_AnswerTypeMultiple = new AnswerTypeMultiple();
                        m_AnswerTypeMultiple._ids = ac.Preferences;

                        if (IsHasUserMatch)
                        {
                            m_CriteriaUserAnswer = new CriteriaUserAnswerWeek().UpdateCriteriaUserPreference(ac.Criteria_id, UserID, m_AnswerTypeMultiple, ac.HasAllPreferencesSelected);
                        }
                        else
                        {
                            new CriteriaUserAnswer().UpdateCriteriaUserPreference(ac.Criteria_id, UserID, m_AnswerTypeMultiple, ac.HasAllPreferencesSelected);
                            m_CriteriaUserAnswer = new CriteriaUserAnswerWeek().UpdateCriteriaUserPreference(ac.Criteria_id, UserID, m_AnswerTypeMultiple, ac.HasAllPreferencesSelected);
                        }
                        break;
                    }

                case "3":
                    {
                        AnswerTypeRange m_AnserTypeRange = new AnswerTypeRange
                        {
                            Min = ac.PreferenceRangeMin,
                            Max = ac.PreferenceRangeMax
                        };

                        if (IsHasUserMatch)
                        {
                            m_CriteriaUserAnswer = new CriteriaUserAnswerWeek().UpdateCriteriaUserPreference(ac.Criteria_id, UserID, m_AnserTypeRange, ac.HasAllPreferencesSelected);
                        }
                        else
                        {
                            new CriteriaUserAnswer().UpdateCriteriaUserPreference(ac.Criteria_id, UserID, m_AnserTypeRange, ac.HasAllPreferencesSelected);
                            m_CriteriaUserAnswer = new CriteriaUserAnswerWeek().UpdateCriteriaUserPreference(ac.Criteria_id, UserID, m_AnserTypeRange, ac.HasAllPreferencesSelected);              
                        }
                        break;
                    }
                case "4":
                    {
                        AnswerTypeRange m_AnserTypeRange = new AnswerTypeRange
                        {
                            Min = ac.PreferenceRangeMin,
                            Max = ac.PreferenceRangeMax
                        };

                        if (IsHasUserMatch)
                        {
                            m_CriteriaUserAnswer = new CriteriaUserAnswerWeek().UpdateCriteriaUserPreference(ac.Criteria_id, UserID, m_AnserTypeRange, ac.HasAllPreferencesSelected);
                        }
                        else
                        {
                            new CriteriaUserAnswer().UpdateCriteriaUserPreference(ac.Criteria_id, UserID, m_AnserTypeRange, ac.HasAllPreferencesSelected);
                            m_CriteriaUserAnswer = new CriteriaUserAnswerWeek().UpdateCriteriaUserPreference(ac.Criteria_id, UserID, m_AnserTypeRange, ac.HasAllPreferencesSelected);
                        }
                        break;
                    }
            }
         
            new CriteriaUserAnswer().UpdateCriteriaUserComment(UserID, ac.Criteria_id, ac.Comment);
            
            m_CriteriaUserAnswer = new CriteriaUserAnswerWeek().UpdateCriteriaUserComment(UserID,ac.Criteria_id, ac.Comment);
            return m_CriteriaUserAnswer;
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

    public class AddCriteriaUserAnswer
    {
        public string Criteria_id { get; set; }

        public string CriteriaType { get; set; }

        public string CriteriaPreferenceType { get; set; }

        public string UserOption { get; set; }

        public string[] UserOptions { get; set; }

        public string UserOption_Month { get; set; }

        public string UserOption_Day { get; set; }

        public string UserOption_Year { get; set; }

        public string[] Preferences { get; set; }

        public string PreferenceRangeMin { get; set; }

        public string PreferenceRangeMax { get; set; }

        public string Comment { get; set; }

        public bool HasAllPreferencesSelected { get; set; }
    }
}