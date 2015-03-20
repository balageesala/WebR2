using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using IntellidateR1;
using System.IO;

namespace IntelliWebR1.web.service
{
    public partial class PhotoView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["pid"] == null)
                {
                    return;
                }
                int PhotoID = Convert.ToInt32(Request.QueryString["pid"].ToString());

                Response.ContentType = "image/jpeg";

                if (Request.QueryString["c"] != null)
                {
                    using (Bitmap _Resized = GetCroppedPhoto(PhotoID))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            _Resized.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            ms.WriteTo(Response.OutputStream);

                        }
                    }
                }

            }
            catch (Exception)
            {

            }
        }

        private Bitmap GetCroppedPhoto(int PhotoID)
        {
            try
            {
                Photo Photo = new Photo().GetPhoto(PhotoID);
                Bitmap Cropped = new Bitmap(Photo.PhotoCropDetails.XWidth, Photo.PhotoCropDetails.YWidth);


                using (Bitmap Original = new Bitmap(ConfigurationManager.AppSettings["PhotosRootPath"].ToString() + Photo.PhotoPath))
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
    }
}