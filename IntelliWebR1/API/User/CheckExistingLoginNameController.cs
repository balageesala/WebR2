using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using IntellidateR1;

namespace IntelliWebR1.API
{
    public class CheckExistingLoginNameController : ApiController
    {
        
        // POST api/<controller>
        public bool Post([FromBody]CheckExistingLoginName m_CheckExistingLoginName)
        {
            try
            {
                if (HttpContext.Current.User.Identity.Name != "")
                {
                    int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                    return new IntellidateR1.User().CheckExistingLoginName(_UserID, m_CheckExistingLoginName.LoginName);
                }
                else
                {
                    return new IntellidateR1.User().CheckExistingLoginName(m_CheckExistingLoginName.LoginName);
                }

            }
            catch (Exception)
            {
                return true;
            }
        }

    }

    public class CheckExistingLoginName
    {
        public string LoginName { get; set; }
    }
}