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
    public class ResetMatchPercentagesController : ApiController
    {
        public bool Post([FromBody]RecetMatchpUser ResetUser)
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                new QuestionsMatchPercentage().ResetMatchPercentage(UserID, ResetUser.OtherUserID);
                new CriteriaMatchPercentage().ResetMatchPercentage(UserID, ResetUser.OtherUserID);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }

    public class RecetMatchpUser
    {
        public int OtherUserID { get; set; }

    }



}
