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
    public class SaveProfileController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public bool Get(string OtherUserID)
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                bool _Return = new ProfileSave().IsProfileSaved(_UserID, Convert.ToInt32(OtherUserID));
                return _Return;
            }
            catch (Exception)
            {
                return false;
            }

        }

        // POST api/<controller>
        public int Post([FromBody]ProfileSaveData ProfileSaveData)
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                bool _Return = false;
                if (ProfileSaveData.SaveType == "check")
                {
                    _Return = new ProfileSave().IsProfileSaved(_UserID, ProfileSaveData.OtherUserID);
                    if (_Return)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (ProfileSaveData.SaveType == "save")
                {
                    bool IsSavingAnonymously = false;

                    _Return = new ProfileSave().SaveProfile(_UserID, ProfileSaveData.OtherUserID, IsSavingAnonymously);
                    if (_Return)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    _Return = new ProfileSave().UnsaveProfile(_UserID, ProfileSaveData.OtherUserID);
                    if (_Return)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            catch (Exception)
            {
                return 0;
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
    public class ProfileSaveData
    {
        public int OtherUserID { get; set; }
        public string SaveType { get; set; }
    }
}
