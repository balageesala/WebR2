using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API.Other
{
    public class ReportUserProfileController : ApiController
    {
        public bool Post([FromBody]reportProfile report)
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                return new ReportUser().ReportAUser(UserID, report.ReportedUserID, report.ReportType, report.Comment);
            }
            catch (Exception)
            {

                return false;
            }
        }


    }


    public class reportProfile
    {
        public int ReportedUserID { get; set; }
        public int ReportType { get; set; }
        public string  Comment { get; set; }

    }


}
