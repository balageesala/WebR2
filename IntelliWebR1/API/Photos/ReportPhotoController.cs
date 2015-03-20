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
    public class ReportPhotoController : ApiController
    {
        // POST api/<controller>
        public bool Post([FromBody]ReportPhotoCls PhotoReportObj)
        {
            int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            bool Res = new PhotoReport().ReportPhotoAbuse(_UserID, PhotoReportObj.PhotoUserID, PhotoReportObj.PhotoID, PhotoReportObj.ReportType, PhotoReportObj.Comment);
            return Res;                 
        }

    }

    public class ReportPhotoCls
    {
        public int PhotoID { get; set; }
        public int PhotoUserID { get; set; }
        public int ReportType { get; set; }
        public string Comment { get; set; }
    }


}
