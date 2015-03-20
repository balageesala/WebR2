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
    public class ViewedProfilesController : ApiController
    {
        // Getting who viewed me profiles  api/<controller>
        public List<ViewedProfileClass> Post(ThisProfile _ObjProfile)
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                if (_ObjProfile.MethodName == "WHO")
                {
                    ProfileView[] _ProfileViews = new ProfileView().GetMyProfileViews(_UserID);
                    List<ViewedProfileClass> _lstResult = GetProfileViewes(_ProfileViews);
                    return _lstResult;
                }
                else
                {
                    ProfileView[] _ObjProfiles = new ProfileView().GetProfileViews(_UserID);
                    List<ViewedProfileClass> _lstUserProfiles = new List<ViewedProfileClass>();
                    ViewedProfileClass _ObjViewedProfile;
                    ProfileView[] _ProfileViews = _ObjProfiles.GroupBy(x => x.OtherUserRefID).Select(y => y.First()).ToArray();
                    string SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
                    foreach (var item in _ProfileViews)
                    {

                        _ObjViewedProfile = new ViewedProfileClass();
                        _ObjViewedProfile.TotalViews = _ObjProfiles.Count().ToString();
                        _ObjViewedProfile.LoginName = item.OtherUserDetails.LoginName;
                        if (item.OtherUserDetails.IsUserOnline)
                        {
                            _ObjViewedProfile.OnlinePhoto = SitePath + "web/images/glassy_button_green.png";
                        }
                        else
                        {
                            //imgOtherUser_Online.Src = SitePath + "web/images/glassy_button_grey.png";
                        }
                        if (item.OtherUserDetails.ProfilePhoto != null)
                        {
                            string PhotoPath = ConfigurationManager.AppSettings["PhotosFolder"].ToString() + item.OtherUserDetails.ProfilePhoto.PhotoPath;
                            string EncriptData = new IntellidateR1.EncryptDecrypt().Encrypt(PhotoPath + "&120&120");
                            _ObjViewedProfile.UserPhoto = SitePath + "web/PhotoView?ImagePath=" + EncriptData;
                        }
                        _ObjViewedProfile.Matchp = item.Matchp;
                        _ObjViewedProfile.MatchpPhoto = SitePath + "web/Percentage?v=" + item.Matchp;

                        int _EachViewCount = _ObjProfiles.Where(x => x.UserRefID == item.OtherUserRefID).Count();

                        if (_EachViewCount == 1)
                        {
                            _ObjViewedProfile.EachViewCountText = "1 time";
                        }
                        else if (_EachViewCount == 2)
                        {
                            _ObjViewedProfile.EachViewCountText = "2 times";
                        }
                        else
                        {
                            _ObjViewedProfile.EachViewCountText = "3 or more times";
                        }
                        _ObjViewedProfile.LastOnline = "";
                        if (item.OtherUserDetails.IsUserOnline)
                        {
                            _ObjViewedProfile.OnlinePhoto = SitePath + "web/images/glassy_button_green.png";
                        }
                        else
                        {
                            _ObjViewedProfile.OnlinePhoto = "";
                        }
                        _lstUserProfiles.Add(_ObjViewedProfile);
                    }
                    return _lstUserProfiles;
                }
               
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<ViewedProfileClass> GetProfileViewes(ProfileView [] _ObjProfiles)
        {
            try
            {
                List<ViewedProfileClass> _lstUserProfiles = new List<ViewedProfileClass>();
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                ViewedProfileClass _ObjViewedProfile;
                ProfileView[] _ProfileViews = _ObjProfiles.GroupBy(x => x.UserRefID).Select(y => y.First()).ToArray();
                string SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
                foreach (var item in _ProfileViews)
                {

                    _ObjViewedProfile = new ViewedProfileClass();
                    _ObjViewedProfile.TotalViews = _ObjProfiles.Count().ToString();
                    var _OtherUserDetails = new IntellidateR1.User().GetUserDetails(item.UserRefID);
                    _ObjViewedProfile.LoginName = _OtherUserDetails.LoginName;
                    string _MutualPercentage = new PhilosophyMatch().GetOverallMatchPercentage(_UserID, item.UserRefID).ToString();
                    if (_OtherUserDetails.IsUserOnline)
                    {
                        _ObjViewedProfile.OnlinePhoto = SitePath + "web/images/glassy_button_green.png";
                    }
                    else
                    {
                        //imgOtherUser_Online.Src = SitePath + "web/images/glassy_button_grey.png";
                    }
                    if (_OtherUserDetails.ProfilePhoto != null)
                    {
                        string PhotoPath = ConfigurationManager.AppSettings["PhotosFolder"].ToString() + _OtherUserDetails.ProfilePhoto.PhotoPath;
                        string EncriptData = new IntellidateR1.EncryptDecrypt().Encrypt(PhotoPath + "&120&120");
                        _ObjViewedProfile.UserPhoto = SitePath + "web/PhotoView?ImagePath=" + EncriptData;
                    }
                    _ObjViewedProfile.Matchp = _MutualPercentage;
                    _ObjViewedProfile.MatchpPhoto = SitePath + "web/Percentage?v=" + _MutualPercentage;

                    int _EachViewCount = _ObjProfiles.Where(x => x.UserRefID == item.UserRefID).Count();

                    if (_EachViewCount == 1)
                    {
                        _ObjViewedProfile.EachViewCountText = "1 time";
                    }
                    else if (_EachViewCount == 2)
                    {
                        _ObjViewedProfile.EachViewCountText = "2 times";
                    }
                    else
                    {
                        _ObjViewedProfile.EachViewCountText = "3 or more times";
                    }
                    _ObjViewedProfile.LastOnline = "";
                    if (_OtherUserDetails.IsUserOnline)
                    {
                        _ObjViewedProfile.OnlinePhoto = SitePath + "web/images/glassy_button_green.png";
                    }
                    else
                    {
                        _ObjViewedProfile.OnlinePhoto = "";
                    }
                    _lstUserProfiles.Add(_ObjViewedProfile);
                }
                return _lstUserProfiles;
            }
            catch (Exception)
            {
                return null;
            }
        }





    }

    public class ViewedProfileClass
    {
        public string LoginName { get; set; }
        public string UserPhoto { get; set; }
        public string Matchp { get; set; }
        public string MatchpPhoto { get; set; }
        public string EachViewCountText { get; set; }
        public string LastOnline { get; set; }
        public string OnlinePhoto { get; set; }
        public string TotalViews { get; set; }
    }


    public class ThisProfile
    {
        public string MethodName { get; set; }
    }


}
