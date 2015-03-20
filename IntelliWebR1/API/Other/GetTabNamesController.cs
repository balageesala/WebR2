using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntelliWebR1.API
{
    public class GetTabNamesController : ApiController
    {

        public List<string> Post(OtherUser _OtherUserObj)
        {
            try
            {
                string _res;
                DescriptionAnswers[] _DescriptionAnswers = new DescriptionAnswers().GetAnswers(_OtherUserObj.OtherUserID);
                _DescriptionAnswers = _DescriptionAnswers.Where(x => x.Answer.Trim() != "").ToArray();
                Photo[] _photos = new Photo().GetApprovedUserPhotos(_OtherUserObj.OtherUserID);
                CriteriaUserAnswer[] _criteria = new CriteriaUserAnswer().GetCriteriaUserAnswers(_OtherUserObj.OtherUserID);
                if (_criteria != null)
                {
                    _criteria = _criteria.Where(x => x.UserOption != null || x.UserOptionDate != null || x.UserOptionMultiple != null || x.UserText != null || x.UserPreferenceMultiple != null || x.UserPreferenceRange != null).ToArray();
                }
                QuestionAnswers<OptionsSingleSelectAnswer, OptionsMultiSelectAnswer>[] _questionAns = new QuestionAnswers<OptionsSingleSelectAnswer, OptionsMultiSelectAnswer>().GetUserAnswers(_OtherUserObj.OtherUserID);

                List<string> _lstTabs = new List<string>();
                if (_DescriptionAnswers.Count()>0)
                {
                    _lstTabs.Add("aboutme");
                }
                if (_photos.Count()>0)
                {
                    _lstTabs.Add("photos");
                }
                if (_criteria.Count()>0)
                {
                    _lstTabs.Add("criteria");
                }
                if (_questionAns.Count() > 0)
                {
                    _lstTabs.Add("questions");
                }

                return _lstTabs;


            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }


    public class OtherUser
    {
        public int OtherUserID { get; set; }
    }
}
