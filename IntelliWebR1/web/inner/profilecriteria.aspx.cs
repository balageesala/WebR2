using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntellidateR1;
using System.Globalization;
using System.Text;

namespace IntelliWebR1.web.inner
{
    public partial class profilecriteria : System.Web.UI.Page
    {
        public string OtherUserID { get; set; }
        public string OtherUserGenderID { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["OtherUserID"] != null)
            {
                OtherUserID = Request.QueryString["OtherUserID"].ToString();
            }

            if (Request.QueryString["OtherUserGenderID"] != null)
            {
                OtherUserGenderID = Request.QueryString["OtherUserGenderID"].ToString();
            }

            if (!Page.IsPostBack)
            {
                FillCriteriaMatch();
            }
        }


        List<CriteriaMatch> _OtherUserCriteriaMatchNew;
        private void FillCriteriaMatch()
        {
            int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

            List<CriteriaMatch> _CriteriaMatch = new List<CriteriaMatch>();
            _CriteriaMatch = new CriteriaMatch().GetCriteriaMatch(_UserID, Convert.ToInt32(OtherUserID)).ToList();
            _CriteriaMatch = _CriteriaMatch.OrderByDescending(x => x.PointsAssigned).ToList();

           
          
            foreach (CriteriaMatch _EachMatch in _CriteriaMatch)
            {
                if (_EachMatch.CriteriaType == 9)
                {
                    //set distance range
                    string PostCodeA = _EachMatch.OtherUser.ZipCode;
                    string PostCodeB = _EachMatch.User.ZipCode;
                    double? DistanceFrom = Distance.BetweenTwoPostCodesInMiles(PostCodeA, PostCodeB);
                    if (DistanceFrom != null)
                    {
                        string _distance = string.Format("{0:0.00}", DistanceFrom);
                        _EachMatch.OtherUserValue = _distance + " miles.";
                    }
                    else
                    {
                        _EachMatch.OtherUserValue = "";
                    }
                }

                if (_EachMatch.UserPreferences == "")
                {
                    _EachMatch.UserPreferences = "No Answer";
                }
            }

            decimal _TotalPointsAssigned = 0;
            decimal _TotalPointsAwarded = 0;
            foreach (var item in _CriteriaMatch)
            {
                _TotalPointsAssigned = _TotalPointsAssigned + item.PointsAssigned;
                _TotalPointsAwarded = _TotalPointsAwarded + item.PointsAwarded;
            }

            _CriteriaMatch = _CriteriaMatch.OrderBy(x => x.CriteriaName).OrderByDescending(x => x.PointsAssigned).ToList();
                //.GroupBy(x => x.CriteriaName).OrderBy(x => x.First().CriteriaName).SelectMany(x => x).ToList();
                //
            _CriteriaMatch.Add(new CriteriaMatch { Criteria_id = "", CriteriaName = "", CriteriaQuestion = "", CriteriaType = 0, UserPreferences = "", OtherUserValue = "", PointsAwarded = _TotalPointsAwarded, PointsAssigned = _TotalPointsAssigned, IsMatch = true });



            dgCriteriaTable.DataSource = _CriteriaMatch;
            dgCriteriaTable.DataBind();


            List<CriteriaMatch> _OtherUserCriteriaMatch = new List<CriteriaMatch>();
            _OtherUserCriteriaMatch = new CriteriaMatch().GetCriteriaMatch(Convert.ToInt32(OtherUserID), _UserID).ToList();
            _OtherUserCriteriaMatch = _OtherUserCriteriaMatch.OrderByDescending(x => x.PointsAssignedByOtherUser).ToList();

            _OtherUserCriteriaMatchNew = new List<CriteriaMatch>();

            foreach (CriteriaMatch _EachMatch in _OtherUserCriteriaMatch)
            {

                if (_EachMatch.CriteriaType == 9)
                {
                   //set distance range
                   string PostCodeA = _EachMatch.OtherUser.ZipCode;
                   string PostCodeB = _EachMatch.User.ZipCode;
                   double? DistanceFrom = Distance.BetweenTwoPostCodesInMiles(PostCodeA, PostCodeB);
                   if (DistanceFrom != null)
                   {
                       string _distance = string.Format("{0:0.00}", DistanceFrom);
                       _EachMatch.OtherUserValue = _distance + " miles.";
                   }
                   else
                   {
                       _EachMatch.OtherUserValue = "";
                   }
                }
                if (_EachMatch.OtherUserValue == "")
                {
                    _EachMatch.OtherUserValue = "No Answer";
                }

                bool _Isadd = false;

                if (_EachMatch.CriteriaName.ToLower().IndexOf("race/ethnicity") != -1)
                {
                    _Isadd = true;
                }
                if (_EachMatch.CriteriaName.ToLower().IndexOf("hair color") != -1)
                {
                    _Isadd = true;
                }
                if (_EachMatch.CriteriaName.ToLower().IndexOf("eye color") != -1)
                {
                    _Isadd = true;
                }
                if (_EachMatch.CriteriaName.ToLower().IndexOf("salary") != -1 || _EachMatch.CriteriaName.ToLower().IndexOf("income") != -1)
                {
                    _Isadd = true;
                }
                if (!_Isadd)
                {
                    _OtherUserCriteriaMatchNew.Add(_EachMatch);
                }

            }

            decimal _TotalPointsAssigned2 = 0;
            decimal _TotalPointsAwarded2 = 0;
            foreach (var item in _OtherUserCriteriaMatch)
            {
                _TotalPointsAssigned2 = _TotalPointsAssigned2 + item.PointsAssigned;
                _TotalPointsAwarded2 = _TotalPointsAwarded2 + item.PointsAwarded;
            }

            _OtherUserCriteriaMatchNew = _OtherUserCriteriaMatchNew.OrderBy(x => x.CriteriaName).OrderByDescending(x => x.PointsAssigned).ToList();
            _OtherUserCriteriaMatchNew.Add(new CriteriaMatch { Criteria_id = "", CriteriaName = "", CriteriaQuestion = "", CriteriaType = 0, UserPreferences = "", OtherUserValue = "", PointsAwarded = _TotalPointsAwarded2, PointsAssigned = _TotalPointsAssigned2, IsMatch = true, ShowMatch = true });

            dgOtherUserCriteriaTable.DataSource = _OtherUserCriteriaMatchNew;
            dgOtherUserCriteriaTable.DataBind();

            lblMutualMatch.InnerText = "Mutual Match: " + ((_TotalPointsAwarded + _TotalPointsAwarded2) / 2).ToString() + "%";
        }

