using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using IntellidateR1;
using System.Configuration;
using System.IO;

namespace IntelliWebR1.API
{
    public class SetDefaultPhotoController : ApiController
    {
        // POST api/<controller>
        public void Post([FromBody]DefaultPhoto m_DefaultPhoto)
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                string _RootFolder = ConfigurationManager.AppSettings["PhotosFolder"].ToString();

                Photo m_PhotoDetails = new Photo().GetPhotoDetails(m_DefaultPhoto.PhotoID);
                string _PhotoPath = _RootFolder + m_PhotoDetails.PhotoPath;
                if (m_PhotoDetails.UserID != _UserID)
                {
                    return;
                }

                string _CurrentDefaultPhoto = "";
                IntellidateR1.User m_UserDetails = new IntellidateR1.User().GetUserDetails(_UserID);
                if (m_UserDetails.ProfilePhoto != null)
                {
                    _CurrentDefaultPhoto = _RootFolder + m_UserDetails.ProfilePhoto.PhotoPath;
                    _CurrentDefaultPhoto = MakeCroppedFileName(_CurrentDefaultPhoto);
                    if (File.Exists(_CurrentDefaultPhoto))
                    {
                        try
                        {
                            File.Delete(_CurrentDefaultPhoto);
                        }
                        catch (Exception)
                        {

                        }

                    }
                }

                CropPhoto(_PhotoPath, (int)Convert.ToDecimal(m_DefaultPhoto.X1), (int)Convert.ToDecimal(m_DefaultPhoto.Y1), (int)Convert.ToDecimal(m_DefaultPhoto.X2), (int)Convert.ToDecimal(m_DefaultPhoto.Y2));
                new Photo().UpdateDefaultPhoto(_UserID, m_DefaultPhoto.PhotoID);
            }
            catch (Exception)
            {
                return;
            }
        }


        private string MakeCroppedFileName(string FileName)
        {
            string _Temp = FileName.Split('\\')[FileName.Split('\\').Length - 1];
            FileName = FileName.Replace(_Temp, "cropped_" + _Temp);
            return FileName;
        }

        public void CropPhoto(string FilePath, int x, int y, int w, int h)
        {
            Bitmap _InPhoto = new Bitmap(FilePath);
            Bitmap _CroppedPhoto = new Bitmap(w, h);
            Graphics _Graphics = Graphics.FromImage(_CroppedPhoto);
            Rectangle _CropArea = new Rectangle(x, y, w, h);

            try
            {


                _Graphics.DrawImage(_InPhoto, new Rectangle(0, 0, w, h), _CropArea, GraphicsUnit.Pixel);

                _Graphics.Save();
                _InPhoto.Dispose();
                _Graphics.Dispose();


                string _ext = GetExtension(FilePath).ToUpper();
                if (_ext == "JPG" || _ext == "JPEG" || _ext == "JPE")
                {
                    _CroppedPhoto.Save(MakeCroppedFileName(FilePath), System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else if (_ext == "GIF")
                {
                    _CroppedPhoto.Save(MakeCroppedFileName(FilePath), System.Drawing.Imaging.ImageFormat.Gif);
                }
                else if (_ext == "PNG")
                {
                    _CroppedPhoto.Save(MakeCroppedFileName(FilePath), System.Drawing.Imaging.ImageFormat.Png);
                }
                else
                {
                    _CroppedPhoto.Save(MakeCroppedFileName(FilePath), System.Drawing.Imaging.ImageFormat.Bmp);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                _InPhoto.Dispose();
                _InPhoto = null;
                _CroppedPhoto.Dispose();
                _CroppedPhoto = null;
                _Graphics.Dispose();
                _Graphics = null;
            }
        }

        private string GetExtension(string FilePath)
        {
            return FilePath.Split('.')[FilePath.Split('.').Length - 1];
        }
    }

    public class DefaultPhoto
    {
        public int PhotoID { get; set; }

        public int X1 { get; set; }
        public int Y1 { get; set; }

        public int X2 { get; set; }
        public int Y2 { get; set; }
    }

}
