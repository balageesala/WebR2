using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web.service
{
    public partial class UserPhoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (Request.QueryString["uid"] != null)
                    {
                        Response.ContentType = "image/jpeg";
                        string PhotoPath = ConfigurationManager.AppSettings["PhotosRootPath"].ToString();
                        int UserID = Convert.ToInt32(Request.QueryString["uid"]);
                        TempUser UserDetails = new TempUser().GetUserDetails(UserID);
                        if (UserDetails.ProfilePhoto != null)
                        {
                            string _UserPhotoPath = new Utils().GetSmallPRootPath(UserDetails.ProfilePhoto.PhotoID);
                            using (Bitmap _Resized = new Bitmap(_UserPhotoPath))
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    _Resized.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    ms.WriteTo(Response.OutputStream);

                                }
                            }
                        }
                        else
                        {
                            string PhotoUrl = string.Empty;
                            if (UserDetails.Gender == 1)
                            {
                                PhotoUrl = PhotoPath + "M.png";
                            }
                            else
                            {
                                PhotoUrl = PhotoPath + "F.png";
                            }

                            using (Bitmap _Resized = new Bitmap(PhotoUrl))
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    _Resized.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    ms.WriteTo(Response.OutputStream);
                                }
                            }
                        }

                    }
                }
                catch (Exception)
                {
                }                
            }
        }

    


        private Bitmap GetCroppedPhoto(int PhotoID)
        {
            try
            {
                Photo Photo = new Photo().GetPhoto(PhotoID);
                Bitmap Cropped = new Bitmap(Photo.PhotoCropDetails.XWidth, Photo.PhotoCropDetails.YWidth);
                string _PhotoRootPath = ConfigurationManager.AppSettings["PhotosRootPath"].ToString();

                using (Bitmap Original = new Bitmap(_PhotoRootPath + Photo.PhotoPath))
                {
                    Rectangle cropRect = new Rectangle(Photo.PhotoCropDetails.XPosition, Photo.PhotoCropDetails.YPosition, Photo.PhotoCropDetails.XWidth, Photo.PhotoCropDetails.YWidth);

                    using (Graphics g = Graphics.FromImage(Cropped))
                    {
                        g.DrawImage(Original, new Rectangle(0, 0, Photo.PhotoCropDetails.XWidth, Photo.PhotoCropDetails.YWidth),
                                         cropRect,
                                         GraphicsUnit.Pixel);
                        g.Save();
                    }
                }
                int _MaxThumbnailWidth = Convert.ToInt32(ConfigurationManager.AppSettings["PCT"].ToString());
                int _MaxThumbnailHeight = Convert.ToInt32(ConfigurationManager.AppSettings["PCT"].ToString());

                return ImageUtilities.ResizeImage(Cropped, _MaxThumbnailWidth, _MaxThumbnailHeight);

            }
            catch (Exception)
            {
                return null;
            }
        }

        private Bitmap GetDummyPhoto(string _PhotoPath)
        {
            try
            {

                Bitmap Cropped = new Bitmap(_PhotoPath);
                return Cropped;

            }
            catch (Exception)
            {
                return null;
            }
        }

       



    }
}