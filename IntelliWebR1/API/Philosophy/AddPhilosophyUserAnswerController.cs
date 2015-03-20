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
    public class AddPhilosophyUserAnswerController : ApiController
    {

        // POST api/<controller>
        public PhilosophyUserAnswer Post([FromBody]AddPhilosophyUserAnswer ac)
        {
            int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            PhilosophyUserAnswer m_PhilosophyUserAnswer = new PhilosophyUserAnswer();

            switch (ac.PhilosophyType)
            {
                case "1":
                    {
                        AnswerTypeSingle m_AnswerTypeSingle = new AnswerTypeSingle
                        {
                            _id = ac.UserOption
                        };


                        m_PhilosophyUserAnswer = new PhilosophyUserAnswer().UpdatePhilosophyUserAnswer(ac.Philosophy_id, UserID, m_AnswerTypeSingle);
                        break;
                    }

                case "2":
                    {
                        AnswerTypeMultiple m_AnswerTypeMultiple = new AnswerTypeMultiple();
                        m_AnswerTypeMultiple._ids = ac.UserOptions;


                        m_PhilosophyUserAnswer = new PhilosophyUserAnswer().UpdatePhilosophyUserAnswer(ac.Philosophy_id, UserID, m_AnswerTypeMultiple);
                        break;
                    }

                case "5":
                    {
                        AnswerTypeSingle m_AnswerTypeSingle = new AnswerTypeSingle
                        {
                            _id = ac.UserOption
                        };


                        m_PhilosophyUserAnswer = new PhilosophyUserAnswer().UpdatePhilosophyUserAnswer(ac.Philosophy_id, UserID, m_AnswerTypeSingle);
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


                        m_PhilosophyUserAnswer = new PhilosophyUserAnswer().UpdatePhilosophyUserAnswer(ac.Philosophy_id, UserID, m_AnswerTypeDate);

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


                        m_PhilosophyUserAnswer = new PhilosophyUserAnswer().UpdatePhilosophyUserAnswer(ac.Philosophy_id, UserID, m_AnswerTypeText);
                        break;
                    }
            }



            switch (ac.PhilosophyPreferenceType)
            {
                case "1":
                    {
                        AnswerTypeMultiple m_AnswerTypeMultiple = new AnswerTypeMultiple();
                        m_AnswerTypeMultiple._ids = ac.Preferences;

                        m_PhilosophyUserAnswer = new PhilosophyUserAnswer().UpdatePhilosophyUserPreference(ac.Philosophy_id, UserID, m_AnswerTypeMultiple, ac.HasAllPreferencesSelected);
                        break;
                    }

                case "3":
                    {
                        AnswerTypeRange m_AnserTypeRange = new AnswerTypeRange
                        {
                            Min = ac.PreferenceRangeMin,
                            Max = ac.PreferenceRangeMax
                        };

                        m_PhilosophyUserAnswer = new PhilosophyUserAnswer().UpdatePhilosophyUserPreference(ac.Philosophy_id, UserID, m_AnserTypeRange, ac.HasAllPreferencesSelected);
                        break;
                    }
                case "4":
                    {
                        AnswerTypeRange m_AnserTypeRange = new AnswerTypeRange
                        {
                            Min = ac.PreferenceRangeMin,
                            Max = ac.PreferenceRangeMax
                        };

                        m_PhilosophyUserAnswer = new PhilosophyUserAnswer().UpdatePhilosophyUserPreference(ac.Philosophy_id, UserID, m_AnserTypeRange, ac.HasAllPreferencesSelected);
                        break;
                    }
            }

            m_PhilosophyUserAnswer = new PhilosophyUserAnswer().UpdatePhilosophyUserComment(UserID, ac.Philosophy_id, ac.Comment);
            return m_PhilosophyUserAnswer;
        }

    }

    public class AddPhilosophyUserAnswer
    {
        public string Philosophy_id { get; set; }

        public string PhilosophyType { get; set; }

        public string PhilosophyPreferenceType { get; set; }

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