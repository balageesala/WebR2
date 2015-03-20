using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelliWebR1
{
    public class UploadResponse
    {
        public int ResponseCode { get; set; }
        public string UploadPath { get; set; }
        public string ErrorMessage { get; set; }
    }
}