        protected void dgCriteriaTable_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            try
            {
                if (e.Item.Cells[0].Text.ToLower().IndexOf("salary") != -1 || e.Item.Cells[0].Text.ToLower().IndexOf("income") != -1)
                {
                    try
                    {
                        string _MyPreference = e.Item.Cells[1].Text;
                        string _salary = e.Item.Cells[2].Text;
                        var _getRange = _MyPreference.Split(' ');
                        int _MinSal = Convert.ToInt32(_getRange[0]);
                        int _MaxSal = Convert.ToInt32(_getRange[2]);
                        int _ThirSal = Convert.ToInt32(_salary);
                        if (_MinSal <= _ThirSal && _MaxSal >= _ThirSal)
                        {
                            e.Item.Cells[2].Text = "Inside your range";
                        }
                        else
                        {
                            e.Item.Cells[2].ForeColor = System.Drawing.Color.Red;
                            e.Item.Cells[2].Text = "Outside your range";
                        }
                    }catch(Exception){
                        e.Item.Cells[2].Text = "No Answer";
                    }
                    
                }

                if (e.Item.Cells[0].Text.ToLower().IndexOf("zip code") != -1)
                {
                    try
                    {
                        if (e.Item.Cells[1].Text != "" && e.Item.Cells[2].Text != "")
                        {
                            string _MyPreference = e.Item.Cells[1].Text;
                            string _Distance = e.Item.Cells[2].Text.Split(' ')[0];
                            var _getRange = _MyPreference.Split(' ');

                            int _MaxDistance = Convert.ToInt32(_getRange[3]);
                            double _ThirDistance = Convert.ToDouble(_Distance);
                            if (_MaxDistance >= _ThirDistance)
                            {
                                e.Item.Cells[2].ForeColor = System.Drawing.Color.Black;
                            }
                            else
                            {
                                e.Item.Cells[2].ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        
                    }
                    catch (Exception)
                    {
                        e.Item.Cells[2].Text = "No Answer";
                    }
                    e.Item.Cells[0].Text = "Distance";

                }


                if (e.Item.Cells[0].Text.Trim() != "&nbsp;")
                {
                    if (e.Item.Cells[1].Text.Trim() == "&nbsp;" || e.Item.Cells[1].Text.Trim() == "")
                    {
                        e.Item.Cells[1].Text = "No Answer";
                        e.Item.Cells[1].ForeColor = System.Drawing.Color.Red;
                    }
                    if (e.Item.Cells[2].Text.Trim() == "&nbsp;" || e.Item.Cells[2].Text.Trim() == "")
                    {
                        e.Item.Cells[2].Text = "No Answer";
                        e.Item.Cells[2].ForeColor = System.Drawing.Color.Red;
                    }
                }
                if (e.Item.Cells[2].Text == "No Answer")
                {
                    e.Item.Cells[2].ForeColor = System.Drawing.Color.Red;
                }
                if (e.Item.Cells[1].Text == "No Answer")
                {
                    e.Item.Cells[1].ForeColor = System.Drawing.Color.Red;
                }

                if (Convert.ToBoolean(e.Item.Cells[5].Text) == false)
                {
                    e.Item.Cells[2].ForeColor = System.Drawing.Color.Red;
                }

                if (Convert.ToBoolean(e.Item.Cells[11].Text) == true)
                {
                    if (Convert.ToBoolean(e.Item.Cells[5].Text) == true)
                    {
                        e.Item.Cells[2].Text = e.Item.Cells[12].Text;
                    }
                    else
                    {
                        e.Item.Cells[2].Text = e.Item.Cells[13].Text;
                    }

                }


                string[] _OptionsArray = e.Item.Cells[1].Text.Split(',');
                StringBuilder _HtmlOption = new StringBuilder();
                foreach (string _Option in _OptionsArray)
                {
                    _HtmlOption.Append("<div>" + _Option + "</div>");
                }

                e.Item.Cells[1].Text = _HtmlOption.ToString();


            }
            catch (Exception)
            {

            }
        }

        protected void dgOtherUserCriteriaTable_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            try
            {
                e.Item.Cells[3].Text = "";
                if (e.Item.Cells[4].Text.ToLower().IndexOf("earned") != -1)
                {

                }
                else
                {
                    int _itemCount = _OtherUserCriteriaMatchNew.Count();

                    if (e.Item.ItemIndex == _OtherUserCriteriaMatchNew.Count() - 1)
                    {

                    }else
                    {
                        e.Item.Cells[4].Text = "";
                    }
                }
               
                if (e.Item.Cells[0].Text.ToLower().IndexOf("race/ethnicity") != -1)
                {
                   
                }
                if (e.Item.Cells[0].Text.ToLower().IndexOf("hair color") != -1)
                {
                    e.Item.Cells[1].Visible = false;
                }
                if (e.Item.Cells[0].Text.ToLower().IndexOf("eye color") != -1)
                {
                    e.Item.Cells[1].Visible = false;
                }
                if (e.Item.Cells[0].Text.ToLower().IndexOf("salary") != -1 || e.Item.Cells[0].Text.ToLower().IndexOf("income") != -1)
                {
                    try
                    {
                        e.Item.Cells[1].Visible = false;
                       
                    }
                    catch (Exception)
                    {
                        e.Item.Cells[2].Text = "";
                    }

                }


                if (e.Item.Cells[1].Text.ToLower().Contains("their preference") || e.Item.Cells[2].Text.ToLower().Contains("your answer"))
                {

                }
                else
                {
                    if (e.Item.Cells[0].Text.Trim() != "&nbsp;")
                    {
                        string _myAnswer = e.Item.Cells[2].Text.ToLower();
                        if (e.Item.Cells[1].Text.ToLower() != _myAnswer)
                        {
                            e.Item.Cells[2].ForeColor = System.Drawing.Color.Red;
                            if (e.Item.Cells[1].Text.Trim() == "&nbsp;" || e.Item.Cells[1].Text.Trim() == "")
                            {
                                e.Item.Cells[1].Text = "No Answer";
                                e.Item.Cells[1].ForeColor = System.Drawing.Color.Red;
                                e.Item.Cells[2].ForeColor = System.Drawing.Color.Black;
                            }
                            if (e.Item.Cells[2].Text.Trim() == "&nbsp;" || e.Item.Cells[2].Text.Trim() == "")
                            {
                                e.Item.Cells[2].Text = "No Answer";
                                e.Item.Cells[2].ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else
                        {
                            e.Item.Cells[2].ForeColor = System.Drawing.Color.Black;
                            if (e.Item.Cells[1].Text.Trim() == "&nbsp;" || e.Item.Cells[1].Text.Trim() == "")
                            {
                                e.Item.Cells[1].Text = "No Answer";
                                e.Item.Cells[1].ForeColor = System.Drawing.Color.Red;
                            }
                            if (e.Item.Cells[2].Text.Trim() == "&nbsp;" || e.Item.Cells[2].Text.Trim() == "")
                            {
                                e.Item.Cells[2].Text = "No Answer";
                                e.Item.Cells[2].ForeColor = System.Drawing.Color.Red;
                            }
                        }

                        if (e.Item.Cells[1].Text.ToLower().IndexOf(_myAnswer) != -1 || e.Item.Cells[1].Text.ToLower().IndexOf("any of the above") != -1)
                        {
                            e.Item.Cells[2].ForeColor = System.Drawing.Color.Black;
                        }

                        if (e.Item.Cells[2].Text == "No Answer")
                        {
                            e.Item.Cells[2].ForeColor = System.Drawing.Color.Red;
                        }
                        if (e.Item.Cells[1].Text == "No Answer")
                        {
                            e.Item.Cells[1].ForeColor = System.Drawing.Color.Red;
                        }

                    }
                }


                if (e.Item.Cells[0].Text.ToLower().IndexOf("zip code") != -1)
                {
                    try
                    {
                        if (e.Item.Cells[1].Text != "" && e.Item.Cells[2].Text != "")
                        {
                            string _MyPreference = e.Item.Cells[1].Text;
                            string _Distance = e.Item.Cells[2].Text.Split(' ')[0];
                            var _getRange = _MyPreference.Split(' ');

                            int _MaxDistance = Convert.ToInt32(_getRange[3]);
                            double _ThirDistance = Convert.ToDouble(_Distance);
                            if (_MaxDistance >= _ThirDistance)
                            {
                                e.Item.Cells[2].ForeColor = System.Drawing.Color.Black;
                            }
                            else
                            {
                                e.Item.Cells[2].ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        e.Item.Cells[0].Text = "Distance";
                       
                    }
                    catch (Exception)
                    {
                        e.Item.Cells[2].Text = "No Answer";
                    }

                }



                if (Convert.ToBoolean(e.Item.Cells[5].Text) == false)
                {
                   // e.Item.Cells[2].ForeColor = System.Drawing.Color.Red;

                }

                if (Convert.ToBoolean(e.Item.Cells[10].Text) == true)
                {
                    e.Item.Visible = false;
                }

                //if (e.Item.Cells[10].Text != "&nbsp;")
                //{
                //    e.Item.Cells[3].Text = "";
                //}


                string[] _OtherOptions = e.Item.Cells[1].Text.Split(',');
                StringBuilder _OtherOptionHtml = new StringBuilder();
                foreach (string _SingleOption in _OtherOptions)
                {
                    _OtherOptionHtml.Append("<div>"+_SingleOption+"</div>");
                }
                e.Item.Cells[1].Text = _OtherOptionHtml.ToString();

            }
            catch (Exception)
            {

            }
        }
    }
}