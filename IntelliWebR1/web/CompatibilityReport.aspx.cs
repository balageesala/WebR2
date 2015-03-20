using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Configuration;

namespace IntellidateR1Web.web
{
    public partial class CompatibilityReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                   if(Request.QueryString["OtherUserID"]!=null)
                   {
                        int OtherUserID = Convert.ToInt32(Request.QueryString["OtherUserID"]);
                        int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                               FillCriteriaMatch(UserID, OtherUserID);
                   }
                }
                catch (Exception ex)
                {
                    IntellidateR1.Error.LogError(ex, "CompatibilityReport");
                    if (Request.QueryString["OtherUserID"] != null)
                    {
                        int OtherUserID = Convert.ToInt32(Request.QueryString["OtherUserID"]);
                        int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                        new CRDownloadInfo().AddCRDownloadInfo(UserID, OtherUserID, "", false);
                    }
                }
            }
        }



        private void FillCriteriaMatch(int _UserID, int OtherUserID)
        {
           
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



                if (_EachMatch.CriteriaName.ToLower().IndexOf("salary") != -1 || _EachMatch.CriteriaName.ToLower().IndexOf("income") != -1)
                {
                    try
                    {
                        string _MyPreference = _EachMatch.UserPreferences;
                        string _salary = _EachMatch.OtherUserValue;
                        var _getRange = _MyPreference.Split(' ');
                        int _MinSal = Convert.ToInt32(_getRange[0]);
                        int _MaxSal = Convert.ToInt32(_getRange[2]);
                        int _ThirSal = Convert.ToInt32(_salary);
                        if (_MinSal <= _ThirSal && _MaxSal >= _ThirSal)
                        {
                            _EachMatch.OtherUserValue = "Inside your range";
                        }
                        else
                        {
                            _EachMatch.OtherUserValue = "Outside your range";
                        }
                    }
                    catch (Exception)
                    {
                        _EachMatch.OtherUserValue = "No Answer";
                    }
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




            List<CriteriaMatch> _OtherUserCriteriaMatch = new List<CriteriaMatch>();
            _OtherUserCriteriaMatch = new CriteriaMatch().GetCriteriaMatch(Convert.ToInt32(OtherUserID), _UserID).ToList();
            _OtherUserCriteriaMatch = _OtherUserCriteriaMatch.OrderByDescending(x => x.PointsAssignedByOtherUser).ToList();

            List<CriteriaMatch> _OtherUserCriteriaMatchNew = new List<CriteriaMatch>();

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

           
    
             string _RandomName = _UserID.ToString() + DateTime.Now.ToString("ddMMMyyyyhhmmss");
             string _ReportPath = System.Configuration.ConfigurationManager.AppSettings["ReportsRootPath"].ToString();
             string _FilePath = _ReportPath + _RandomName + "_CompatibilityReport.pdf";
          

             User _ThisUser = new User().GetUserDetails(_UserID);
             User _OtherUser = new User().GetUserDetails(OtherUserID);
             string _OtherUserPic = string.Empty;
             string _ThisUserPic = string.Empty;
             string _CriTheyMatchYou = string.Empty;
             string _CriteriaOverallMatch = string.Empty;
             string _CriYouMatchThem =  string.Empty;

             string _QtnTheyMatchYou = string.Empty;
             string _QuestionsOverallMatch = string.Empty;
             string _QtnYouMatchThem = string.Empty;


             string PhotoRootPath = System.Configuration.ConfigurationManager.AppSettings["PhotosRootPath"].ToString();
             string SitePath = System.Configuration.ConfigurationManager.AppSettings["SitePath"].ToString();

           
                 if (_OtherUser.ProfilePhoto != null)
                 {
                     _OtherUserPic = new Utils().GetSmallPPCTPath(_OtherUser.ProfilePhoto.PhotoID);
                 }
                 else
                 {
                     if (_OtherUser.Gender == 1)
                     {
                         _OtherUserPic = SitePath + "web/images/M.png";
                     }
                     else
                     {
                         _OtherUserPic = SitePath + "web/images/F.png";
                     }
                 }
             

             
                 if (_ThisUser.ProfilePhoto != null)
                 {
                     _ThisUserPic = new Utils().GetSmallPPCTPath(_ThisUser.ProfilePhoto.PhotoID);
                 }
                 else
                 {
                     if (_ThisUser.Gender == 1)
                     {
                         _ThisUserPic = SitePath + "web/images/M.png";
                     }
                     else
                     {
                         _ThisUserPic = SitePath + "web/images/F.png";
                     }
                 }
             

            //create pie chaarts using pdf class
             decimal _CriteriaTMatch = new CriteriaMatchPercentage().GetMatchPercentage(_UserID, OtherUserID);    
             decimal _CriteriaTheyMatchYou = new CriteriaMatch()._GetCriteriaSinglePercentage(OtherUserID, _UserID);
             decimal _CriteriaYouMatchThem = new CriteriaMatch()._GetCriteriaSinglePercentage(_UserID, OtherUserID);

             string _CriteriaTMatchImg = SitePath + "web/service/OverallMatchImage?p=" + _CriteriaTMatch.ToString();
             string _CriteriaTheyMatchYouImg = SitePath + "web/service/OverallMatchImage?p=" + _CriteriaTheyMatchYou.ToString();
             string _CriteriaYouMatchThemImg = SitePath + "web/service/OverallMatchImage?p=" + _CriteriaYouMatchThem.ToString();


             decimal _PhilosophyTheyMatchYou = new QuestionsMatch()._GetQuestionsSinglePercentage(OtherUserID, _UserID);
             decimal _PhilosophyYouMatchThem = new QuestionsMatch()._GetQuestionsSinglePercentage(_UserID, OtherUserID);
             decimal _PhilosophyMatch = (decimal)(((decimal) (_PhilosophyTheyMatchYou) + (decimal)(_PhilosophyYouMatchThem))/2);

           
             string _QtnMatchImg = SitePath + "web/service/OverallMatchImage?p=" + _PhilosophyMatch.ToString();
             string _QtnTheyMatchYouImg = SitePath + "web/service/OverallMatchImage?p=" + _PhilosophyTheyMatchYou.ToString();
             string _QtnYouMatchThemImg = SitePath + "web/service/OverallMatchImage?p=" + _PhilosophyYouMatchThem.ToString();


           

             Document mydocument = new Document(PageSize.A4, 10f, 10f, 50f, 0f);
             PdfWriter.GetInstance(mydocument, new FileStream(_FilePath, FileMode.Create));
             mydocument.Open();
             try
             {

                 Paragraph heading = new Paragraph("Criteria", new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA,20f, iTextSharp.text.Font.BOLD));
                 heading.SpacingAfter = 18f;
                 heading.Alignment = 1;
                 mydocument.Add(heading);
                 //PdfWriter _writer ;
                 //iTextSharp.text.pdf.PdfContentByte _Cb = _writer.DirectContent;

                 PdfPTable _PdfTable = new PdfPTable(5);
                 
                 

                 float[] widths = new float[] { 1f, 1f, 1f , 1f, 1f};
                 _PdfTable.TotalWidth = 500f;
                 _PdfTable.LockedWidth = true;
                 _PdfTable.SetWidths(widths);
                 _PdfTable.DefaultCell.Border = 0;
                 _PdfTable.DefaultCell.HorizontalAlignment = 1;
                 iTextSharp.text.Font fontTitle = FontFactory.GetFont("Arial", 10);
                 iTextSharp.text.Font fontRed = FontFactory.GetFont("Arial", 10, iTextSharp.text.Color.RED);
                 iTextSharp.text.Font fontTitleBold = FontFactory.GetFont("Arial", 10,iTextSharp.text.Font.BOLD);

                 _PdfTable.DefaultCell.Phrase = new Phrase() { Font = fontTitle };
                 iTextSharp.text.Image _OtherUserPimg = iTextSharp.text.Image.GetInstance(_OtherUserPic);
                 _OtherUserPimg.ScaleToFit(100f, 100f);
                  PdfPCell _PdfOtherPicCell = new PdfPCell(_OtherUserPimg);
                  _PdfOtherPicCell.Border = 0;
                 _PdfTable.AddCell(_PdfOtherPicCell);

                

                 iTextSharp.text.Image _CriTheyMatchI = iTextSharp.text.Image.GetInstance(_CriteriaTheyMatchYouImg);
                 _CriTheyMatchI.ScaleToFit(100f, 100f);
                 PdfPCell _PdfCriTheyMatchICell = new PdfPCell(_CriTheyMatchI);
                 _PdfCriTheyMatchICell.Border = 0;
                 _PdfTable.AddCell(_PdfCriTheyMatchICell);

                 iTextSharp.text.Image _CriOvI = iTextSharp.text.Image.GetInstance(_CriteriaTMatchImg);
                 _CriOvI.ScaleToFit(100f, 100f);
                 PdfPCell _PdfCriOvICell = new PdfPCell(_CriOvI);
                 _PdfCriOvICell.Border = 0;
                 _PdfTable.AddCell(_PdfCriOvICell);


                 iTextSharp.text.Image _CriYouMatchI = iTextSharp.text.Image.GetInstance(_CriteriaYouMatchThemImg);
                 _CriYouMatchI.ScaleToFit(100f, 100f);
                 PdfPCell _PdfCriYouMatchICell = new PdfPCell(_CriYouMatchI);
                 _PdfCriYouMatchICell.Border = 0;
                 _PdfTable.AddCell(_PdfCriYouMatchICell);

                 iTextSharp.text.Image _ThisUserI = iTextSharp.text.Image.GetInstance(_ThisUserPic);
                 _ThisUserI.ScaleToFit(100f, 100f);
                 PdfPCell _PdfThisUserICell = new PdfPCell(_ThisUserI);
                 _PdfThisUserICell.Border = 0;
                 _PdfTable.AddCell(_PdfThisUserICell);

                 _PdfTable.AddCell(_OtherUser.LoginName);
                 _PdfTable.AddCell("They match you");
                 _PdfTable.AddCell("Criteria match");
                 _PdfTable.AddCell("You match them");
                 _PdfTable.AddCell(_ThisUser.LoginName);

                 mydocument.Add(_PdfTable);
                 mydocument.Add(new Paragraph(" "));
                 mydocument.Add(new Paragraph(" "));
                 PdfPTable _PdfCriTable1 = new PdfPTable(5);
                 float[] _CriWidths = new float[] { 1f, 2.6f, 1.4f, 0.6f, 0.5f };
                 _PdfCriTable1.TotalWidth = 580f;
                 _PdfCriTable1.LockedWidth = true;
                 _PdfCriTable1.SetWidths(_CriWidths);
                 _PdfCriTable1.DefaultCell.Border = 1;
                 _PdfCriTable1.DefaultCell.HorizontalAlignment = 0;
                 _PdfCriTable1.DefaultCell.Phrase = new Phrase() { Font = fontTitle };

                 _PdfCriTable1.AddCell(new PdfPCell(new Phrase("Category", fontTitleBold)));
                 _PdfCriTable1.AddCell(new PdfPCell(new Phrase("My Preference", fontTitleBold)));
                 _PdfCriTable1.AddCell(new PdfPCell(new Phrase("Their Answer", fontTitleBold)));
                 _PdfCriTable1.AddCell(new PdfPCell(new Phrase("Assigned", fontTitleBold)));
                 _PdfCriTable1.AddCell(new PdfPCell(new Phrase("Earned", fontTitleBold)));


                 foreach (var item in _CriteriaMatch)
                 {
                     // _PdfCriTable1.DefaultCell.Phrase = new Phrase() { Font = fontTitle };
                     _PdfCriTable1.AddCell(new PdfPCell(new Phrase(item.CriteriaName, fontTitle)));

                     if (item.UserPreferences.Trim().ToLower() == "no answer")
                     {
                         _PdfCriTable1.AddCell(new PdfPCell(new Phrase(item.UserPreferences, fontRed)));
                     }
                     else
                     {
                         _PdfCriTable1.AddCell(new PdfPCell(new Phrase(item.UserPreferences, fontTitle)));
                     }
                     if (item.IsMatch)
                     {
                         _PdfCriTable1.AddCell(new PdfPCell(new Phrase(item.OtherUserValue, fontTitle)));
                         if (item.OtherUserValue.Trim().ToLower() == "no answer")
                         {
                             _PdfCriTable1.AddCell(new PdfPCell(new Phrase(item.OtherUserValue, fontRed)));
                         }
                     }
                     else
                     {
                         _PdfCriTable1.AddCell(new PdfPCell(new Phrase(item.OtherUserValue, fontRed)));
                     }

                     _PdfCriTable1.AddCell(new PdfPCell(new Phrase(item.PointsAssigned.ToString(), fontTitle)));
                     _PdfCriTable1.AddCell(new PdfPCell(new Phrase(item.PointsAwarded.ToString(), fontTitle)));

                    
                 }

                 mydocument.Add(_PdfCriTable1);
                 mydocument.Add(new Paragraph(" "));
                 mydocument.Add(new Paragraph(" "));
                 PdfPTable _PdfCriTable2 = new PdfPTable(5);
                 float[] _Cri2Widths = new float[] { 1f, 2.6f, 1.4f, 0.6f, 0.5f };
                 _PdfCriTable2.TotalWidth = 580f;
                 _PdfCriTable2.LockedWidth = true;
                 _PdfCriTable2.SetWidths(_Cri2Widths);
                 _PdfCriTable2.DefaultCell.Border = 1;
                 _PdfCriTable2.DefaultCell.HorizontalAlignment = 0;

                 _PdfCriTable2.DefaultCell.Phrase = new Phrase() { Font = fontTitle };

                 _PdfCriTable2.AddCell(new PdfPCell(new Phrase("Category", fontTitleBold)));
                 _PdfCriTable2.AddCell(new PdfPCell(new Phrase("Their Preference", fontTitleBold)));
                 _PdfCriTable2.AddCell(new PdfPCell(new Phrase("My Answer", fontTitleBold)));
                 _PdfCriTable2.AddCell(new PdfPCell(new Phrase("Assigned", fontTitleBold)));
                 _PdfCriTable2.AddCell(new PdfPCell(new Phrase("Earned", fontTitleBold)));
                 
                 int _Index = 0;
                 foreach (var item in _OtherUserCriteriaMatchNew)
                 {

                     _PdfCriTable2.AddCell(new PdfPCell(new Phrase(item.CriteriaName, fontTitle)));

                     if (item.UserPreferences.Trim().ToLower() == "no answer")
                     {
                         _PdfCriTable2.AddCell(new PdfPCell(new Phrase(item.UserPreferences, fontRed)));
                     }
                     else
                     {
                         _PdfCriTable2.AddCell(new PdfPCell(new Phrase(item.UserPreferences, fontTitle)));
                     }

                    if (item.IsMatch)
                     {
                         _PdfCriTable2.AddCell(new PdfPCell(new Phrase(item.OtherUserValue, fontTitle)));
                         if (item.OtherUserValue.Trim().ToLower() == "no answer")
                         {
                             _PdfCriTable1.AddCell(new PdfPCell(new Phrase(item.OtherUserValue, fontRed)));
                         }
                     }
                     else
                     {
                         _PdfCriTable2.AddCell(new PdfPCell(new Phrase(item.OtherUserValue, fontRed)));
                     }
                     _PdfCriTable2.AddCell(new PdfPCell(new Phrase(" ", fontTitle)));
                     if (_Index == (_OtherUserCriteriaMatchNew.Count() - 1))
                     {
                         _PdfCriTable2.AddCell(new PdfPCell(new Phrase(item.PointsAwarded.ToString(), fontTitle)));
                     }
                     else
                     {
                         _PdfCriTable2.AddCell(new PdfPCell(new Phrase(" ", fontTitle)));
                     }
                     _Index =_Index +1;
                 }
                
                 mydocument.Add(_PdfCriTable2);

                 QuestionsMatch[] m_QuestionsMatch = new QuestionsMatch().GetQuestionsMatch(_UserID, OtherUserID);

                 if (m_QuestionsMatch !=null)
                 {
                     m_QuestionsMatch = m_QuestionsMatch.Where(x => x.UserValue != "" && x.OtherUserValue != "" && x.IsAnsweredPrivately == false && x.QuestionCategory == 0).ToArray();
                     QuestionAnswers<OptionsSingleSelectAnswer, OptionsMultiSelectAnswer>[] _Answers = new QuestionAnswers<OptionsSingleSelectAnswer, OptionsMultiSelectAnswer>().GetUserAnswers(_UserID);
                     List<QuestionsMatch> lstQmatch = new List<QuestionsMatch>(); ;

                     //add bouth answred questions here _UserID, int OtherUserID

                     foreach (var _Answer in _Answers)
                     {
                         QuestionsMatch _Match = new QuestionsMatch();
                         _Match = m_QuestionsMatch.Where(x => x.Question_id == _Answer.Question_id).SingleOrDefault();
                         //here QuestionType is rank order;
                         if (_Match != null)
                         {
                             if (!_Answer.AnsweredPrivately)
                             {
                                 _Match.QuestionType = _Answer.RankOrder;
                                 lstQmatch.Add(_Match);
                             }
                         }

                     }

                     var _OrderByRankOrder = lstQmatch.OrderBy(x => x.QuestionType);

                     if (_OrderByRankOrder.Count() > 0)
                     {


                         Paragraph QtnHding = new Paragraph("Questions", new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 20f, iTextSharp.text.Font.BOLD));
                         QtnHding.SpacingAfter = 18f;
                         QtnHding.Alignment = 1;
                         mydocument.Add(QtnHding);
                         //PdfWriter _writer ;
                         PdfPTable _PdfQtnTable = new PdfPTable(5);
                         _PdfQtnTable.TotalWidth = 500f;
                         _PdfQtnTable.LockedWidth = true;
                         _PdfQtnTable.SetWidths(widths);
                         _PdfQtnTable.DefaultCell.Border = 0;
                         _PdfQtnTable.DefaultCell.HorizontalAlignment = 1;

                         _PdfQtnTable.AddCell(_PdfOtherPicCell);



                         iTextSharp.text.Image _QtnTheyMatchI = iTextSharp.text.Image.GetInstance(_QtnTheyMatchYouImg);
                         _QtnTheyMatchI.ScaleToFit(100f, 100f);
                         PdfPCell _PdfQtnTheyMatchICell = new PdfPCell(_QtnTheyMatchI);
                         _PdfQtnTheyMatchICell.Border = 0;
                         _PdfQtnTable.AddCell(_PdfQtnTheyMatchICell);



                         iTextSharp.text.Image _QtnOvI = iTextSharp.text.Image.GetInstance(_QtnMatchImg);
                         _QtnOvI.ScaleToFit(100f, 100f);
                         PdfPCell _PdfQtnOvICell = new PdfPCell(_QtnOvI);
                         _PdfQtnOvICell.Border = 0;
                         _PdfQtnTable.AddCell(_PdfQtnOvICell);



                         iTextSharp.text.Image _QtnYouMatchI = iTextSharp.text.Image.GetInstance(_QtnYouMatchThemImg);
                         _QtnYouMatchI.ScaleToFit(100f, 100f);
                         PdfPCell _PdfQtnYouMatchICell = new PdfPCell(_QtnYouMatchI);
                         _PdfQtnYouMatchICell.Border = 0;
                         _PdfQtnTable.AddCell(_PdfQtnYouMatchICell);

                         _PdfQtnTable.AddCell(_PdfThisUserICell);


                         _PdfQtnTable.AddCell(_OtherUser.LoginName);
                         _PdfQtnTable.AddCell("They match you");
                         _PdfQtnTable.AddCell("Questions match");
                         _PdfQtnTable.AddCell("You match them");
                         _PdfQtnTable.AddCell(_ThisUser.LoginName);

                         mydocument.Add(_PdfQtnTable);



                         mydocument.Add(new Paragraph(" "));

                         foreach (var item in _OrderByRankOrder)
                         {
                             // add question
                             mydocument.Add(new Paragraph(item.QuestionName));
                             // add my answer
                             mydocument.Add(new Paragraph(item.OtherUser.LoginName + ": " + item.OtherUserValue));
                             // add your answer
                             mydocument.Add(new Paragraph(item.User.LoginName + ": " + item.UserValue));

                             mydocument.Add(new Paragraph(" "));
                         }
                     }
                 }
                 //add sex questions matchp

                 //get sex questions data

                 QuestionsMatch[] m_SexQuestionsMatch = new QuestionsMatch().GetQuestionsMatch(_UserID, OtherUserID);

                 if (m_SexQuestionsMatch != null )
                 {
                     m_SexQuestionsMatch = m_SexQuestionsMatch.Where(x => x.UserValue != "" && x.OtherUserValue != "" && x.IsAnsweredPrivately == false && x.QuestionCategory == 1).ToArray();


                     if (m_SexQuestionsMatch.Count() > 0)
                     {
                         mydocument.Add(new Paragraph(" "));

                         Paragraph SexQtnHding = new Paragraph("Sex Questions", new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 20f, iTextSharp.text.Font.BOLD));
                         SexQtnHding.SpacingAfter = 18f;
                         SexQtnHding.Alignment = 1;
                         mydocument.Add(SexQtnHding);

                         PdfPTable _PdfSexQtnTable = new PdfPTable(5);
                         float[] _sexWidths = new float[] { 1f, 1f, 1f, 1f, 1f };
                         _PdfSexQtnTable.TotalWidth = 500f;
                         _PdfSexQtnTable.LockedWidth = true;
                         _PdfSexQtnTable.SetWidths(_sexWidths);
                         _PdfSexQtnTable.DefaultCell.Border = 0;
                         _PdfSexQtnTable.DefaultCell.HorizontalAlignment = 1;

                         string SexQtnMatchpImg = string.Empty;

                         if (_ThisUser.Gender == 1)
                         {
                             decimal _SexPhilosophyMatch = new QuestionsMatch().GetSexQuestionsOverallMatch(_UserID, OtherUserID);
                             if (_SexPhilosophyMatch == -1)
                             {
                                 _SexPhilosophyMatch = 0;
                             }
                             SexQtnMatchpImg = SitePath + "web/service/OverallMatchImage?p=" + _SexPhilosophyMatch.ToString();

                             _PdfSexQtnTable.AddCell(_PdfOtherPicCell);
                             iTextSharp.text.Image _SexQtnYouMatchI = iTextSharp.text.Image.GetInstance(SexQtnMatchpImg);
                             _SexQtnYouMatchI.ScaleToFit(100f, 100f);
                             PdfPCell _PdfSexQtnYouMatchICell = new PdfPCell(_SexQtnYouMatchI);
                             _PdfSexQtnYouMatchICell.Border = 0;
                             _PdfSexQtnTable.AddCell(" ");
                             _PdfSexQtnTable.AddCell(_PdfSexQtnYouMatchICell);
                             _PdfSexQtnTable.AddCell(" ");
                             _PdfSexQtnTable.AddCell(_PdfThisUserICell);

                             _PdfSexQtnTable.AddCell(_OtherUser.LoginName);
                             _PdfSexQtnTable.AddCell("They match you");
                             _PdfSexQtnTable.AddCell("Questions Match");
                             _PdfSexQtnTable.AddCell("You match them");
                             _PdfSexQtnTable.AddCell(_ThisUser.LoginName);
                             mydocument.Add(_PdfSexQtnTable);

                         }
                         else
                         {
                             decimal _SexPhilosophyTheyMatchYou = new QuestionsMatch()._GetSexQuestionsSinglePercentage(OtherUserID, _UserID);
                             if (_PhilosophyTheyMatchYou == -1)
                             {
                                 _PhilosophyTheyMatchYou = 0;
                             }
                             SexQtnMatchpImg = SitePath + "web/service/OverallMatchImage?p=" + _SexPhilosophyTheyMatchYou.ToString();

                             _PdfSexQtnTable.AddCell(_PdfOtherPicCell);
                             iTextSharp.text.Image _SexQtnYouMatchI = iTextSharp.text.Image.GetInstance(SexQtnMatchpImg);
                             _SexQtnYouMatchI.ScaleToFit(100f, 100f);
                             PdfPCell _PdfSexQtnYouMatchICell = new PdfPCell(_SexQtnYouMatchI);
                             _PdfSexQtnYouMatchICell.Border = 0;
                             _PdfSexQtnTable.AddCell(_PdfSexQtnYouMatchICell);
                             _PdfSexQtnTable.AddCell(" ");
                             _PdfSexQtnTable.AddCell(" ");
                             _PdfSexQtnTable.AddCell(_PdfThisUserICell);

                             _PdfSexQtnTable.AddCell(_OtherUser.LoginName);
                             _PdfSexQtnTable.AddCell("They match you");
                             _PdfSexQtnTable.AddCell("Questions match");
                             _PdfSexQtnTable.AddCell("You match them");
                             _PdfSexQtnTable.AddCell(_ThisUser.LoginName);
                             mydocument.Add(_PdfSexQtnTable);

                         }
                     }

                     mydocument.Add(new Paragraph(" "));
                     foreach (var item in m_SexQuestionsMatch)
                     {
                         mydocument.Add(new Paragraph(item.QuestionName));
                     }


                 }

                 mydocument.Add(new Paragraph(" "));
                 mydocument.Close();

                 string _rootUrl = ConfigurationManager.AppSettings["PhotosRootUrl"].ToString();

                 _FilePath = _FilePath.Replace(ConfigurationManager.AppSettings["PhotosRootPath"].ToString(), ConfigurationManager.AppSettings["PhotosRootUrl"].ToString());
                 _FilePath = _FilePath.Replace("\\", "/");


                 pdfReport.Src = _FilePath;
                 new CRDownloadInfo().AddCRDownloadInfo(_UserID, OtherUserID, _FilePath, true);
                 
             }
             catch (Exception er)
             {
                 IntellidateR1.Error.LogError(er, "CompatibilityReport");
                 new CRDownloadInfo().AddCRDownloadInfo(_UserID, OtherUserID, "", false);
             }

       
        }

     
     

    }


  


}