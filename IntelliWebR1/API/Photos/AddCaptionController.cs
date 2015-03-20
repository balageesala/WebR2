using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntelliWebR1.API
{
    public class AddCaptionController : ApiController
    {
        public bool Post([FromBody]PhotoCaption PhotoObject)
        {
            return new Photo().AddPhotoCaption(PhotoObject.PhotoID, PhotoObject.Caption);
        }
    }

    public class PhotoCaption
    {
        public int PhotoID { get; set; }
        public string Caption { get; set; }

    }

}
