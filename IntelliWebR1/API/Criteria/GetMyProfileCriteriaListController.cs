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
    public class GetMyProfileCriteriaListController : ApiController
    {

        // GET api/<controller>
        public IEnumerable<MyProfileCriteria> Get()
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                MyProfileCriteria[] _GetList = new MyProfileCriteria().GetCritertaList(UserID);
                return _GetList;
            }
            catch (Exception ex)
            {
                Error.LogError(ex, "IEnumerable<Criteria> Get()");
                return null;
            }
            
        }
    }

  

}
