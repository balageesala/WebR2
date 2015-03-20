using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API.Profile
{
    public class MemoController : ApiController
    {
        public bool Post([FromBody]MemoUserCls _MemoObj)
        {
            int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            bool m_Res = new UserMemo().SaveMemo(_UserID, _MemoObj.OtherUserId, _MemoObj.MemoText);
            return m_Res;
        }
    }
    public class MemoUserCls
    {
        public int OtherUserId { get; set; }
        public string MemoText { get; set; }

    }

}
