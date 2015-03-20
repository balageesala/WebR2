using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace IntelliWebR1.API
{
    public class EncryptController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public string Post([FromBody]PhotoEncrypt PhotoEncrypt)
        {
            try
            {
                Photo _PhotoDetails = new Photo().GetPhotoDetails(PhotoEncrypt.PhotoID);
                string _Return = new EncryptDecrypt().Encrypt(ConfigurationManager.AppSettings["PhotosFolder"].ToString() + _PhotoDetails.PhotoPath + "&" + PhotoEncrypt.Width.ToString() + "&" + PhotoEncrypt.Height.ToString());
                return _Return;
            }
            catch (Exception)
            {
                return "";
            }

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }

    public class PhotoEncrypt
    {
        public int PhotoID { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
