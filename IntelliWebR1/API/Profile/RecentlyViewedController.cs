using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API
{
    public class RecentlyViewedController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<ProfileView> Get()
        {
            int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            ProfileView[] m_ProfileViews = new ProfileView().GetProfileViews(_UserID);

            m_ProfileViews = m_ProfileViews.Take(15).ToArray();

            foreach (ProfileView _EachProfileView in m_ProfileViews)
            {
                if (_EachProfileView.OtherUserDetails.ProfilePhoto != null)
                {
                    string PhotoPath = ConfigurationManager.AppSettings["PhotosFolder"].ToString() + _EachProfileView.OtherUserDetails.ProfilePhoto.PhotoPath;
                    _EachProfileView.OtherUserDetails.ProfilePhoto.EncryptPath = new EncryptDecrypt().Encrypt(PhotoPath + "&100&100");
                }

            }

            return m_ProfileViews;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {

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
}
