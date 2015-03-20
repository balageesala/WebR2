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
    public class SetRankOrderController : ApiController
    {

        public bool POST([FromBody]RankOrder _ObjRank)
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                new QARankOrder().SetQuestionAnswerRankOrder(_ObjRank.Answer_id, _ObjRank._RankOrder, _UserID);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


    }


    public class RankOrder
    {
        public string Answer_id { get; set; }
        public int _RankOrder { get; set; }
    }



}
