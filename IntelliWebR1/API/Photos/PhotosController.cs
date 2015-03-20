using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntellidateR1;
using System.Web;
using System.Configuration;

namespace IntelliWebR1.API
{
    /*public class PhotosController : ApiController
    {

        public IEnumerable<Photo> Get()
        {
            try
            {
                int OtherUserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                Photo[] _UserPhotos = new Photo().GetUserPhotos(OtherUserID, ConfigurationManager.AppSettings["PhotosFolder"].ToString(), 200, 400);
                return _UserPhotos;
            }
            catch (Exception)
            {
                return null;
            }
        }
        // GET api/<controller>/5
        public IEnumerable<Photo> Get(string value)
        {
            try
            {
                int OtherUserID = Convert.ToInt32(new EncryptDecrypt().Decrypt(value));

                Photo[] _UserPhotos = new Photo().GetUserPhotos(OtherUserID, ConfigurationManager.AppSettings["PhotosFolder"].ToString(), 200, 400);
                return _UserPhotos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // POST api/<controller>
        public Photo[] Post([FromBody]PhotosCommand PhotosCommand)
        {
            try
            {
                if (PhotosCommand.Action == "G")
                {
                    int _UserID = Convert.ToInt32(new EncryptDecrypt().Decrypt(PhotosCommand.UserIDEncrypted));

                    Photo[] _UserPhotos = new Photo().GetUserPhotos(_UserID, ConfigurationManager.AppSettings["PhotosFolder"].ToString(), 230, 550);
                    return _UserPhotos;
                }
                if (PhotosCommand.Action == "D")
                {
                    int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                    Photo[] _UserPhotos = new Photo().GetUserPhotos(_UserID, ConfigurationManager.AppSettings["PhotosFolder"].ToString(), 230, 550);
                    return _UserPhotos;
                }
                if (PhotosCommand.Action == "GL")
                {
                    int _UserID = Convert.ToInt32(new EncryptDecrypt().Decrypt(PhotosCommand.UserIDEncrypted));

                    Photo[] _UserPhotos = new Photo().GetUserPhotos(_UserID, ConfigurationManager.AppSettings["PhotosFolder"].ToString(), 590, 550);
                    return _UserPhotos;
                }
                return null;

            }
            catch (Exception)
            {
                return null;
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
    public class PhotosCommand
    {
        public string UserIDEncrypted { get; set; }
        public int PhotoID { get; set; }
        public string Action { get; set; }
    }*/
}
