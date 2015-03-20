using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IntellidateR1Web.web
{
    public partial class MatchsHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadCurrentMatchs();
                LoadRematchedThem();
                LoadRematchedYou();
                LoadPostMatches();
            }
        }

        private void LoadCurrentMatchs()
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                UserTodayMatch[] m_UserLastSevenMatches = new UserTodayMatch().GetRecentSixDaysMatchs(UserID);

                if (m_UserLastSevenMatches != null)
                {
                    if (m_UserLastSevenMatches.Count() > 0)
                    {
                        List<UserTodayMatch> LstMatchs = new List<UserTodayMatch>();

                        List<DateTime> DateList = new List<DateTime>();

                        DateTime _CurrentTime = DateTime.Now;
                        if (_CurrentTime.Hour < 12)
                        {
                            for (int i = 1; i < 8; i++)
                            {
                                DateList.Add(DateTime.Now.AddDays(-i));
                            }
                        }
                        else
                        {
                            for (int i = 0; i < 7; i++)
                            {
                                DateList.Add(DateTime.Now.AddDays(-i));
                            }
                        }
                        UserTodayMatch _Matches;
                        foreach (DateTime _Today in DateList)
                        {
                            _Matches = new UserTodayMatch();
                            _Matches.DateTime = _Today;
                            LstMatchs.Add(_Matches);
                        }
                        bool IsMatchedDate = false;
                        foreach (var _DateMatch in LstMatchs)
                        {
                            foreach (var _ThisRealMatch in m_UserLastSevenMatches)
                            {
                                if (_DateMatch.DateTime.Date == _ThisRealMatch.DateTime.Date)
                                {
                                    IsMatchedDate = true;
                                    _DateMatch._id = _ThisRealMatch._id;
                                    _DateMatch.DateTime = _ThisRealMatch.DateTime;
                                    _DateMatch.UserID = _ThisRealMatch.UserID;
                                    _DateMatch.MatchUserID = _ThisRealMatch.MatchUserID;
                                    _DateMatch.TodayMatchID = _ThisRealMatch.TodayMatchID;
                                    _DateMatch.Status = _ThisRealMatch.Status;
                                }
                            }
                        }
                        if (IsMatchedDate)
                        {
                            divCurrentMatchs.Visible = true;
                            rptCurrentMatches.ItemDataBound += rptCurrentMatches_ItemDataBound;
                            rptCurrentMatches.DataSource = LstMatchs;
                            rptCurrentMatches.DataBind();
                        }


                    }
                }
            }
            catch (Exception)
            {
             
            }
        }



        private void LoadRematchedThem()
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                ProfileRematch[] m_UserLastSevenMatches = new ProfileRematch().GetReMatchedThemRecentMatchs(UserID);
                if (m_UserLastSevenMatches.Count() > 0)
                {

                    List<ProfileRematch> LstMatchs = new List<ProfileRematch>();

                    List<DateTime> DateList = new List<DateTime>();

                    DateTime _CurrentTime = DateTime.Now;
                    if (_CurrentTime.Hour < 12)
                    {
                        for (int i = 1; i < 8; i++)
                        {
                            DateList.Add(DateTime.Now.AddDays(-i));
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            DateList.Add(DateTime.Now.AddDays(-i));
                        }
                    }


                    ProfileRematch _Matches;
                    foreach (DateTime _Today in DateList)
                    {
                        _Matches = new ProfileRematch();
                        _Matches.MatchedDate = _Today;
                        LstMatchs.Add(_Matches);
                    }

                    bool IsMatchedDate = false;
                    foreach (var _DateMatch in LstMatchs)
                    {
                        foreach (var _ThisRealMatch in m_UserLastSevenMatches)
                        {
                            if (_DateMatch.MatchedDate.Date == _ThisRealMatch.MatchedDate.Date)
                            {
                                IsMatchedDate = true;
                                _DateMatch._id = _ThisRealMatch._id;
                                _DateMatch.MatchedDate = _ThisRealMatch.MatchedDate;
                                _DateMatch.UserID = _ThisRealMatch.UserID;
                                _DateMatch.MatchUserID = _ThisRealMatch.MatchUserID;
                                _DateMatch.ReMatchID = _ThisRealMatch.ReMatchID;
                                _DateMatch.Status = _ThisRealMatch.Status;
                            }
                        }
                    }
                    if (IsMatchedDate)
                    {
                        divRematchedThem.Visible = true;
                        rptRematchedThem.ItemDataBound += rptRematchedThem_ItemDataBound;
                        rptRematchedThem.DataSource = LstMatchs;
                        rptRematchedThem.DataBind();
                    }


                }

            }
            catch (Exception)
            {

            }
        }


        private void LoadRematchedYou()
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                ProfileRematch[] m_UserLastSevenMatches = new ProfileRematch().GetReMatchedYouRecentMatchs(UserID);
                if (m_UserLastSevenMatches.Count() > 0)
                {
                    List<ProfileRematch> LstMatchs = new List<ProfileRematch>();
                    List<DateTime> DateList = new List<DateTime>();

                    DateTime _CurrentTime = DateTime.Now;
                    if (_CurrentTime.Hour < 12)
                    {
                        for (int i = 1; i < 8; i++)
                        {
                            DateList.Add(DateTime.Now.AddDays(-i));
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            DateList.Add(DateTime.Now.AddDays(-i));
                        }
                    }
                    ProfileRematch _Matches;
                    foreach (DateTime _Today in DateList)
                    {
                        _Matches = new ProfileRematch();
                        _Matches.MatchedDate = _Today;
                        LstMatchs.Add(_Matches);
                    }
                    bool IsMatchedDate = false;
                    foreach (var _DateMatch in LstMatchs)
                    {
                        foreach (var _ThisRealMatch in m_UserLastSevenMatches)
                        {
                            if (_DateMatch.MatchedDate.Date == _ThisRealMatch.MatchedDate.Date)
                            {
                                IsMatchedDate = true;
                                _DateMatch._id = _ThisRealMatch._id;
                                _DateMatch.MatchedDate = _ThisRealMatch.MatchedDate;
                                _DateMatch.UserID = _ThisRealMatch.UserID;
                                _DateMatch.MatchUserID = _ThisRealMatch.MatchUserID;
                                _DateMatch.ReMatchID = _ThisRealMatch.ReMatchID;
                                _DateMatch.Status = _ThisRealMatch.Status;
                            }
                        }
                    }
                    if (IsMatchedDate)
                    {
                        divRematchedYou.Visible = true;
                        rptRematchedYou.ItemDataBound += rptRematchedThem_ItemDataBound;
                        rptRematchedYou.DataSource = LstMatchs;
                        rptRematchedYou.DataBind();
                    }
                }

            }
            catch (Exception)
            {

            }
        }


        private void LoadPostMatches()
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                UserTodayMatch[] m_UserTodayMatches = new UserTodayMatch().GetAllMatches(UserID);
                UserTodayMatch[] m_UserLastSevenMatches = new UserTodayMatch().GetRecentSixDaysMatchs(UserID);

                List<UserTodayMatch> _Rematchs = new List<UserTodayMatch>();
                foreach (UserTodayMatch _TodayMatch in m_UserTodayMatches)
                {
                    UserTodayMatch[] _WithInBank = m_UserLastSevenMatches.Where(x => x._id == _TodayMatch._id).ToArray();
                    if (_WithInBank.Count() == 0)
                    {
                        //check if user deleted or not


                        //check if user blocked with this user
                        bool IsUserBlocked = new BlockUser().IsUserBlocked(_TodayMatch.MatchUserID, _TodayMatch.UserID);
                        bool IsFemaleReplayed = false;
                        //check if femail reply to male if male send a message
                        if (_TodayMatch.MatchUser.Gender == 2)
                        {
                            IsFemaleReplayed = new Conversation().IsSheReplayedToMale(_TodayMatch.MatchUserID, _TodayMatch.UserID);
                        }
                        else
                        {
                            IsFemaleReplayed = new Conversation().IsSheReplayedToMale(_TodayMatch.UserID, _TodayMatch.MatchUserID);
                        }

                        if (IsUserBlocked && IsFemaleReplayed)
                        {
                            _Rematchs.Add(_TodayMatch);
                        }
                    }
                }

                if (m_UserTodayMatches.Count() > 0)
                {
                    divPostMatchs.Visible = true;
                    List<UserTodayMatch> LstMatchs = _Rematchs;
                    rptPostMathcs.ItemDataBound += rptPostMathcs_ItemDataBound;
                    rptPostMathcs.DataSource = LstMatchs;
                    rptPostMathcs.DataBind();
                }

            }
            catch (Exception)
            {

            }
        }

        void rptPostMathcs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                UserTodayMatch m_UserTodayMatch = (UserTodayMatch)e.Item.DataItem;
                string SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                ProfileRematch _ThisRematch = new ProfileRematch().GetProfileRemtch(m_UserTodayMatch.MatchUserID, m_UserTodayMatch.UserID);
                string m_month = m_UserTodayMatch.DateTime.Month.ToString();
                string m_day = m_UserTodayMatch.DateTime.Day.ToString();
                string m_year = m_UserTodayMatch.DateTime.Year.ToString();

                if (_ThisRematch != null)
                {
                    ((HtmlGenericControl)e.Item.FindControl("divDate")).InnerText = m_month + "." + m_day + "." + m_year;
                    ((HtmlGenericControl)e.Item.FindControl("divRematchedDate")).Visible = true;
                    if (m_UserTodayMatch.UserID == UserID)
                    {
                        ((HtmlImage)e.Item.FindControl("imgMatchImage")).Alt = m_UserTodayMatch.MatchUser.LoginName;
                        ((HtmlImage)e.Item.FindControl("imgMatchImage")).Attributes.Add("title", m_UserTodayMatch.MatchUser.LoginName);
                        ((HtmlGenericControl)e.Item.FindControl("divRematchID")).Visible = false;
                        ((HtmlGenericControl)e.Item.FindControl("divRematchedDate")).InnerText = _ThisRematch.MatchedDate.Month + "." + _ThisRematch.MatchedDate.Day + "." + _ThisRematch.MatchedDate.Year;
                   
                        //Attributes.Add("title", m_UserTodayMatch.MatchUserID.ToString());

                        if (m_UserTodayMatch.MatchUser.ProfilePhoto != null)
                        {
                            string _MatchUserPhoto = new Utils().GetPhotoPCTPath(m_UserTodayMatch.MatchUser.ProfilePhoto.PhotoID, Page.Request);
                            ((HtmlImage)e.Item.FindControl("imgMatchImage")).Src = _MatchUserPhoto;
                        }
                        else
                        {
                            string _DefaultUserPhoto = string.Empty;
                            if (m_UserTodayMatch.MatchUser.Gender == 1)
                            {
                                _DefaultUserPhoto = SitePath + "web/images/M.png";
                            }
                            else
                            {
                                _DefaultUserPhoto = SitePath + "web/images/F.png";
                            }
                            ((HtmlImage)e.Item.FindControl("imgMatchImage")).Src = _DefaultUserPhoto;
                        }
                    }
                    else
                    {
                        ((HtmlImage)e.Item.FindControl("imgMatchImage")).Alt = m_UserTodayMatch.ThisUser.LoginName;
                        ((HtmlImage)e.Item.FindControl("imgMatchImage")).Attributes.Add("title", m_UserTodayMatch.ThisUser.LoginName);
                        ((HtmlGenericControl)e.Item.FindControl("divRematchID")).Visible = false;
                        ((HtmlGenericControl)e.Item.FindControl("divRematchedDate")).InnerText = _ThisRematch.MatchedDate.Month + "." + _ThisRematch.MatchedDate.Day + "." + _ThisRematch.MatchedDate.Year;
                   
                        if (m_UserTodayMatch.ThisUser.ProfilePhoto != null)
                        {
                            string _MatchUserPhoto = new Utils().GetPhotoPCTPath(m_UserTodayMatch.ThisUser.ProfilePhoto.PhotoID, Page.Request);
                            ((HtmlImage)e.Item.FindControl("imgMatchImage")).Src = _MatchUserPhoto;

                        }
                        else
                        {
                            string _DefaultUserPhoto = string.Empty;
                            if (m_UserTodayMatch.ThisUser.Gender == 1)
                            {
                                _DefaultUserPhoto = SitePath + "web/images/M.png";
                            }
                            else
                            {
                                _DefaultUserPhoto = SitePath + "web/images/F.png";
                            }
                            ((HtmlImage)e.Item.FindControl("imgMatchImage")).Src = _DefaultUserPhoto;
                        }
                    }
                }
                else
                {
                    ((HtmlGenericControl)e.Item.FindControl("divDate")).InnerText = m_month + "." + m_day + "." + m_year;
                    if (m_UserTodayMatch.UserID == UserID)
                    {
                        ((HtmlImage)e.Item.FindControl("imgMatchImage")).Alt = m_UserTodayMatch.MatchUser.LoginName;
                        ((HtmlImage)e.Item.FindControl("imgMatchImage")).Attributes.Add("title", m_UserTodayMatch.MatchUser.LoginName);
                        ((HtmlGenericControl)e.Item.FindControl("divRematchID")).Attributes.Add("data-id", m_UserTodayMatch.MatchUserID.ToString());
                        //Attributes.Add("title", m_UserTodayMatch.MatchUserID.ToString());

                        if (m_UserTodayMatch.MatchUser.ProfilePhoto != null)
                        {
                            string _MatchUserPhoto = new Utils().GetPhotoPCTPath(m_UserTodayMatch.MatchUser.ProfilePhoto.PhotoID, Page.Request);
                            ((HtmlImage)e.Item.FindControl("imgMatchImage")).Src = _MatchUserPhoto;
                        }
                        else
                        {
                            string _DefaultUserPhoto = string.Empty;
                            if (m_UserTodayMatch.MatchUser.Gender == 1)
                            {
                                _DefaultUserPhoto = SitePath + "web/images/M.png";
                            }
                            else
                            {
                                _DefaultUserPhoto = SitePath + "web/images/F.png";
                            }
                            ((HtmlImage)e.Item.FindControl("imgMatchImage")).Src = _DefaultUserPhoto;
                        }
                    }
                    else
                    {
                        ((HtmlImage)e.Item.FindControl("imgMatchImage")).Alt = m_UserTodayMatch.ThisUser.LoginName;
                        ((HtmlImage)e.Item.FindControl("imgMatchImage")).Attributes.Add("title", m_UserTodayMatch.ThisUser.LoginName);
                        ((HtmlGenericControl)e.Item.FindControl("divRematchID")).Attributes.Add("data-id", m_UserTodayMatch.UserID.ToString());

                        if (m_UserTodayMatch.ThisUser.ProfilePhoto != null)
                        {
                            string _MatchUserPhoto = new Utils().GetPhotoPCTPath(m_UserTodayMatch.ThisUser.ProfilePhoto.PhotoID, Page.Request);
                            ((HtmlImage)e.Item.FindControl("imgMatchImage")).Src = _MatchUserPhoto;

                        }
                        else
                        {
                            string _DefaultUserPhoto = string.Empty;
                            if (m_UserTodayMatch.ThisUser.Gender == 1)
                            {
                                _DefaultUserPhoto = SitePath + "web/images/M.png";
                            }
                            else
                            {
                                _DefaultUserPhoto = SitePath + "web/images/F.png";
                            }
                            ((HtmlImage)e.Item.FindControl("imgMatchImage")).Src = _DefaultUserPhoto;
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        void rptCurrentMatches_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                UserTodayMatch m_UserTodayMatch = (UserTodayMatch)e.Item.DataItem;
                string SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();

                if (m_UserTodayMatch.ThisUser != null)
                {
                    int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                    string m_month = m_UserTodayMatch.DateTime.Month.ToString();
                    string m_day = m_UserTodayMatch.DateTime.Day.ToString();
                    string m_year = m_UserTodayMatch.DateTime.Year.ToString();

                    ((HtmlGenericControl)e.Item.FindControl("divDate")).InnerText = m_month + "." + m_day + "." + m_year;
                    if (m_UserTodayMatch.UserID == UserID)
                    {
                        ((HtmlImage)e.Item.FindControl("imgMatchImage")).Alt = m_UserTodayMatch.MatchUser.LoginName;
                        ((HtmlImage)e.Item.FindControl("imgMatchImage")).Attributes.Add("title", m_UserTodayMatch.MatchUser.LoginName);
                        ((HtmlImage)e.Item.FindControl("imgMatchImage")).Visible = true;

                        if (m_UserTodayMatch.MatchUser.ProfilePhoto != null)
                        {
                            string _MatchUserPhoto = new Utils().GetPhotoPCTPath(m_UserTodayMatch.MatchUser.ProfilePhoto.PhotoID, Page.Request);
                            ((HtmlImage)e.Item.FindControl("imgMatchImage")).Src = _MatchUserPhoto;
                            
                        }
                        else
                        {
                            string _DefaultUserPhoto = string.Empty;
                            if (m_UserTodayMatch.MatchUser.Gender == 1)
                            {
                                _DefaultUserPhoto = SitePath + "web/images/M.png";
                            }
                            else
                            {
                                _DefaultUserPhoto = SitePath + "web/images/F.png";
                            }
                            ((HtmlImage)e.Item.FindControl("imgMatchImage")).Src = _DefaultUserPhoto;
                        }
                    }
                    else
                    {
                        ((HtmlImage)e.Item.FindControl("imgMatchImage")).Alt = m_UserTodayMatch.ThisUser.LoginName;
                        ((HtmlImage)e.Item.FindControl("imgMatchImage")).Attributes.Add("title", m_UserTodayMatch.ThisUser.LoginName);
                        ((HtmlImage)e.Item.FindControl("imgMatchImage")).Visible = true;

                        if (m_UserTodayMatch.ThisUser.ProfilePhoto != null)
                        {
                            string _MatchUserPhoto = new Utils().GetPhotoPCTPath(m_UserTodayMatch.ThisUser.ProfilePhoto.PhotoID, Page.Request);
                            ((HtmlImage)e.Item.FindControl("imgMatchImage")).Src = _MatchUserPhoto;

                        }
                        else
                        {
                            string _DefaultUserPhoto = string.Empty;
                            if (m_UserTodayMatch.ThisUser.Gender == 1)
                            {
                                _DefaultUserPhoto = SitePath + "web/images/M.png";
                            }
                            else
                            {
                                _DefaultUserPhoto = SitePath + "web/images/F.png";
                            }
                            ((HtmlImage)e.Item.FindControl("imgMatchImage")).Src = _DefaultUserPhoto;
                        }
                    }
                }
                else
                {
                    string m_month = m_UserTodayMatch.DateTime.Month.ToString();
                    string m_day = m_UserTodayMatch.DateTime.Day.ToString();
                    string m_year = m_UserTodayMatch.DateTime.Year.ToString();

                    ((HtmlGenericControl)e.Item.FindControl("divDate")).InnerText = m_month + "." + m_day + "." + m_year;

                }

               
            }
            catch (Exception)
            {

            }
        }



        void rptRematchedThem_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                ProfileRematch m_ProfileReMatch = (ProfileRematch)e.Item.DataItem;
                string SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();

                if (m_ProfileReMatch.ThisUser != null)
                {
                    int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                    string m_month = m_ProfileReMatch.MatchedDate.Month.ToString();
                    string m_day = m_ProfileReMatch.MatchedDate.Day.ToString();
                    string m_year = m_ProfileReMatch.MatchedDate.Year.ToString();

                    ((HtmlGenericControl)e.Item.FindControl("divDate")).InnerText = m_month + "." + m_day + "." + m_year;
                    if (m_ProfileReMatch.UserID == UserID)
                    {
                        ((HtmlImage)e.Item.FindControl("imgMatchImage")).Alt = m_ProfileReMatch.MatchUser.LoginName;
                        ((HtmlImage)e.Item.FindControl("imgMatchImage")).Attributes.Add("title", m_ProfileReMatch.MatchUser.LoginName);
                        ((HtmlImage)e.Item.FindControl("imgMatchImage")).Visible = true;

                        if (m_ProfileReMatch.MatchUser.ProfilePhoto != null)
                        {
                            string _MatchUserPhoto = new Utils().GetPhotoPCTPath(m_ProfileReMatch.MatchUser.ProfilePhoto.PhotoID, Page.Request);
                            ((HtmlImage)e.Item.FindControl("imgMatchImage")).Src = _MatchUserPhoto;

                        }
                        else
                        {
                            string _DefaultUserPhoto = string.Empty;
                            if (m_ProfileReMatch.MatchUser.Gender == 1)
                            {
                                _DefaultUserPhoto = SitePath + "web/images/M.png";
                            }
                            else
                            {
                                _DefaultUserPhoto = SitePath + "web/images/F.png";
                            }
                            ((HtmlImage)e.Item.FindControl("imgMatchImage")).Src = _DefaultUserPhoto;
                        }
                    }
                    else
                    {
                        ((HtmlImage)e.Item.FindControl("imgMatchImage")).Alt = m_ProfileReMatch.ThisUser.LoginName;
                        ((HtmlImage)e.Item.FindControl("imgMatchImage")).Attributes.Add("title", m_ProfileReMatch.ThisUser.LoginName);
                        ((HtmlImage)e.Item.FindControl("imgMatchImage")).Visible = true;

                        if (m_ProfileReMatch.ThisUser.ProfilePhoto != null)
                        {
                            string _MatchUserPhoto = new Utils().GetPhotoPCTPath(m_ProfileReMatch.ThisUser.ProfilePhoto.PhotoID, Page.Request);
                            ((HtmlImage)e.Item.FindControl("imgMatchImage")).Src = _MatchUserPhoto;

                        }
                        else
                        {
                            string _DefaultUserPhoto = string.Empty;
                            if (m_ProfileReMatch.ThisUser.Gender == 1)
                            {
                                _DefaultUserPhoto = SitePath + "web/images/M.png";
                            }
                            else
                            {
                                _DefaultUserPhoto = SitePath + "web/images/F.png";
                            }
                            ((HtmlImage)e.Item.FindControl("imgMatchImage")).Src = _DefaultUserPhoto;
                        }
                    }
                }
                else
                {
                    string m_month = m_ProfileReMatch.MatchedDate.Month.ToString();
                    string m_day = m_ProfileReMatch.MatchedDate.Day.ToString();
                    string m_year = m_ProfileReMatch.MatchedDate.Year.ToString();
                    ((HtmlGenericControl)e.Item.FindControl("divDate")).InnerText = m_month + "." + m_day + "." + m_year;

                }


            }
            catch (Exception)
            {

            }
        }

        


        public DateTime EndOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }

        public DateTime StartOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }
    }
}