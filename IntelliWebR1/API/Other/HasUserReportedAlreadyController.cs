using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API
{
    public class HasUserReportedAlreadyController : ApiController
    {

        public bool Post([FromBody]ReportedUserCls report)
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                return new ReportUser().HasUserReportedAlready(UserID, report.OtherUserID);
            }
            catch (Exception)
            {

                return false;
            }
        }
    }


    public class ReportedUserCls
    {
        public int OtherUserID { get; set; }

    }


}
