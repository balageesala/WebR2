using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IntellidateR1;
using System.Configuration;
using System.IO;

namespace IntelliWebR1
{
    public class Utils
    {
        public bool IsAcceptWebP(HttpRequest _Request)
        {
            // Chrome exception
            if (_Request.ServerVariables["HTTP_USER_AGENT"].ToString().Contains("Chrome"))
            {
                return true;
            }
            if (_Request.ServerVariables["HTTP_USER_AGENT"].ToString().Contains("image/webp"))
            {
                return true;
            }
            return false;
        }

        public string GetPhotoPCTPath(int PhotoID, HttpRequest _Request)
        {
            try
            {
                Photo Photo = new Photo().GetPhoto(PhotoID);
                string _OrigPhotoPath = ConfigurationManager.AppSettings["PhotosRootPath"].ToString() + Photo.PhotoPath;
                string _PhotoPath = "";

                _PhotoPath = GetFolderName(_OrigPhotoPath) + "\\PCT\\" + GetFileName(_OrigPhotoPath);

                _PhotoPath = _PhotoPath.Replace(ConfigurationManager.AppSettings["PhotosRootPath"].ToString(), ConfigurationManager.AppSettings["PhotosRootUrl"].ToString());
                _PhotoPath = _PhotoPath.Replace("\\", "/");

                if (IsAcceptWebP(_Request))
                {
                    _PhotoPath = _PhotoPath + ".webp";
                }
                else
                {
                    _PhotoPath = _PhotoPath + ".jpg";
                }

                return _PhotoPath;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string GetPhotoPCGTPath(int PhotoID, HttpRequest _Request)
        {
            try
            {
                Photo Photo = new Photo().GetPhoto(PhotoID);
                string _OrigPhotoPath = ConfigurationManager.AppSettings["PhotosRootPath"].ToString() + Photo.PhotoPath;
                string _PhotoPath = "";

                _PhotoPath = GetFolderName(_OrigPhotoPath) + "\\PCGT\\" + GetFileName(_OrigPhotoPath);

                _PhotoPath = _PhotoPath.Replace(ConfigurationManager.AppSettings["PhotosRootPath"].ToString(), ConfigurationManager.AppSettings["PhotosRootUrl"].ToString());
                _PhotoPath = _PhotoPath.Replace("\\", "/");

                if (IsAcceptWebP(_Request))
                {
                    _PhotoPath = _PhotoPath + ".webp";
                }
                else
                {
                    _PhotoPath = _PhotoPath + ".jpg";
                }

                return _PhotoPath;
            }
            catch (Exception)
            {
                return "";
            }
        }


        public string GetPhotoPCGTPath(int PhotoID)
        {
            try
            {
                Photo Photo = new Photo().GetPhoto(PhotoID);
                string _OrigPhotoPath = ConfigurationManager.AppSettings["PhotosRootPath"].ToString() + Photo.PhotoPath;
                string _PhotoPath = "";
                _PhotoPath = GetFolderName(_OrigPhotoPath) + "\\PCGT\\" + GetFileName(_OrigPhotoPath);
                _PhotoPath = _PhotoPath.Replace(ConfigurationManager.AppSettings["PhotosRootPath"].ToString(), ConfigurationManager.AppSettings["PhotosRootUrl"].ToString());
                _PhotoPath = _PhotoPath.Replace("\\", "/");
                _PhotoPath = _PhotoPath + ".jpg";
                return _PhotoPath;
            }
            catch (Exception)
            {
                return "";
            }
        }



        public string GetPhotoFullViewPath(int PhotoID, HttpRequest _Request)
        {
            try
            {
                Photo Photo = new Photo().GetPhoto(PhotoID);
                string _OrigPhotoPath = ConfigurationManager.AppSettings["PhotosRootPath"].ToString() + Photo.PhotoPath;
                string _PhotoPath = "";
                _PhotoPath = GetFolderName(_OrigPhotoPath) + "\\" + GetFileName(_OrigPhotoPath);
                _PhotoPath = _PhotoPath.Replace(ConfigurationManager.AppSettings["PhotosRootPath"].ToString(), ConfigurationManager.AppSettings["PhotosRootUrl"].ToString());
                _PhotoPath = _PhotoPath.Replace("\\", "/");

                if (IsAcceptWebP(_Request))
                {
                    _PhotoPath = _PhotoPath + ".webp";
                }
                else
                {
                    _PhotoPath = _PhotoPath + ".jpg";
                }

                return _PhotoPath;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string GetPhotoFullViewPath(int PhotoID)
        {
            try
            {
                Photo Photo = new Photo().GetPhoto(PhotoID);
                string _OrigPhotoPath = ConfigurationManager.AppSettings["PhotosRootPath"].ToString() + Photo.PhotoPath;
                string _PhotoPath = "";
                _PhotoPath = GetFolderName(_OrigPhotoPath) + "\\" + GetFileName(_OrigPhotoPath);
                _PhotoPath = _PhotoPath.Replace(ConfigurationManager.AppSettings["PhotosRootPath"].ToString(), ConfigurationManager.AppSettings["PhotosRootUrl"].ToString());
                _PhotoPath = _PhotoPath.Replace("\\", "/");            
                _PhotoPath = _PhotoPath + ".jpg";
                return _PhotoPath;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string GetSmallPPCTPath(int PhotoID)
        {
            try
            {
                Photo Photo = new Photo().GetPhoto(PhotoID);
                string _OrigPhotoPath = ConfigurationManager.AppSettings["PhotosRootPath"].ToString() + Photo.PhotoPath;
                string _PhotoPath = "";
                _PhotoPath = GetFolderName(_OrigPhotoPath) + "\\PCT\\" + GetFileName(_OrigPhotoPath);
                _PhotoPath = _PhotoPath.Replace(ConfigurationManager.AppSettings["PhotosRootPath"].ToString(), ConfigurationManager.AppSettings["PhotosRootUrl"].ToString());
                _PhotoPath = _PhotoPath.Replace("\\", "/");
                _PhotoPath = _PhotoPath + ".jpg";
                return _PhotoPath;
            }
            catch (Exception)
            {
                return ""; 
            }
        }

        public string GetSmallPRootPath(int PhotoID)
        {
            try
            {
                Photo Photo = new Photo().GetPhoto(PhotoID);
                string _OrigPhotoPath = ConfigurationManager.AppSettings["PhotosRootPath"].ToString() + Photo.PhotoPath;
                string _PhotoPath = "";
                _PhotoPath = GetFolderName(_OrigPhotoPath) + "\\PCT\\" + GetFileName(_OrigPhotoPath);
                _PhotoPath = _PhotoPath + ".jpg";
                return _PhotoPath;
            }
            catch (Exception)
            {
                return "";
            }
        }


        public string GetOriginalRootPath(int PhotoID)
        {
            try
            {
                Photo Photo = new Photo().GetPhoto(PhotoID);
                string _OrigPhotoPath = ConfigurationManager.AppSettings["PhotosRootPath"].ToString() + Photo.PhotoPath;
                return _OrigPhotoPath;
            }
            catch (Exception)
            {
                return "";
            }
        }



        private string GetFileName(string FilePath)
        {
            string _FileName = Path.GetFileName(FilePath);
            return _FileName.Split('.')[0];
        }

        private string GetFolderName(string FilePath)
        {
            string _FolderName = Path.GetDirectoryName(FilePath);
            return _FolderName;
        }

        public string ConvertEmailBody(string EmailBody)
        {
            try
            {
                string _EmailBody = EmailBody;
                _EmailBody = _EmailBody.Replace("[LANDING_PATH]", ConfigurationManager.AppSettings["SitePath"].ToString());
                _EmailBody = _EmailBody.Replace("[TRACKER_PATH]", ConfigurationManager.AppSettings["SitePath"].ToString() + "post/et?i=[EMAIL_ID]&p=[PRIORITY]");
                _EmailBody = _EmailBody.Replace("[ACTIVATEEMAIL_PATH]", ConfigurationManager.AppSettings["SitePath"].ToString()+"EmailVerification?em=[EMAIL_ID]&dt="+DateTime.Now.ToString());
                _EmailBody = _EmailBody.Replace("[ABOUTUS_LINK]", ConfigurationManager.AppSettings["SitePath"].ToString());
                _EmailBody = _EmailBody.Replace("[PRIVACY_LINK]", ConfigurationManager.AppSettings["SitePath"].ToString());
                _EmailBody = _EmailBody.Replace("[TERMS_LINK]", ConfigurationManager.AppSettings["SitePath"].ToString());

                return _EmailBody;
            }
            catch (Exception)
            {
                return EmailBody;
            }
        }
    }
}