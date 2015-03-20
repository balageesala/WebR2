using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using IntellidateR1;
using System.Device.Location;

namespace IntelliWebR1.API
{
    public class GrabController : ApiController
    {

        public void Post([FromBody]UserAnalytics _Analytics)
        {
            try
            {
                int _UserID = 0;
                string _IpAddress = HttpContext.Current.Request.UserHostAddress;
               if (HttpContext.Current.User.Identity.Name == "")
                {
                    _UserID = 0;
                }
                else
                {
                    _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                }

              
               GeoCoordinate _Coordinates = new GeoCoordinate(_Analytics.Latitude, _Analytics.Longitude);

               new Analytics().SubmitAnalytics(_IpAddress, _Analytics.UserAgent, _Coordinates, _Analytics.LoadTime, _Analytics.SpentTime, _Analytics.PageName, _UserID, _Analytics.Referer, _Analytics.ScreenWidth, _Analytics.ScreenHeight);
            }
            catch (Exception)
            {
                return;
            }
        }
    }

    public class UserAnalytics
    {
        public string UserAgent { get; set; }
        public TimeSpan LoadTime { get; set; }
        public TimeSpan SpentTime { get; set; }
        public string PageName { get; set; }
        public string Referer { get; set; }
        public int  ScreenWidth  { get; set; }
        public int ScreenHeight { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }


}
