using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API.Messages
{
    public class PostFilterSettingsController : ApiController
    {
        public bool Post([FromBody]PostFilterClass PostFilter)
        {
            int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            int MinChars = 0;
            int MaxChars = 0;
            if(PostFilter.IsCharectors)
            {
              MinChars = PostFilter.MinChars;
              MaxChars = PostFilter.MaxChars;
            }
            else
            {
               MinChars = 0;
               MaxChars = 0;
            }

            return new MessageFilters().SetMessageFilter(_UserID, MinChars, MaxChars, false, PostFilter.IsProfinity, PostFilter.IsCharectors);
        }
    }


    public class PostFilterClass
    {
        public bool IsCharectors { get; set; }
        public int MinChars { get; set; }
        public int MaxChars { get; set; }
        public bool IsProfinity  { get; set; }

    }

}
