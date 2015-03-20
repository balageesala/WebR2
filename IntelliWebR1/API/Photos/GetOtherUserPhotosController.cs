using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntellidateR1;
using System.Configuration;
using System.Web;

namespace IntelliWebR1.API
{
    public class GetOtherUserPhotosController : ApiController
    {
        // POST api/<controller>
        public IEnumerable<Photo> Post([FromBody]GetOtherUserPhotos value)
        {

            Photo[] _UserPhotos = new Photo().GetUserPhotos(value.LoginName);

            foreach (var item in _UserPhotos)
            {
                item.PhotoPath = new Utils().GetPhotoPCGTPath(item.PhotoID, HttpContext.Current.Request);
                item.EncryptPath = new Utils().GetPhotoFullViewPath(item.PhotoID, HttpContext.Current.Request);
            }

            return _UserPhotos;
        }
    }
    public class GetOtherUserPhotos
    {
        public string LoginName { get; set; }
    }
}