using IntellidateR1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace IntelliWebR1.API
{
    public class ReadImageController : ApiController
    {
        public string Post([FromBody]ImageOne _ImgObj)
        {
            try
            {
                string _ImagePath = string.Empty;
                //get original path 
                if (_ImgObj.PType == 1)
                {
                    _ImagePath = new Utils().GetPhotoFullViewPath(_ImgObj.PhotoID);
                }
                else if (_ImgObj.PType == 2)
                {
                    _ImagePath = new Utils().GetPhotoPCGTPath(_ImgObj.PhotoID);
                }
                else
                {
                    _ImagePath = new Utils().GetSmallPPCTPath(_ImgObj.PhotoID);
                }
                return _ImagePath;
            }
            catch (Exception)
            {
                return "";
            }

        }
    }

    public class ImageOne
    {
        public int PhotoID { get; set; }

        // 1 = Original full path
        // 2 = PCGT Thumbanail path for full photo
        // 3 = PCT Only Craped path for (profile pic)
        public int PType { get; set; }

    }

}
